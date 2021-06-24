---
uid: sharing-state-with-advices
---

# Sharing State with Advices

If you need to share _compile-time_ state between advices, or between advices and your implementation of the `BuildAspect` method, a few strategies are available to you.

> [!NOTE]
> If you need to share _run-time_ state between advices, you have to choose another strategy, for instance introducing a field in the target type and using it from several advices.

## Sharing state with an aspect field

A simple way to share state between different aspect methods (both templates or regular compile-time methods) is to simply use a field of the aspect class. You can for instance initialize the field in your implementation of the `BuildAspect` method and use it from template methods.

The inconvenience of this method is that it is not very flexible. You cannot pass state that is specific to an advice.

## Sharing state with the Tags property

If your `BuildAspect` method needs to pass to a template method some state that is specific to an advice instance, you can construct an instance of the @Caravela.Framework.Aspects.AdviceOptions class and assign all elements of state as tags_ in name-value dictionary. In the template method, the tags are available under the `meta.Tags` dictionary.

### Example

[!include[Tags](../../../code/Caravela.Documentation.SampleCode.AspectFramework/Tags.cs)]