---
uid: implementing-interfaces
---
# Implementing Interfaces

Many aspects need modify the target type so it implements a new interface. This can be done only using the programmatic advising API.

1. In your implementation of the <xref:Caravela.Framework.Aspects.IAspect%601.BuildAspect(Caravela.Framework.Aspects.IAspectBuilder{%600})> method, call the <xref:Caravela.Framework.Aspects.IAdviceFactory.ImplementInterface(Caravela.Framework.Code.INamedType,System.Type,Caravela.Framework.Aspects.ConflictBehavior,Caravela.Framework.Aspects.AdviceOptions)> method.
   
2. Add all interface members to the aspect class and mark them with the <xref:Caravela.Framework.Aspects.InterfaceMemberAttribute?text=[InterfaceMember]> custom attribute. There is no need to have the aspect class implement the introduced interface.

    - The name and signature of all interface members must exactly match.
    - The accessibility of introduced members have no importance.
    - The aspect framework will generate public members unless the <xref:Caravela.Framework.Aspects.InterfaceMemberAttribute.IsExplicit> property is set to `true`. In this case, an explicit implementation is generated.


Implementing an interface in a complete dynamic manner, when the interface itself is not know by the aspect, is not yet supported.

  

## Example: deep cloning

[!include[Deep Clone](../../../code/Caravela.Documentation.SampleCode.AspectFramework/DeepClone.cs)]