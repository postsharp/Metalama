---
uid: overriding-fields-or-properties
---
# Overriding Fields or Properties

In @overriding-methods, you have learned how to wrap an existing method with additional, automatically-generated model. You can do the same with fields and properties thanks to the  @"Caravela.Framework.Aspects.OverrideFieldOrPropertyAspect" abstract class. 

## Creating an OverrideFieldOrPropertyAspect aspect

1. Create a new class derived from the @"Caravela.Framework.Aspects.OverrideFieldOrPropertyAspect" abstract class. This class will be a custom attribute, so it is a good idea to name it with the `Attribute` suffix.

2. Implement the @"Caravela.Framework.Aspects.OverrideMethodAspect.OverrideProperty" property in plain C#:
   - To insert code or expressions that depend on the target method of the aspect (such as the method name or the parameter type), use the @"Caravela.Framework.Aspects.meta" API.
   - Where the original implementation must be invoked, call the <xref:Caravela.Framework.Aspects.meta.Proceed?text=meta.Proceed> method.

3. The aspect is a custom attribute. To transform a method using the aspect, just add the aspect custom attribute to the method.

> [!WARNING]
> When you apply an aspect to a field, Caravela will automatically transform the field into a property. If the field is used by reference using `ref`, `out` and `in` keywords, it will result in a compile-time error.
> (TODO #28909)

### Example: An empty OverrideFieldOrPropertyAspect aspect

The next example shows an empty implementation of @"Caravela.Framework.Aspects.OverrideFieldOrPropertyAspect" applied to a property (TODO: and to a field).

[!include[Empty OverrideFieldOrProperty](../../../code/Caravela.Documentation.SampleCode.AspectFramework/EmptyOverrideFieldOrProperty.cs)]


## Accessing the metadata of the overridden field or property

The metadata of the field or being overridden are available from the template accessors on the <xref:Caravela.Framework.Aspects.meta.FieldOrProperty?text=meta.FieldOrProperty> property . This property gives you all information about the name, type, parameters and custom attributes of the field or property. For instance, the member name is available on `meta.FieldOrProperty.Name` and its type on `meta.FieldOrProperty.Type`. But note that only _metadata_ are exposed there.

The _value_ of the field or property is available on <xref:Caravela.Framework.Aspects.meta.FieldOrProperty?text=meta.FieldOrProperty.Value>. Your aspect can read and write this property, as long as the field or the property is writable. To determine if the field is `readonly` or if the property has a `set` accessor, you can use <xref:Caravela.Framework.Code.IFieldOrProperty.Writeability?meta.FieldOrProperty.Writeability>.

### Example: Resolving dependencies on the fly

The following example is a simplified implementation of the service locator pattern.

The `Import` aspect overrides the getter of a property to make a call to a global service locator. The type of the service is determined from the type of the field or property, using `meta.FieldOrProperty.Type`.
The dependency is not stored, so the service locator must be called every time the property is evaluated.

[!include[Import Service](../../../code/Caravela.Documentation.SampleCode.AspectFramework/GlobalImport.cs)]

### Example: Resolving dependencies on the fly and storing the result

This example builds over the previous one, but the dependency is stored in the field or property after it has been retrieved from the service provider for the first time.

[!include[Import Service](../../../code/Caravela.Documentation.SampleCode.AspectFramework/GlobalImportWithSetter.cs)]