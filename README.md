# Elifir

Elifir is a small library for constructing `T -> Tʹ` functions using If-Then-Else expressions provided by its methods. 
It was implemented to have hands-on experience in using edge cases abilities of the C# type system.

API of Elifir based on method-by-method calling (left image) with no need to use nesting (right).

![nesting and in line comparison](https://raw.githubusercontent.com/nu-i-sho/Elifir/refs/heads/main/readme_img/001.svg)

This aspect was the main challenge of Elifir's realization because it required implementing a "family of types" that controlled the type state at each point of expression. 
(For example, if you called 5 `If`s, you should close 5 `End`s, no more, and in relevant places. And the compiler controls this.) 
Also, the library provides some custom "covariance" that helps to avoid a list of type conflicts. 

## Usings
The inclusion of the following directives is required to use the library.

```CSharp
using Nuisho.Elifir;
using static Nuisho.Elifir.Syntax;
```

## Then
The simplest functional item of Elifir is the `Then` method, which essentially is functional composition.

```CSharp
Func<char, double> fromCharToDouble = ...
Func<double, string> fromDoubleToString = ...
Func<string, int> fromStringToInt = ...

Func<char, int> fromCharToInt =
     fromCharToDouble
        .Then(fromDoubleToString)
        .Then(fromStringToInt);
```
## If Then End
The simplest form of a conditional expression is `If`-`Then`-`End`.
It begins with `If`, which takes a predicate as its argument.
And it completes with `End`, which can be invoked only on an expression state where the types are appropriately matched.
Any number (≥ 0) of `Then` calls can be included between these `If` and `End`. 

```CSharp

Func<int, bool> IsEven = x => x % 2 == 0;

Func<int, int> f = ...
Func<int, int> g = ...
Func<int, int> h = ...

Func<int, int> p = If(IsEvent).Then(f).Then(g).Then(h).End();
```
The function `p` from the code snippet above returns the original value for odd arguments and the result of `Then`'s functions applying to even arguments (`h(g(f(x)))`).

