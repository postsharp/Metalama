---
uid: debugging-aspects
---

# Debugging Aspects

Debugging the compile-time logic of an aspect is currently difficult because the compiler does not execute your source code, but the transformed code produced from your source code and stored under an unpredictable path.

To debug compile-time logic:

1. Inject breakpoints directly in your source code:

    - In a build-time method such as `BuildAspect`, call `System.Diagnostics.Debugger.Launch()`.
    - In a template method, call @"Caravela.Framework.Aspects.meta.DebugBreak?text=meta.DebugBreak".

2. Attach the debugger to the process

    - In an aspect test, run the test with the debugger.
    - To debug the compiler, set the `DebugCaravela` property to `True`: 

    ```
    dotnet build -p:DebugCaravela=True
    ```

## See Also

<xref:debugging>