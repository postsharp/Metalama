# Caravela.Framework

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

## Aspects, advices and Initialize

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

## Template context

Inside a template method, extra operations are available through members of the `TemplateContext` class. These members are intended to be used directly, which requires adding `using static Caravela.Framework.Aspects.TemplateContext;` to the top of your files. To make these members look like special operations, they use the camelCase naming convention, violating .NET naming conventions, which require PascalCase.

These members are:

* `dynamic proceed()`: Gives control to the original code of the method the template is being applied to. When multiple advices per method are supported, this will instead give control to the next template in line, if there are any left.
* `ITemplateContext target { get; }`: Gives access to information about the code element the template is being applied to.
* `T compileTime<T>( T expression )`: Informs the templating engine that this expression should be considered to be compile-time, even when it normally would not. Other than that, the input value is returned unchanged.