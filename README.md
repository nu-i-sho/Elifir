# Elifir

Elifir is a small library for constructing `T -> Tʹ` functions using If-Then-Else expressions provided by its methods. 
It was implemented to have hands-on experience in using edge cases abilities of the C# type system.

API of Elifir based on method-by-method calling (left image) with no need to use nesting (right).

![nesting and in line comparison](https://raw.githubusercontent.com/nu-i-sho/Elifir/refs/heads/main/readme_img/001.svg)

This point was the main challenge of Elifir's realization because it required implementing a "family of types" that controlled the type state at each point of expression. 
(For example, if you called 5 `If`s, you should close 5 `End`s, no more, and in relevant places. And the compiler controls this.) 
Also, the library provides some custom "covariance" that helps to avoid a list of type conflicts. 
