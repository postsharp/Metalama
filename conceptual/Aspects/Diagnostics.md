---
uid: diagnostics
---
# Reporting and suppressing diagnostics

This article explains how to report a diagnostic (error, warning or information message) from an aspect, or to _suppress_ a diagnostic reported by the C# compiler or another aspect.

## Reporting a diagnostic

TODO: When to report a diagnostic? Eligibility vs diagnostic.

To report a diagnostic:

1. Import the <xref:Caravela.Framework.Diagnostics> namespace.

2. Define a `static` field of type <xref:Caravela.Framework.Diagnostics.DiagnosticDefinition> in your aspect class. <xref:Caravela.Framework.Diagnostics.DiagnosticDefinition> specifies the diagnostic id, the severity, and the error formatting string.

    - For a message without formatting parameters or with weakly-typed formatting parameters, use the non-generic <xref:Caravela.Framework.Diagnostics.DiagnosticDefinition> class.
    - For a message with a single strongly-typed formatting parameter, use the generic <xref:Caravela.Framework.Diagnostics.DiagnosticDefinition%601> class, e.g. `DiagnosticDefinition<int>`.
    - For a message with several strongly-types formatting parameters, use the generic <xref:Caravela.Framework.Diagnostics.DiagnosticDefinition%601> with a tuple, e.g. `DiagnosticDefinition<(int,string)>` for a message with two formatting parameters expecting a value of type `int` and `string`.

    > [!WARNING]
    > The aspect framework relies on the fact that diagnostics are defined as static fields of aspect classes. You will not be able to report a diagnostic that has not been declared on an aspect class of the current project.

3. To report a diagnostic, use the <xref:Caravela.Framework.Diagnostics.IDiagnosticSink.Report(Caravela.Framework.Diagnostics.IDiagnosticLocation,Caravela.Framework.Diagnostics.DiagnosticDefinition,System.Object[])> method of the <xref:Caravela.Framework.Diagnostics.IDiagnosticSink> interface.
 
    - from your implementation of the <xref:Caravela.Framework.Aspects.IAspect%601.BuildAspect(Caravela.Framework.Aspects.IAspectBuilder{%600})> method, use `builder.Diagnostics.Report`.
    - from a template, use `meta.Diagnostics.Report`.

    The first parameter of the `Report` method is optional: it specifies the declaration to which the diagnostic relates. The aspect framework computes the file, line and column of the diagnostic based on this declaration. If you don't give a value for this parameter, the diagnostic will be reported for the target declaration of the aspect.


## Suppressing a diagnostic

Sometimes the C# compiler or other analyzers may report warnings to the target code of your aspects. Since neither the C# compiler nor the analyzers know about your aspect, some of these warnings may be irrelevant. As an aspect author, it is a good practice to prevent the report of irrelevant warnings.

To suppress a diagnostic:

1. Import the <xref:Caravela.Framework.Diagnostics> namespace.

2. Define a `static` field of type <xref:Caravela.Framework.Diagnostics.SuppressionDefinition> in your aspect class. <xref:Caravela.Framework.Diagnostics.SuppressionDefinition> specifies the identifier of the diagnostic id to suppress.

3. Call the <xref:Caravela.Framework.Diagnostics.IDiagnosticSink.Suppress(Caravela.Framework.Code.IDeclaration,Caravela.Framework.Diagnostics.SuppressionDefinition)> method using `builder.Diagnostics.Suppress(...)` in the `BuildAspect` method or `meta.Diagnostics.Suppress(...)` in a template method.

## Example

The following aspect can be added to a field or property. It overrides the getter so that its value is retrieved from a service locator. This aspect assumes that the target class has a field named `_serviceProvider` and of type `IServiceProvider`. The aspect reports errors if this field is absent or of a wrong type. The C# compiler may report an error `CS0169` because it looks from source code that the `_serviceProvider` field is unused. Therefore, the aspect must suppress this diagnostic.

[!include[Import Service](../../code/Caravela.Documentation.SampleCode.AspectFramework/ImportService.cs)]
