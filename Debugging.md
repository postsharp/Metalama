# Debugging

When debugging code that uses Caravela, by default, the debugger only shows you your original code, without Caravela-applied modifications. This is convenient when you're using an existing aspect, but when you're developing an aspect, you want to be able to see the transformed code. Caravela offers several options for that, set from a `<PropertyGroup>` section inside your `.csproj` or `Directory.Build.props` file:



| Property Name  | Description
| ---------------|--------------
| `CaravelaEmitCompilerTransformedFiles` | Set this property to `True` to write the transformed code to disk, to the `obj/$Configuration/$Framework/transformed` directory (e.g. `obj/Debug/net5.0/transformed`).
|  `CaravelaDebugTransformedCode` | Set this property to `True` to compile the transformed code with debugging symbols.
| `DebugCaravela` | Set this property to `True` to attach the debugger to the compiler process.
