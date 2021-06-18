---
uid: ordering-aspects
---

# Ordering Aspects

When there are several aspect classes in the project, their order of execution is significant.

## Concepts

### Per-project ordering

In Caravela, the order of execution is _static_. It is principally a concern of the aspect library author, not one of the user of the aspect library.

Each aspect library should define the order of execution of the aspect it defines, not only with regards to other aspects of the same library, but also to the aspects defined in the referenced aspect libraries.

When a project uses two unrelated aspect libraries, or when a project defines its own aspects, it has to define the ordering in the project itself.

### Order of application versus order of execution

Caravela follows what we call the "matryoshka" model: your source code is the innermost dull, and aspects are added _around_ it. The fully compiled code, with all aspects, is like the fully assembled matryoshka. Executing a method is like disassembling the matryoshka: you start with the outermost shell, and you continue to the original implementation.

<img src="https://upload.wikimedia.org/wikipedia/commons/4/40/Matryoshka_transparent.png" width="480px" style="padding: 40px" title="CC BY-SA 3.0 by Wikipedia user Fanghong.">

It is important to remember that Caravela builds the matryoshka from the inside to the outside, but the code is executed is from the outside to the inside, i.e. the source code is executed _last_.

Therefore, the aspect application order and the aspect execution order are _opposite_.

## Specifying the execution order

Aspects must be ordered using the <xref:Caravela.Framework.Aspects.AspectOrderAttribute> assembly-level custom attribute. The order in which the aspect classes in the constructor correspond to their order of _execution_.

```cs
using Caravela.Framework.Aspects;
[assembly: AspectOrder( typeof(Aspect1), typeof(Aspect2), typeof(Aspect3))]
```

You can specify _partial_ order relationships. The aspect framework will merge all partial relationships and determine the global order for the current project. 

For instance, the following code snippet is equivalent to the previous one:

```cs
using Caravela.Framework.Aspects;
[assembly: AspectOrder( typeof(Aspect1), typeof(Aspect2))]
[assembly: AspectOrder( typeof(Aspect2), typeof(Aspect3))]
```

This is like in mathematics: if we have `a < b` and `b < c`, then we have `a < c` and the ordered sequence is `{a, b, c}`. 

If you specify conflicting relationships, or import aspect library that define conflicting ordering, Caravela will emit a compilation error.

## Example

The following code snippet shows two aspects that both add a method to the target type and display the list of methods that were defined on the target type before the aspect was applied. The order of execution is defined as `Aspect1 < Aspect2`. You can see from this example that the order of application of aspects is opposite. `Aspect2` is applied first and sees the source code, then `Aspect1` is applied and sees the method added by `Aspect1`. The modified method body of `SourceMethod` shows that the aspects are executed in this order: `Aspect1`, `Aspect2`, then the original method.

[!include[Ordering](../../code/Caravela.Documentation.SampleCode.OverrideMethod/Ordering.cs?sample)]

