---
uid: packages
---

# Packages and Components

Caravela is composed of half a dozen of NuGet packages. It may sounds a lot, but some are used only for testing and will never make it to your public packages.


## Package list

| Package Name | Scenarios | Description |
|--|--|--|
| Caravela.Framework.Redist | Run-time | Required to execute code built with Caravela, but does not contain or reference the assets to build with Caravela |
| Caravela.Framework | Compile-time | The typical top-level package for a project that uses Caravela aspects. See <xref:installing>.
| Caravela.Compiler | Compile-time | Replaces Microsoft's C# compiler by Caravela's own fork.
| Caravela.TestFramework | Test | The top-level package for test projects. References `Caravela.Framework` but inhibits most of its behaviors. See <xref:compile-time-testing>. |
| Caravela.Framework.Impl | Test | An opaque implementation assembly required by the test framework. |
| Caravela.Framework.Contracts.DesignTime | Test | An opaque implementation assembly  required by the test framework.. |

## Package diagram


```mermaid
graph TD
    Caravela.Framework -- references --> Caravela.Framework.Redist
    Caravela.Framework -- references-->  Caravela.Compiler
    Caravela.Framework -- contains --> analyzers((analyzers))
    Caravela.TestFramework -- inhibits --> Caravela.Framework
    Caravela.TestFramework -- references--> Caravela.Framework.Impl
    Caravela.Framework.Impl -- references--> Caravela.Framework.Contracts.DesignTime

    Caravela.Compiler -- contains --> compiler((full compiler))

    classDef testing fill:orange;
    class Caravela.TestFramework testing;
    class Caravela.Framework.Impl testing;
    class Caravela.Framework.Contracts.DesignTime testing;

    classDef compileTime fill:yellow;
    class Caravela.Framework compileTime;
    class Caravela.Compiler compileTime;

    classDef runTime fill:lightgreen;
    class Caravela.Framework.Redist runTime;

    


    subgraph Legend

        t[For testing]
        class t testing

        c[Compile-time]
        class c compileTime

        r[Run-time]
        class r runTime

    end




```

## Visual Studio extension

Additionally to the NuGet packages, Caravela has a [Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=PostSharpTechnologies.caravela) to help you write new aspects This extension is optional but is recommended, at least in the beginning when you are learning the meta template language.