---
uid: distributing
---

# Distributing Projects That Use Aspects

When your project uses aspects, you need to consider whether the projects that _reference_ your projects will also need to use aspects just because of this reference.

## Flowing the use of aspects

Your project may _flow_ the necessity to use the aspect framework to consuming projects for one the following reasons:

* Your project exposes public aspects that can be used by referencing projects.
* Your project has non-sealed, public classes that have _inheritable_ aspects. (Not implemented)
* Your project has policies on referencing projects. (Not implemented)

If this is the case of your project, you do not need to take any action. Your package reference to `Caravela.Framework` will flow to the consumers of your project.


## Avoiding to flow the use of aspects

If, conversely, the consumers of your project will _not_ need to use aspects just because of your project, you can prevent the `Caravela.Framework` to flow to the consumers of your project by setting the `PrivateAssets="all"` property to the package reference. Additionally, you need to include the `Caravela.Framework.Redist` package, which is the only package that needs to flow to consumers.

This is achieved by the following code snippet in your `.csproj` file:

```xml
<ItemGroup>
    <PackageReference Include="Caravela.Framework" Version="CHANGE ME" PrivateAssets="all" />
    <PackageReference Include="Caravela.Framework.Redist" Version="CHANGE ME" />
</ItemGroup>
```
