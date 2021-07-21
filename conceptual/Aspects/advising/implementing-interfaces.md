---
uid: implementing-interfaces
---
# Implementing Interfaces

Many aspects need modify the target type so it implements a new interface. This can be done only using the programmatic advising API.

## Step 1. Call IAdviceFactory.ImplementInterface

In your implementation of the <xref:Caravela.Framework.Aspects.IAspect%601.BuildAspect(Caravela.Framework.Aspects.IAspectBuilder{%600})> method, call the <xref:Caravela.Framework.Aspects.IAdviceFactory.ImplementInterface(Caravela.Framework.Code.INamedType,System.Type,Caravela.Framework.Aspects.OverrideStrategy,System.Collections.Generic.Dictionary{System.String,System.Object})> method.

## Step 2. Add interface members to the aspect class

Add all interface members to the aspect class and mark them with the <xref:Caravela.Framework.Aspects.InterfaceMemberAttribute?text=[InterfaceMember]> custom attribute. There is no need to have the aspect class implement the introduced interface.

The following rules apply to interface members:

- The name and signature of all interface members must exactly match.
- The accessibility of introduced members have no importance.
- The aspect framework will generate public members unless the <xref:Caravela.Framework.Aspects.InterfaceMemberAttribute.IsExplicit> property is set to `true`. In this case, an explicit implementation is generated.

Implementing an interface in a complete dynamic manner, when the interface itself is not know by the aspect, is not yet supported.

## Example: deep cloning

[!include[Deep Clone](../../../code/Caravela.Documentation.SampleCode.AspectFramework/DeepClone.cs)]


## Referencing interface members in other templates

When you introduce an interface member to a type, your will often want to access it from templates. Unless the member is an explicit implementations, you have two options:

(TODO: better code examples)


### Option 1. Access the aspect template member

```cs
this.Dispose();
```


### Option 2. Use `meta.This` and write dynamic code

```cs
meta.This.Dispose();
```

### Accessing explicit implementations

The following strategies are possible:

- cast the instance to the interface and access the member, e.g.

    ```cs
    ((IDisposable)meta.This).Dispose();
    ```

- introduce a private method with the real method implementation, and call this private member both from the interface member and from other templates.