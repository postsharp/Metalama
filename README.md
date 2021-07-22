# PostSharp "Caravela"

[![Gitter](https://badges.gitter.im/postsharp/caravela.svg)](https://gitter.im/postsharp/caravela?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

> You can try PostSharp "Caravela" in your browser, without installing anything, at <https://try.postsharp.net/>.

## Table of contents

- [PostSharp "Caravela"](#postsharp-caravela)
  - [Table of contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Documentation and Examples](#documentation-and-examples)
  - [Licensing](#licensing)
  - [We would love your feedback](#we-would-love-your-feedback)
  - [How does PostSharp "Caravela" compare to Roslyn source generators?](#how-does-postsharp-caravela-compare-to-roslyn-source-generators)
  - [How does PostSharp "Caravela" compare to PostSharp MSIL?](#how-does-postsharp-caravela-compare-to-postsharp-msil)
  - [Compatibility with PostSharp MSIL](#compatibility-with-postsharp-msil)

## Introduction

PostSharp "Caravela" is an extension of the Microsoft "Roslyn" C# compiler that allows you to automatically transform your source code at build time
or design time based on encapsulated code transformations called _aspects_. PostSharp "Caravela" can be used for aspect-oriented programming,
code generation, or architecture validation.

PostSharp "Caravela" is intended to replace the MSIL-based stack that is now the foundation of PostSharp.

## Documentation and Examples

| Link                                                              | Description |
|-------------------------------------------------------------------|------------------------
| [Documentation](https://doc.postsharp.net) | Conceptual and API documentation.
| [Try Caravela](https://try.postsharp.net) | Try Caravela from your browser. Based on https://try.dot.net/ |
| [Caravela.Samples](https://github.com/postsharp/Caravela.Samples) | A dozen of examples in a GitHub repo. |
|[Caravela.Open.AutoCancellationToken](https://github.com/postsharp/Caravela.Open.AutoCancellationToken) | A low-level Caravela aspect that adds cancellation tokens to your method declarations and your method calls.
| [Caravela.Open.Virtuosity](https://github.com/postsharp/Caravela.Open.Virtuosity) | A low-level Caravela aspect that makes your methods virtual (a fork of Virtuosity.Fody).

Examples and code snippets are open-source and tested: 

[![Documentation Snippets](https://github.com/postsharp/Caravela.Documentation/actions/workflows/main.yml/badge.svg)](https://github.com/postsharp/Caravela.Documentation/actions/workflows/main.yml) [![Caravela.Samples](https://github.com/postsharp/Caravela.Samples/actions/workflows/main.yml/badge.svg)](https://github.com/postsharp/Caravela.Samples/actions/workflows/main.yml)


## Licensing

PostSharp "Caravela" is currently released under the terms of the Evaluation License of PostSharp.

> Caravela is currently in EARLY PREVIEW stage and is not intended for commercial use.
> Any version of the Caravela preview will stop working 90 days after it has been built.
> To continue using it, you will need to update to a newer preview.

## We would love your feedback

If you have any feedback regarding Caravela, please [open an issue](https://github.com/postsharp/Caravela/issues/new),
 [start a discussion](https://github.com/postsharp/Caravela/discussions/new), or contact us directly at hello@postsharp.net.

## How does PostSharp "Caravela" compare to Roslyn source generators?

Unlike Roslyn source generators, PostSharp "Caravela":

- can replace or enhance hand-written code (Roslyn source generators are additive only: you just can add partial classes);
- allows you to write aspects (or code transformations):
  - in your main project (instead of a separate project),
  - using the C# language, with Intellisense and code validation (instead of building a string);
- is therefore a real and complete framework for _aspect-oriented programming_ in C#, with the same level of functionality
    than what exists in other languages (such as AspectJ for Java).

## How does PostSharp "Caravela" compare to PostSharp MSIL?

PostSharp "Caravela" was designed from scratch. It is based on best lessons learned from PostSharp MSIL during the last 15 years,
and addresses the main obstacles that are now hindering PostSharp MSIL.

You will enjoy the following benefits with Caravela compared to PostSharp:

- **Faster builds**: Caravela runs directly inside the compiler process (it is a fork of Roslyn), does not require an external process,
  and is therefore much faster;
- **More powerful transformations**: The templating technology used by Caravela allows for more control over code than what was possible
  with PostSharp MSIL.
- **Better multi-platform support**: Caravela does not load the whole project being built in the compiler process, therefore it avoids the
  cross-compilation issues that have plagued PostSharp for many years;
- **Better design-time experience**: You will see introduced members and interfaces in Intellisense because Caravela will do that
  at design time and not at post-compilation time. No need for weird casts.
- **Better run-time performance**: Because of code generation improvements, you can create aspects that execute much faster.
- **Better debugging experience**:  You can switch from source code view to transformed code view can debug the code exactly
  how it is executed.

## Compatibility with PostSharp MSIL

How compatible do we intend to be with PostSharp MSIL? How much code will you need to rewrite?

It has been 12 years since the last major breaking change in PostSharp. Do you remember the .NET landscape in 2008? Clearly,
we cannot build a new platform by keeping compatibility with designs that were optimal 12 years ago. However, we understand that
PostSharp is used by thousands and we want to find a compromise between modernity and backward compatibility.

We have already taken the following compromise:

- your _aspect code_ (typically less than a dozen of classes) will need to be totally rewritten,
- your _business code_ should not be affected.
