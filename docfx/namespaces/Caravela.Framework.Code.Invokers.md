---
uid: Caravela.Framework.Code.Invokers
summary: *content
---
This namespace defines invokers, which are objects that generates syntax that invokes methods or accesses properties, fields or events.

Where it makes sense, declarations expose an invoker factory (@"Caravela.Framework.Code.Invokers.IInvokerFactory`1") on their `Invokers` property. 
The invoker factory interface has two properties:

-  @"Caravela.Framework.Code.Invokers.IInvokerFactory`1.Final" is equivalent to the `this` keyword in C#. It allows you to access the last override
   of the semantic.

-  @"Caravela.Framework.Code.Invokers.IInvokerFactory`1.Base" is equivalent to the `base` keyword in C#. It allows you to access the implementation
   prior to the current aspect layer.


## Class Diagram

```mermaid
classDiagram

class IInvokerFactory~T~ {
   T? Base
   T Final
}

IInvokerFactory~T~ --> IInvoker: exposes

IMethod --> IInvokerFactory~IMethodInvoker~: exposes
IEvent --> IInvokerFactory~IEventInvoker~: exposes
IFieldOrProperty --> IInvokerFactory~IFieldOrPropertyInvoker~: exposes

IMethodInvoker <|-- IInvoker
IFieldOrPropertyInvoker <|-- IInvoker
IPropertyInvoker <|-- IFieldOrPropertyInvoker
IEventInvoker <|-- IInvoker

class IMethod {
   Invokers
}

class IEvent {
   Invokers
}

class IFieldOrProperty {
   Invokers
}



class IMethodInvoker {
 +Invoke()
}

class IFieldOrPropertyInvoker {
   +GetValue()
   +SetValue()
}

class IPropertyInvoker {
   +GetIndexerValue()
   +SetIndexerValue()
}

class IEventInvoker {
   +AddDelegate()
   +RemoveDelegate()
}

```