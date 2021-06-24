---
uid: compile-time-testing
---

# Compile-Time Testing

The idea of compile-time testing is to create both _input_ test files annotated with aspects and _output_ test files which contain the transformed code (possibly with comments for errors and warnings), and to rely on the compile-time testing framework to automatically execute inputs and verify that the outputs match the expectations.

Concretely, you can follow the following steps (detailed below):

1. Create a test project.
2. For each test case:
   1. Create an input file, say `MyTest.cs`, that includes some target code annotated with the aspect custom attribute.
   2. Run the test.
   3. Verify the transformed code visually. Fix bugs until the transformed code is not as expected.
   4. Copy the test output to a file named with the extension `.t.cs`, say `MyTest.t.cs`.


> ![NOTE]
> For a real-world example, see https://github.com/postsharp/Caravela.Samples. Sample aspects are tested using the approach described here.

## Step 1. Create an aspect test project with Caravela.TestFramework

1. Create a Xunit test project.
2. Add the `Caravela.TestFramwework` package.

> [!WARNING]
> Do not add the `Caravela.TestFramework` to a project that you do not intend to use _exclusively_ for compile-time tests. This packages significantly changes the semantics of the project items.

Typically, the `csproj` project file of a compile-time test project would have the following content:

```xml
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.7.1" />
        <PackageReference Include="xunit" Version="2.4.1" />
        <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3">
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
            <PrivateAssets>all</PrivateAssets>
        </PackageReference>
        <PackageReference Include="Caravela.Framework" Version="TODO" />
        <PackageReference Include="Caravela.TestFramework" Version="TODO" />
    </ItemGroup>

</Project>
```

### Customizations performed by Caravela.TestFramework

When you import the `Caravela.TestFramework` package in a project, the following happens:

1. The `CaravelaEnabled` project property is set to `False`, which completely disables Caravela for the project.
  
2. Expected test results (`*.t.cs`) are excluded from the compilation.

3. The Xunit test framework is customized to execute tests from standalone _files_ instead of from methods annotated with `[Fact]` or `[Theory]`.
   

## Step 2. Add a test case

Every source file in the project is a standalone test case. It typically contains some source code to which your aspect is applied, but it can also contain an aspect. You can consider that every file constitutes a project in itself, and this small project receives the project references of the parent compile-time project.

Every test includes:

- A main test file, named say `BlueSky.cs`.
- A file containing the _expected transformed code_ of the main test file, named with the `.t.cs` extension, e.g. `BlueSky.t.cs`. We recommend you do not create this file manually, but you copy the actual output of the test after you are satisfied with it (see below).
- Optionally, one or more auxiliary test files, whose name starts with the main test file, e.g. `BlueSky.*.cs`. Auxiliary files are included in the test compilation but their transformed code is not appended to the `.t.cs` file.

> [!NOTE]
> The name of the main file of your test case cannot include a `.`, except for the `.cs` extension.

For instance, suppose that we are testing the following aspect. This file would typically be included in a class library project.

[!include[Main](../../../code/Caravela.Documentation.SampleCode.AspectFramework/Testing.Aspect.cs)]

To test this aspect, we create a test file with the following content:

[!include[Main](../../../code/Caravela.Documentation.SampleCode.AspectFramework/Testing.cs)]

### Restricting the compared region of transformed code

If you want the test to compare only one declaration (e.g. a class or a method) of your main file, you can mark this class with the `// <target>` comment. This comment must be on the top of any custom attribute on this declaration, and its spacing must be exactly as shown.

### Include other files

If you want to include in the test compilation other files than auxiliary files based on the file name, you can do it by adding a comment of this form in the main test file:

```cs
// @Include(../Path/To/The/File.cs)
```

The included file will behave just as an auxiliary file.

## Step 3. Run the test case

When you create a new test file, your IDE does not discover it automatically. To make the new test appear in the Test Explorer, you first need to run all tests in the project. After the first run, the test will appear in the Test Explorer and it will be possible to execute tests one by one.

You can also run the tests using `dotnet test`.

You can find the output code, transformed by your aspects, at two locations:

- in the _additional output_ of the test message,
- under the `obj/Debug/XXX/transformed` folder, with the name `*.t.cs`.

For the example above, the test output is the following:

[!include[Testing](../../../code/Caravela.Documentation.SampleCode.AspectFramework/Testing.t.cs)]

Verify that the output code matches your expectations. If necessary, fix your aspect and run the test again. Repeat as many times as necessary.

## Step 4. Copy to the test output to the expected output

Once you are satisfied with the test output, copy the expected code to `.t.cs` file. For instance, if your test file is named `MyTest.cs`, copy the test output to the file named `MyTest.t.cs`.

> [!WARNING]
> The _Paste_ command of Visual Studio can reformat the code and break the test.

To accept the output of all tests:

1. Commit or stages the changes in your repository, so you will be able to review and possibly rollback the consequence of the next steps.

2. Run the following sequence of commands:

    ```powershell
    # Make sure there is no garbage in the obj\transformed from another commit.
    dotnet build -t:CleanTestOutput

    # Run the tests (it does not matter if they fail)
    dotnet test

    # Copy the actual output to the expected output
    dotnet build -t:AcceptTestOutput
    ```

3. Review modified each file in your repository using the diff tool.

## Advanced features

### Excluding a directory

By default, all files in a compile-time test project are turned into test input files. To disable this behavior for a project directory, create a file named `caravelaTests.json` and add the following content:

```json
{ "Exclude": true }
```

Note that, by default, all source files are excluded from the compilation, even those in the directories that have been excluded by this mechanism. To include the files, define the project property _CaravelaTestAutoExclude_ to _False_ and include/exclude the files manually as needed. Note that the `*.t.cs` files are always excluded.

### Enabling file nesting in Solution Explorer

To make the `.t.cs.` file appear under its parent `.cs` file:

- In Visual Studio:
    1. In Solution Explorer, select the compile-time project.
    2. Click on the file nesting icon in the Solution Explorer Toolbar.
    3. Define a custom profile and add the following content:

    ```json
    {
        "help": "https://go.microsoft.com/fwlink/?linkid=866610",
        "dependentFileProviders": {
            "add": {
                "extensionToExtension": {
                    "add": {
                        ".t.cs": [ ".cs" ],
                        ".t.html": [ ".cs" ]
                    }
                }
            }
        }
    }
    ```                

- In Rider:
    1. In Solution Explorer, click on the settings (wheel) icon in the Solution Explorer toolbar.
    2. Choose _File Nesting Settings_.
    3. To the `.cs` rule, add the `.t.cs` extension.


### Creating hierarchical test runners in Rider or Resharper

JetBrains tools do not support the customized compile-time test framework. As a workaround, the Caravela testing framework registers a default test runner that discovers all tests in the current project and add them as test cases for a `[Theory]`-based universal test method.

If you have a large number of tests and want to see a hierarchical view, you can create, in each directory you want, a file named `_Runner.cs`, with the following content (in the namespace of your choice):

[!include[Test Runner](../../../code/Caravela.Documentation.SampleCode.AspectFramework/_Runner.cs)]

The `[CurrentDirectory]` attribute will automatically provide test data for all files located under the directory containing the `_Runner.cs` file as well as any child directory.

Note that custom runners are only supported in Resharper and Rider. They are ignored in other environments and replaced by the customized test framework.