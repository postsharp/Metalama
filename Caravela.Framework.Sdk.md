# Caravela.Framework.Sdk

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
