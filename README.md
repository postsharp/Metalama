# PostSharp "Caravela"

> You can try PostSharp "Caravela" in your browser, without installing anything, at https://try.postsharp.net/.


## Table of contents
- [PostSharp "Caravela"](#postsharp-caravela)
  - [Table of contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Licensing](#licensing)
  - [Examples](#examples)
  - [We would love your feedback!](#we-would-love-your-feedback)
  - [Debugging code with Caravela](#debugging-code-with-caravela)
  - [Writing your own aspects](#writing-your-own-aspects)
  - [How does PostSharp "Caravela" compare to Roslyn source generators?](#how-does-postsharp-caravela-compare-to-roslyn-source-generators)
  - [How does PostSharp "Caravela" compare to PostSharp MSIL?](#how-does-postsharp-caravela-compare-to-postsharp-msil)
  - [Compatibility with PostSharp MSIL](#compatibility-with-postsharp-msil)
  - [Architecture](#architecture)


## Introduction

PostSharp "Caravela" is an extension of the Microsoft "Roslyn" C# compiler that allows you to automatically transform your source code at build time 
(and, in the future, design time) based on encapsulated code transformations called _aspects_. PostSharp "Caravela" can be used for aspect-oriented 
programming, but is not limited to it.

PostSharp "Caravela" is intended to replace the MSIL-based technology stack that is now the foundation of PostSharp and its copies.

## Licensing

PostSharp "Caravela" is currently released under the terms of the Evaluation License of PostSharp.

> Caravela is currently in EARLY PREVIEW stage and is not intended for commercial use.
> Any version of the Caravela preview will stop working 90 days after it has been built. 
> To continue using it, you will need to update to a newer preview.


## Examples

To see Caravela in action, go to [try.postsharp.net](https://try.postsharp.net).

You can also look at the following repos for example:

* [Caravela.Samples](https://github.com/postsharp/Caravela.Samples): a set of examples built using the Caravela aspect framework. Includes:

    * Logging (of course!)
    * Caching
    * Auto-retry

* [Caravela.Open.AutoCancellationToken](https://github.com/postsharp/Caravela.Open.AutoCancellationToken): a low-level Caravela aspect that
adds cancellation tokens to your method declarations and your method calls.

* [Caravela.Open.Virtuosity](https://github.com/postsharp/Caravela.Open.Virtuosity): a low-level Caravela aspect that makes your
methods virtual (a fork of Virtuosity.Fody).

* [Caravela.Open.DependencyEmbedder](https://github.com/postsharp/Caravela.Open.DependencyEmbedder): a low-level Caravela aspect that
embeds dependent assemblies into managed resources (a fork of Costura.Fody).

All examples are open source.

## We would love your feedback!

If you have any feedback regarding Caravela, please [open an issue](https://github.com/postsharp/Caravela/issues/new),
 [start a discussion](https://github.com/postsharp/Caravela/discussions/new), or contact us directly at hello@postsharp.net.


## Debugging code with Caravela

By default, the debugger will show you your _source_ code, not the transformed code. To see and step into the transformed code,
see [Debugging](Debugging.md).

## Writing your own aspects

### Caravela.Framework: the simple and safe aspect framework

[Caravela.Framework](Caravela.Framework.md) is an aspect-oriented framework that allows you to write code transformations and
code generators in a simple and natural way, without working with compiler APIs.

> Caravela.Framework is now in VERY EARLY PREVIEW. It is not considered to be complete except for the simplest use cases.
> Our ambition is to implement all features of PostSharp MSIL into Caravela.Framework.

### Caravela.Framework.Sdk: the low-level extensibility API

[Caravela.Framework.Sdk](Caravela.Framework.Sdk.md) is the low-level API, which allows you to transform any Roslyn compilation
in any way, without any guard or simplification.

> Caravela.Framework.Sdk is considered to be almost final. We don't expect many changes.



## How does PostSharp "Caravela" compare to Roslyn source generators?

Unlike Roslyn source generators, PostSharp "Caravela":

 * can replace or enhance hand-written code (Roslyn source generators are additive only),
 * allows you to write aspects (or code transformations):
     * in your main project (instead of a separate project),
     * using a simple and natural API (instead of using the complex Roslyn API).


## How does PostSharp "Caravela" compare to PostSharp MSIL?

PostSharp "Caravela" was designed from scratch. It is based on best lessons learned from PostSharp MSIL during the last 15 years,
and addresses the main obstacles that are now hindering PostSharp MSIL.


You will enjoy the following benefits with Caravela compared to PostSharp:

* **Faster builds**: Caravela runs directly inside the compiler process (it is a fork of Roslyn), does not require an external process, 
  and is therefore much faster;
* **Better multi-platform support**: Caravela does not load the whole project being built in the compiler process, therefore it avoids the 
  cross-compilation issues that have plagued PostSharp for many years;
* **Better design-time experience**: You will see introduced members and interfaces in Intellisence because Caravela will do that
  at design time and not at post-compilation time. No need for weird casts.
* **More powerful transformations**: The templating technology used by Caravela allows for more control over code than what was possible
  with PostSharp MSIL.
* **Better run-time performance**: Because of code generation improvements, you can create aspects that execute much faster.
* **Better debugging experience**:  You can switch from source code view to transformed code view can debug the code exactly 
  how it is executed.


## Compatibility with PostSharp MSIL

How compatible do we intend to be with PostSharp MSIL? How much code will you need to rewrite?

It has been 12 years since the last major breaking change in PostSharp. Do you remember the .NET landscape in 2008? Clearly,
we cannot build a new platform by keeping compatibility with designs that were optimal 12 years ago. However, we understand that
PostSharp is used by thousands and we want to find a compromise between modernity and backward compatibility.

We have already taken the following compromise:

* your _aspect code_ (typically less than a dozen of classes) will need to be totally rewritten,
* your _business code_ should not be affected.


## Architecture

 The foundation of PostSharp "Caravela" is the package _Caravela.Compiler_, a fork of [Roslyn](https://github.com/dotnet/roslyn) (the C# compiler) that adds to the compiler 
 the ability to execute custom source code modifying extensions. When you build a project using Caravela, this fork of Roslyn is loaded
 instead of the Microsoft vanilla C# compiler.

 The  _Caravela.Compiler_ package is not designed to be used or extended by end users.

 _Caravela.Framework_ is an add-in (the only one) to _Caravela.Compiler_. It contains the code transformation framework.

 _Caravela.Framework_ is designed to be hostable by Visual Studio and to integrate with design-time source
 generators, although this feature has not yet been implemented.

