# Metalama

[![Slack](https://img.shields.io/badge/Slack-4A154B?label=Chat%20with%20us&style=flat&logo=slack&logoColor=white)](https://www.postsharp.net/slack) 
[![Discord](https://img.shields.io/badge/Discord-4A154B?label=Chat%20with%20us&style=flat&logo=discord&logoColor=white)](https://www.postsharp.net/discord)

![Metalama Logo](images/metalama-by-postsharp.svg)

Welcome to Metalama, a cutting-edge Roslyn-based meta-programming framework designed to enhance your code quality and productivity in C#. Metalama stands on three foundational principles:

* *Boilerplate Reduction*: Harness the power of aspect-oriented programming to dynamically generate repetitive code during compilation. This ensures your source code stays concise and clear.
* *Architecture as Code*: Receive real-time validation of your code against your architectural guidelines, patterns, and conventions. Say goodbye to waiting for code reviews.
* *Tailored Coding Assistance*: Arm your team with personalized code fixes and refactorings.


## Quick Links

- 🌐 [Metalama Website](https://www.postsharp.net/metalama)
- 📖 [Documentation](https://doc.metalama.net/)
- 📝 [Annotated Examples](https://doc.metalama.net/examples)
- 🎥 [Tutorial Videos](https://doc.metalama.net/videos)
- 🐞 [Bug Reports](https://github.com/postsharp/Metalama/issues)
- 💬 [Discussions](https://github.com/postsharp/Metalama/discussions)
- 📜 [Detailed Changelog](https://github.com/orgs/postsharp/discussions/categories/changelog)
- 📢 [Release Notes](https://doc.metalama.net/conceptual/aspects/release-notes)


## Repositories

This repository serves as a hub for Metalama. The codebase is distributed across the following repositories:

| Link                                                                           | License          | Description                                                                                                                                     |
| ------------------------------------------------------------------------------ | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| [PostSharp.Engineering](https://github.com/postsharp/PostSharp.Engineering)    | MIT              | A custom multi-repo build and CI framework.                                                                                                       |
| [Metalama.Compiler](https://github.com/postsharp/Metalama.Compiler)           | MIT              | A [Roslyn](https://github.com/dotnet/roslyn) fork that introduces an extension point for arbitrary source code transformations. |
| [Metalama.Framework](https://github.com/postsharp/Metalama.Framework)         | Source Available | The core implementation of the Metalama Framework.                                                                                               |
| [Metalama.Framework.RunTime](https://github.com/postsharp/Metalama.Framework.RunTime) | MIT  | Run-time classes utilized by code generated via `Metalama.Framework`.                                                                            |
| [Metalama.Extensions](https://github.com/postsharp/Metalama.Extensions)        | MIT              | Open-source, professional-grade extensions for Metalama such as dependency injection or architecture verification.                                                                                        |
| [Metalama.Patterns](https://github.com/postsharp/Metalama.Patterns)            | MIT              | Ready-to-use, open-source and professional-grade aspects, including caching, code contracts, and `INotifyPropertyChanged`.                                          |
| [Metalama.LinqPad](https://github.com/postsharp/Metalama.LinqPad)              | MIT              | A LinqPad driver for querying any C# project or solution.                                                                                        |
| [Metalama.Community](https://github.com/postsharp/Metalama.Community)          | MIT              | Repository housing community-contributed aspects.                                                                                                |
| [Metalama.Migration](https://github.com/postsharp/Metalama.Migration)          | MIT              | The original PostSharp API annotated with guidelines to transition to Metalama.                                                        |
| [Metalama.Documentation](https://github.com/postsharp/Metalama.Documentation)  | MIT              | Source repository for documentation hosted on [Metalama Docs](https://doc.metalama.net/).                                                       |
| [Metalama.Samples](https://github.com/postsharp/Metalama.Samples)              | MIT              | A collection of illustrative samples available at [Metalama Examples](https://doc.metalama.net/examples).                                        |


## The Dream Weavers of Metalama

It's in the vibrant streets of Prague, Czechia, that an insurrection against boilerplate took rose in 2004. Back in the days when the C# compiler was an obscure, closed-source monolith, inaccessible for extensibility, our first product PostSharp became the first successful implementation of aspect-oriented in .NET. Fifteen years later, when Microsoft released .NET 5 and added source generators to Roslyn, we knew it was time for a complete rewrite based on new .NET stack. This project, originally codenamed "Caravela", became Metalama. 

### The Core Team

- **[Gael Fraiteur](https://github.com/gfraiteur)**: The Captain of our ship, Lead Architect, and beloved Chief Mad Scientist.
- **[Antonin Prochazka](https://github.com/prochan2)**: Senior Software Developer, DevOps Maestro, and the guy who often talks to machines (and they listen).
- **[Daniel Balas](https://github.com/addabis)**: Senior Software Developer and our in-house "Thread Whisperer". Rumor has it he can split threads finer than hair!
- **[Petr Onderka](https://github.com/svick)**: Senior Software Developer and Compiler Maniac, often found in deep conversations with compilers late into the night.
- **[Zuzana Hybsova](https://github.com/Zu-Hy)**: Our anchor, the Back-Office Manager. The only one who ensures our creative chaos remains just the right side of insane.

### The Passionate Collaborators

- **[Alex Dolin](https://github.com/aleksd)**: Dived head-first into Metalama's proof-of-concept phase in 2020 when the project was still named Caravela.
- **[Tom Glastonbury](https://github.com/tg73)**: The passionate soul behind the inception of `Metalama.Patterns` in 2023. Some say he dreams in patterns.

### Our Enthusiast VIPs

We extend our deepest gratitude to the following champions for their countless suggestions, invaluable feedback, and diligent bug reports that have immensely contributed to our community:

- [Whit Waldo](https://github.com/WhitWaldo)
- [Dom Sinclair](https://github.com/domsinclair)
- [Onur Er](https://github.com/XtroTheArctic)
- Marc K

Their dedication and insights have been pivotal in shaping Metalama to its finest.