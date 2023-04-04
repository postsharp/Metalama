# Metalama

[![Slack](https://img.shields.io/badge/Slack-4A154B?label=Chat%20with%20us%20on&style=flat&logo=slack&logoColor=white)](https://www.postsharp.net/slack)

> You can try Metalama in your browser, without installing anything, at <https://try.metalama.net/>.

This is the home repo for Metalama, a Roslyn-based meta-programming framework C# with focus on aspect-oriented programmning, code generation and code validation. We use this repo for discussions and bug reports.

## Table of contents

- [Metalama](#metalama)
  - [Table of contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Documentation and Examples](#documentation-and-examples)
  - [Licensing](#licensing)
  - [We would love your feedback](#we-would-love-your-feedback)
  - [How does Metalama compare to Roslyn source generators?](#how-does-metalama-compare-to-roslyn-source-generators)
  - [How does Metalama compare to PostSharp MSIL?](#how-does-metalama-compare-to-postsharp-msil)
  - [Compatibility with PostSharp MSIL](#compatibility-with-postsharp-msil)

## Introduction

Metalama is an extension of the Microsoft "Roslyn" C# compiler that allows you to automatically transform your source code at build time
or design time based on encapsulated code transformations called _aspects_. Metalama can be used for aspect-oriented programming,
code generation, or architecture validation.

Metalama is intended to replace the MSIL-based stack that is now the foundation of PostSharp.

## Documentation and Examples

| Link                                                              | Description |
|-------------------------------------------------------------------|------------------------
| [Documentation](https://doc.metalama.net) | Conceptual and API documentation.
| [Try Metalama](https://try.metalama.net) | Try Metalama from your browser. Based on https://try.dot.net/ |
| [Metalama.Samples](https://github.com/postsharp/Metalama.Samples) | A dozen of examples in a GitHub repo. |
| [Metalama.Open.AutoCancellationToken](https://github.com/postsharp/Metalama.Open.AutoCancellationToken) | A low-level Metalama aspect that adds cancellation tokens to your method declarations and your method calls.
| [Metalama.Open.Virtuosity](https://github.com/postsharp/Metalama.Open.Virtuosity) | A low-level Metalama aspect that makes your methods virtual. (A fork of Virtuosity.Fody.)
| [Metalama.Open.Costura](https://github.com/postsharp/Metalama.Open.Costura) | A low-level Metalama aspect that embeds dependent assemblies as managed resources. (A fork of Costura.Fody.)
| [Metalama.Framework.Extensions](https://github.com/postsharp/Metalama.Framework.Extensions) | Open-source extensions to Metalama.Framework.


## Licensing

Metalama is currently released under the terms of the Evaluation License of PostSharp.

> Metalama is currently in Release Candidate stage and is not intended for commercial use.
> Any version of the Metalama preview will stop working 90 days after it has been built.
> To continue using it, you will need to update to a newer preview.

## We would love your feedback

If you have any feedback regarding Metalama, please [open an issue](https://github.com/postsharp/Metalama/issues/new),
 [start a discussion](https://github.com/postsharp/Metalama/discussions/new), or contact us directly at hello@postsharp.net.

## How does Metalama compare to Roslyn source generators?

Unlike Roslyn source generators, Metalama:

- can replace or enhance hand-written code (Roslyn source generators are additive only: you just can add partial classes);
- allows you to write aspects (or code transformations):
  - in your main project (instead of a separate project),
  - using the C# language, with Intellisense and code validation (instead of building a string);
- is therefore a real and complete framework for _aspect-oriented programming_ in C#, with the same level of functionality
    than what exists in other languages (such as AspectJ for Java).

## How does Metalama compare to PostSharp MSIL?

Metalama was designed from scratch. It is based on best lessons learned from PostSharp MSIL during the last 15 years,
and addresses the main obstacles that are now hindering PostSharp MSIL.

You will enjoy the following benefits with Metalama compared to PostSharp:

- **Faster builds**: Metalama runs directly inside the compiler process (it is a fork of Roslyn), does not require an external process,
  and is therefore much faster;
- **More powerful transformations**: The templating technology used by Metalama allows for more control over code than what was possible
  with PostSharp MSIL.
- **Better multi-platform support**: Metalama does not load the whole project being built in the compiler process, therefore it avoids the
  cross-compilation issues that have plagued PostSharp for many years;
- **Better design-time experience**: You will see introduced members and interfaces in Intellisense because Metalama will do that
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
