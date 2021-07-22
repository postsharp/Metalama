---
uid: installing
---

# Adding Caravela to Your Project


## Installing the NuGet package
Before you start developing aspects, you must add the `Caravela.Framework` package to your project:

```xml
<ItemGroup>
    <ProjectReference Include="Caravela.Framework" Version="CHANGE ME"/>
</ItemGroup>    
```

For details of all NuGet packages and their dependencies, see <xref:packages>.

>[!NOTE]
>Caravela requires a platform that supports .NET Standard 2.0.


## Installing PostSharp "Caravela" Tools for Visual Studio

To create new aspects, we suggest that you use Visual Studio 2018 and install [PostSharp "Caravela" Tools for Visual Studio](https://marketplace.visualstudio.com/items?itemName=PostSharpTechnologies.caravela). This extension adds syntax highlighting to aspect code (like in the present documentation) and can be of great help, especially if you are just getting started with Caravela.