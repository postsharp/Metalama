# Debugging

When debugging code that uses Caravela, by default, the debugger only shows you your original code, without Caravela-applied modifications. This is convenient when you're using an existing aspect, but when you're developing an aspect, you want to be able to see the transformed code. Caravela offers several options for that, set from a `<PropertyGroup>` section inside your .csproj file:

* `CaravelaEmitCompilerTransformedFiles`: setting this property to `true` means that the transformed code will be written to disk, to the `obj/$Configuration/$Framework/transformed` directory (e.g. `obj/Debug/net5.0/transformed`).
* `CaravelaDebugTransformedCode`: setting this property to `true` means transformed code will be used when debugging and when producing errors and warnings.