---
uid: Caravela.Framework.Aspects
summary: *content
---

This is namespace allows you to build aspects. Aspects are an algorithmic representation of a code transformation or validation.

For instance, adding logging to a method, or implementing `INotifyPropertyChanged`, can to a great extent be expressed as
an algorithm and therefore implemented as an aspect.

To create an aspect, create a class that derives from @"System.Attribute" and implement the 
@"Caravela.Framework.Aspects.IAspect`1" interface.

For more information, see <xref:aspects>.

### Class Diagrams

#### Aspect builders

```mermaid
classDiagram
    
    class IAspect {
        BuildAspectClass(IAspectClassBuilder)
        BuildAspect(IAspectBuilder)
    }

    class IAspectBuilder {
        SkipAspect()
        TargetDeclaration
        AdviceFactory
    }

    class IAspectClassBuilder {
        DisplayName
        Description
        Layers
    }

    class IAspectDependencyBuilder {
        RequireAspect()
    }

    class IAdviceFactory {
        OverrideMethod(...)
        IntroduceMethod(...)
        OverrideFieldOrProperty(...)
        IntroduceFieldOrProperty(...)
    }

    class IDiagnosticSink {
        Report(...)
        Suppress(...)
    }

    IAspect --> IAspectBuilder : BuildAspect() receives
    IAspect --> IAspectClassBuilder : BuildAspectClass() receives
    IAspectBuilder --> IAdviceFactory : exposes
    IAspectBuilder --> IDiagnosticSink : exposes
    IAspectClassBuilder --> IAspectDependencyBuilder : exposes

```

#### Scope custom attributes

```mermaid
classDiagram

CompileTimeOnlyAttribute <|-- ScopeAttribute
CompileTimeAttribute <|-- ScopeAttribute
RunTimeOnlyAttribute <|-- ScopeAttribute
TemplateAttribute <|-- CompileTimeOnlyAttribute
AdviceAttribute <|-- TemplateAttribute
IntroduceAttribute <|-- AdviceAttribute
InterfaceMemberAttribute <|-- TemplateAttribute

class CompileTimeAttribute
class RunTimeOnlyAttribute

```