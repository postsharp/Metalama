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
   - Where the original implementation must be invoked, call the <xref:Caravela.Framework.Aspects.meta.Parameters?text=meta.Proceed> method.

5. The aspect is a custom attribute. To transform a method using the aspect, just add the aspect custom attribute to the method.

## Example: an empty OverrideMethod aspect

The following code shows an empty @"Caravela.Framework.Aspects.OverrideMethodAspect", which does not do anything:

[!include[Empty OverrideMethodAttribute](../../../code/Caravela.Documentation.SampleCode.AspectFramework/EmptyOverrideMethodAttribute.cs)]

## Accessing method metadata and parameters

The metadata of the method being overridden are available from the template method on the <xref:Caravela.Framework.Aspects.meta.Method?text=meta.Method> property . This property gives you all information about the name, type, parameters and custom attributes of the method. For instance, the metadata of method parameters are exposed on `meta.Method.Parameters`. But note that only _metadata_ are exposed there.

To access the parameter _values_, you need to access <xref:Caravela.Framework.Aspects.meta.Parameters?text=meta.Parameters>. For instance:

- `meta.Parameters[0].Value` gives you the value of the first parameter,
- `meta.Parameters.Values.ToArray()` creates an `object[]` array with all parameter values,
- `meta.Parameters["a"].Value = 5` sets the `a` parameter to `5`.

## Example: simple logging

The following code writes a message to the system console before and after the method execution. The text includes the name of the target method.

[!include[Simple Logging](../../../code/Caravela.Documentation.SampleCode.AspectFramework/SimpleLogging.cs)]

## Invoking the method with different arguments

When you call `meta.Proceed`, the aspect framework generates a call to the overridden method and passes the parameters it received. If the parameter value has been changed thanks to a statement like `meta.Parameters["a"].Value = 5`, the modified value will be passed.

If you want to invoke the method with a totally different set of arguments, you can do it using <xref:Caravela.Framework.Code.Advised.IAdvisedMethod.Invoke(System.Object[])?text=meta.Method.Invoke>.

> [!NOTE]
> Invoking a method with `ref` or `out` parameters is not yet supported.
