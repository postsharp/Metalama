# Caravela

Caravela is a tool for aspect-oriented programming (AOP) and general compile-time code modification for C#. It is the future of [PostSharp](https://postsharp.net) and is currently in a very early preview.

To see Caravela in action, go to [try.postsharp.net](https://try.postsharp.net).

<!-- TODO: update the link to source generators once official documentation exists: https://github.com/dotnet/docs/issues/21712 -->
Caravela is built on top of a fork of [Roslyn](https://github.com/dotnet/roslyn) (the C# compiler) and adds to the compiler the ability to execute custom source code modifying extensions. This is similar to [source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/), but more powerful, since source generators are limited to just adding source files, while Caravela can be used for any modifications of the source code. This ability is directly exposed through Caravela.Framework.Sdk and is also used by Caravela.Framework to create a template-based AOP framework.

Caravela is a free preview of a future commercial product. Because of that, any version of the Caravela preview will stop working 90 days after it has been built. To continue using it, you will need to update to a newer preview.

If you have any feedback regarding Caravela, please [open an issue](https://github.com/postsharp/Caravela/issues/new), or contact us directly at hello@postsharp.net.

More detailed information is available about:

* [Caravela.Framework.Sdk](Caravela.Framework.Sdk.md)
* [Caravela.Framework](Caravela.Framework.md)
* [Debugging.md](Debugging.md)
