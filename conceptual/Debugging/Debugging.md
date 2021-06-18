---
uid: debugging
---

# Debugging

## Debugging User Code

When debugging code that uses Caravela, by default, the debugger only shows you your original code, without Caravela-applied modifications. This is convenient when you're using an existing aspect, but when you're developing an aspect, you want to be able to see the transformed code. Caravela offers several options for that, set from a `<PropertyGroup>` section inside your `.csproj` or `Directory.Build.props` file:


| Property Name                          | Description                                                                                                                                                                                  |
|----------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `CaravelaEmitCompilerTransformedFiles` | Setting this property to `True` means that the transformed code will be written to disk, to the `obj/$Configuration/$Framework/transformed` directory (e.g. `obj/Debug/net5.0/transformed`). |
| `CaravelaDebugTransformedCode`         | Setting this property to `True` means transformed code will be used when debugging and when producing errors and warnings.                                                                   |

## Debugging Aspects

Debugging the compile-time logic of an aspect is currently difficult because the compiler does not execute your source code, but the transformed code produced from your source code and stored under an unpredictable path.

To debug compile-time logic:

1. Inject breakpoints directly in your source code:

    - In a build-time method such as `BuildAspect`, call ``System.Diagnostics.Debugger.Launch()`.
    - In a template method, call `meta.DebugBreak()` (see @"Caravela.Framework.Aspects.meta.DebugBreak").

2. Attach the debugger to the process

    - In an aspect test, run the test with the debugger.
    - To debug the compiler, set the `DebugCaravela` property to `True`: `dotnet build -p:DebugCaravela=True`.