---
uid: overriding-members
---
# Overriding Members (Reloaded)

In the section @simple-aspects, you have learned to override methods, properties, fields and events using a simple object-oriented API. In this section, you will learn how to achieve the same thing using the advising API. This will allow you to modify not only the method that is the immediate target of the aspect, but any method in the type being targeted.

## Overriding methods

To override one or more methods, your aspects needs to implement the <xref:Caravela.Framework.Aspects.IAspect%601.BuildAspect(Caravela.Framework.Aspects.IAspectBuilder{%600})> method, then call the <xref:Caravela.Framework.Aspects.IAdviceFactory.OverrideMethod(Caravela.Framework.Code.IMethod,System.String,Caravela.Framework.Aspects.AdviceOptions)> method exposed on `builder.AdviceFactory`.

The _first argument_ of `OverrideMethod` is the @Caravela.Framework.Code.IMethod that you want to override. This method must be in the type being targeted by the current aspect instance.

The _second argument_ of `OverrideMethod` is the name of the template method. This method must exist in the aspect class and, additionally:

* the template method must be annotated with the `[Template]` attribute,
* the template method must have exactly the following signature:

    ```cs
    dynamic? Template()
    ```

### Example: synchronized object

The following aspects wraps all instance methods with a `lock( this )` statement.

> [!NOTE]
> In a production-ready implementation, you should not lock `this` but a private field. You can introduce this field as described in @introducing-members. A product-ready implementation should also wrap properties.

[!include[Synchronized](../../../code/Caravela.Documentation.SampleCode.AspectFramework/Synchronized.cs)]

## Overriding fields or properties

Overriding a field or a property means overriding its `get` and/or `set` semantic. From the point of view of overriding, fields are transformed into properties of the same name and accessibility.

Before applying the templates, the aspect framework transforms fields and automatic properties into field-backed properties.

> [!WARNING]
> When you override a field, it is no longer possible to reference the field using the `out`, `ref` or `in` keywords. Such cases are currently unsupported and will result in compilation errors. The workaround is to use an intermediate local variable.

There are two approaches to override a field or property: by providing a _property template_, or by providing one or more _accessor templates_.

### Overriding with a property template

This approach is the simplest but it has a few limitations.

Just like for methods, to override one or more fields or properties, your aspects needs to implement the <xref:Caravela.Framework.Aspects.IAspect%601.BuildAspect(Caravela.Framework.Aspects.IAspectBuilder{%600})> method, then call the <xref:Caravela.Framework.Aspects.IAdviceFactory.OverrideFieldOrProperty(Caravela.Framework.Code.IFieldOrProperty,System.String,Caravela.Framework.Aspects.AdviceOptions)> method exposed on `builder.AdviceFactory`.

The _first argument_ of `OverrideFieldOrProperty` is the @Caravela.Framework.Code.IFieldOrProperty that you want to override. This field or property must be in the type being targeted by the current aspect instance.

The _second argument_ of `OverrideFieldOrProperty` is the name of the template property. This property must exist in the aspect class and, additionally:

* the template property must be annotated with the `[Template]` attribute,
* the template property must be of type `dynamic?`.

The property can have a setter, a getter, or both. If one accessor is not specified, it will not be overridden.

#### Example: registry-backed class

The following aspects overrides properties so that they are written to and read from the Windows registry.

[!include[Registry Storage](../../../code/Caravela.Documentation.SampleCode.AspectFramework/RegistryStorage.cs)]

### Overriding with accessor templates

## Overriding events
