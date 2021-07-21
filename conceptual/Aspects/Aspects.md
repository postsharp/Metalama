---
uid: aspects
---

# Creating Aspects

This chapter explains how to build your own aspects. If you only want to learn how to use aspects written by others, you can skip this chapter in first reading. However, we suggest you to come back here if you want to understand better the "magic" behind Caravela.

This chapter is structured as follows: first we give a few tricks to get started quickly with a smooth learning curve. Then we introduce you to the theory and design of the aspect framework, so you can leverage its complete power. We suggest you don't stop at the simplified _getting started_ API even if you quickly solve your problem at-hand because you may be able to find a better solution with a deeper understanding of the framework.

| Section                       | Description                                                                                                                                            |
| ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| @simple-aspects               | This section explains how to create simple aspects with a familiar object-oriented API and without much theory.                                        |
| @aspect-framework-design      | This article gives the theory behind the Caravela aspect framework.                                                                                    |
| @templates                    | This article explains how to create dynamic code templates.                                                                                            |
| @diagnostics                  | This article explains how to report or suppress errors, warnings and information messages.                                                             |
| @advising-code                | This section explains how to create aspects that perform advanced code modifications using the complete API.                                           |
| <xref:ordering-aspects>       | This article describes how to order aspect classes so that the order of execution is correct when several aspects are applied to the same declaration. |
| @testing                      | This section explains how to test aspects.                                                                                                             |
| @debugging-aspects            | This article explains how to debug aspects.                                                                                                            |
| <xref:creating-live-template> | This article explains how to create a live templates, which modifies the source code in the editor.                                                    |