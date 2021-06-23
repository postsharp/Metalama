---
uid: overriding-methods
---
# Overriding Methods

You can override the hand-written body of a method with code automatically-generated code thanks to the @"Caravela.Framework.Aspects.OverrideMethodAspect" abstract class. This is the simplest and most common aspect. 

## Creating an OverrideMethod aspect

1. Add the `Caravela.Framework` package to your project:

    ```xml
    <ProjectReference Include="Caravela.Framework" Version="TODO"/>
    ```

2. Import the @"Caravela.Framework.Aspects" namespace.
   
3. Create a new class derived from the @"Caravela.Framework.Aspects.OverrideMethodAspect" abstract class. This class will be a custom attribute, so it is a good idea to name it with the `Attribute` suffix.

4. Implement the @"Caravela.Framework.Aspects.OverrideMethodAspect.OverrideMethod" method in plain C#: 
   - To insert code or expressions that depend on the target method of the aspect (such as the method name or the parameter type), use the @"Caravela.Framework.Aspects.meta" API.
   - Where the original implementation must be invoked, call the `meta.Proceed()` method.

5. The aspect is a custom attribute. To transform a method using the aspect, just add the aspect custom attribute to the method.

## Example: an empty OverrideMethod aspect

The following code shows an empty @"Caravela.Framework.Aspects.OverrideMethodAspect", which does not do anything:

[!code-csharp[Main](../../../code/Caravela.Documentation.SampleCode.AspectFramework/EmptyOverrideMethodAttribute.cs)]

## Example: simple logging

The following code writes a message to the system console before and after the method execution. The text includes the name of the target method.

[!include[Simple Logging](../../../code/Caravela.Documentation.SampleCode.AspectFramework/SimpleLogging.cs?sample)]

