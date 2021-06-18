---
uid: Caravela.Framework.Diagnostics
summary: *content
---
This is namespace allows you to report or suppress diagnostics from your aspect code.

To report a diagnostic, you must first define a static field of type @"Caravela.Framework.Diagnostics.DiagnosticDefinition" or 
@"Caravela.Framework.Diagnostics.DiagnosticDefinition`1" in your aspect class. Note that this step is mandatory.

You can then use report a diagnostic from your implementation of @"Caravela.Framework.Aspects.IAspect`1.BuildAspect(Caravela.Framework.Aspects.IAspectBuilder{`0})"
by calling the @"Caravela.Framework.Diagnostics.IDiagnosticSink.Report(Caravela.Framework.Diagnostics.IDiagnosticLocation,Caravela.Framework.Diagnostics.DiagnosticDefinition,System.Object[])" method 
exposed on the consuming @"Caravela.Framework.Aspects.IAspectLayerBuilder.Diagnostics" property of @"Caravela.Framework.Aspects.IAspectBuilder".

You can also report a diagnostic from a template using the @"Caravela.Framework.Aspects.meta.Diagnostics" property of the `meta` API.

To suppress of diagnostic, you must first define it as a static field of type @"Caravela.Framework.Diagnostics.SuppressionDefinition" in your aspect class.
You can then suppress a diagnostic from any declaration from an aspect using the 
@"Caravela.Framework.Diagnostics.IDiagnosticSink.Suppress(Caravela.Framework.Code.IDeclaration,Caravela.Framework.Diagnostics.SuppressionDefinition)"
method.
