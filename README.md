# Caravela

Caravela is a tool for aspect-oriented programming (AOP) and general compile-time code modification for C#. It is the future of [PostSharp](https://postsharp.net) and is currently in a very early preview.

<!-- TODO: update the link to source generators once official documentation exists: https://github.com/dotnet/docs/issues/21712 -->
Caravela is built on top of a fork of [Roslyn](https://github.com/dotnet/roslyn) (the C# compiler) and adds to the compiler the ability to execute custom source code modifying extensions. This is similar to [source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/), but more powerful, since source generators are limited to just adding source files, while Caravela can be used for any modifications of the source code. This ability is directly exposed through Caravela.Framework.Sdk and is also used by Caravela.Framework to create a template-based AOP framework.

Caravela is a free preview of a future commercial product. Because of that, any version of the Caravela preview will stop working 90 days after it has been built. To continue using it, you will need to update to a newer preview.

If you have any feedback regarding Caravela, please [open an issue](https://github.com/postsharp/Caravela/issues/new), or contact us directly at hello@postsharp.net.

## Caravela.Framework.Sdk

Caravela.Framework.Sdk offers direct access to Caravela's underlying code-modifying capabilities through [Roslyn-based APIs](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/compiler-api-model). To use it, you implement the following interface:

```c#
public interface IAspectWeaver
{
    CSharpCompilation Transform(AspectWeaverContext context);
}

public sealed class AspectWeaverContext
{
    public CSharpCompilation Compilation { get; }
    public IReadOnlyList<AspectInstance> AspectInstances { get; }
    public IDiagnosticSink Diagnostics { get; }
}
```

An implementation of this interface receives a Roslyn compilation and can modify it in any way using Roslyn syntax and semantic APIs. It also receives information about where its associated attribute has been applied (called "aspect instances"). And it can produce diagnostics (errors and warnings) if it has been used incorrectly.

Note that because Caravela replaces the compiler used to build your code, but not the one used by the IDE, any modifications made here will not affect code completion.

Caravela.Framework.Sdk is in preview, but it is mostly feature complete.

Available examples of Caravela.Framework.Sdk weavers are:

* [Caravela.Open.Virtuosity](https://github.com/postsharp/Caravela.Open.Virtuosity): makes all possible methods in a project `virtual`
* [Caravela.Open.AutoCancellationToken](https://github.com/postsharp/Caravela.Open.AutoCancellationToken): automatically propagates `CancellationToken` parameter
* [Caravela.Open.Costura](https://github.com/postsharp/Caravela.Open.Costura): bundles .NET Framework applications into a single executable file

The Caravela.Open.Virtuosity repository contains very little logic, so it can be used as a template for your own weavers.

## Caravela.Framework

Caravela.Framework is an [AOP](https://en.wikipedia.org/wiki/Aspect-oriented_programming) framework based on templates written in pure C#.

These templates make it easy to write code that combines compile-time information (such as names and types of parameters of a method) and run-time information (such as parameter values) in a natural way, without having to learn another language or having to combine C# with some special templating language.

For example, consider this simple aspect, which logs the name of a method and information about its parameters to the console and then lets it execute as usual:

```c#
class Log : OverrideMethodAspect
{
    public override dynamic Template()
    {
        Console.WriteLine(target.Method.Name);
        foreach (var parameter in target.Parameters)
        {
            Console.WriteLine(parameter.Type + " " + parameter.Name + " = " + parameter.Value);
        }

        return proceed();
    }
}
```

This aspect can be applied to a method as an attribute:

```c#
[Log]
void CountDown(string format, int n)
{
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine(format, i);
    }
}
```

This changes the method so that it behaves as if it was written like this:

```c#
void CountDown(string format, int n)
{
    Console.WriteLine("CountDown");
    Console.WriteLine("string format = " + format);
    Console.WriteLine("int n = " + n);
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine(format, i);
    }
}
```

Notice that the compile-time `foreach` loop was unrolled, so that each parameter has its own statement and that the compile-time expressions `parameter.Type` and `parameter.Name` have been evaluated and even folded with the nearby constants. On the other hand, the run-time calls to `Console.WriteLine` have been preserved. The expression `parameter.Value` is special, and has been translated to accessing the values of the parameters.

Caravela.Framework is in a very early preview, which means it currently has severe limitations:

* `OverrideMethod` is the only available aspect/advice
* many constructs of C# (including very common ones) are not supported in templates
* only a single advice can be applied to each method

### Aspects, advices and Initialize

While abstract aspects like `OverrideMethodAspect` work well for simple needs, more customization is required in more complex cases. For example, consider the situation where you want to apply an aspect attribute to a type and have it affect all its methods. In Caravela, you can do this by directly implementing the `IAspect<T>` interface and putting this logic into the `Initialize` method. For example:

```c#
public class CountMethodsAspect : Attribute, IAspect<INamedType>
{
    public void Initialize(IAspectBuilder<INamedType> aspectBuilder)
    {
        var methods = aspectBuilder.TargetDeclaration.Methods.GetValue();

        this.methodCount = methods.Count();

        foreach (var method in methods)
        {
            aspectBuilder.AdviceFactory.OverrideMethod(method, nameof(Template));
        }
    }

    int i;
    int methodCount;

    [OverrideMethodTemplate]
    public dynamic Template()
    {
        Console.WriteLine($"This is {++this.i} of {this.methodCount} methods.");
        return proceed();
    }
}
```

This aspect adds the `OverrideMethod` *advice* to each method in a marked type. Here, "advice" is some kind of modification applied to a single element in your code.

As you can see, the `Initialize` method can also be used for other purposes, like initializing values shared by the advices of the aspect.

### Template context

Inside a template method, extra operations are available through members of the `TemplateContext` class. These members are intended to be used directly, which requires adding `using static Caravela.Framework.Aspects.TemplateContext;` to the top of your files. To make these members look like special operations, they use the camelCase naming convention, violating .NET naming conventions, which require PascalCase.

These members are:

* `dynamic proceed()`: Gives control to the original code of the method the template is being applied to. When multiple advices per method are supported, this will instead give control to the next template in line, if there are any left.
* `ITemplateContext target { get; }`: Gives access to information about the code element the template is being applied to.
* `T compileTime<T>( T expression )`: Informs the templating engine that this expression should be considered to be compile-time, even when it normally would not. Other than that, the input value is returned unchanged.

## Debugging

When debugging code that uses Caravela, by default, the debugger only shows you your original code, without Caravela-applied modifications. This is convenient when you're using an existing aspect, but when you're developing an aspect, you want to be able to see the transformed code. Caravela offers several options for that, set from a `<PropertyGroup>` section inside your .csproj file:

* `CaravelaEmitCompilerTransformedFiles`: setting this property to `true` means that the transformed code will be written to disk, to the `obj/$Configuration/$Framework/transformed` directory (e.g. `obj/Debug/net5.0/transformed`).
* `CaravelaDebugTransformedCode`: setting this property to `true` means transformed code will be used when debugging and when producing errors and warnings.