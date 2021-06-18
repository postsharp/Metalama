---
uid: testing
---

# Testing aspects

There are two complementary ways to test your aspects: 

| Article | Description |
|--|--|
| @"run-time-testing" | **Run-time tests** are tests that verify the run-time behavior of the aspect. With this approach, you apply your aspect to some test target code and to test the _behavior_ of the combination of the aspect and the target code, by executing the transformed code in a unit test and evaluating assertions regarding its run-time behavior. For this approach, you can use a conventional Xunit project, or use any other testing framework, because there is nothing specific to Caravela here. |
| @"compile-time-testing" | **Compile-time tests**, by contrast, verify that the aspect transforms some target code as expected, or emits errors and warnings as expected. With compile-time tests, the transformed code is not executed. |

