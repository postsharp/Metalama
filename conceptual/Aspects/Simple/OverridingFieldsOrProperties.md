---
uid: overriding-fields-or-properties
---
# Overriding Fields or Properties

## Example: Resolving dependencies on the fly

The following example is a simplified implementation of the service locator pattern.

The `Import` aspect overrides the getter of a property to make a call to a global service locator. The dependency is not stored, so the service locator must be called every time the property is evaluated.

[!include[Import Service](../../../code/Caravela.Documentation.SampleCode.AspectFramework/GlobalImport.cs)]


## Example: Resolving dependencies on the fly and storing the result

This example builds over the previous one and

[!include[Import Service](../../../code/Caravela.Documentation.SampleCode.AspectFramework/GlobalImportWithSetter.cs)]