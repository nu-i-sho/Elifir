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

There are two ways to close an expression by `End` with the auto inference of return type and one with the manual.
The following image shows them.

![if-then end options](https://raw.githubusercontent.com/nu-i-sho/Elifir/refs/heads/main/readme_img/002.svg)

We can achieve this using one of the overloads of the `End` method without any additional parameters**ˣ**, as shown in *(a)*, under the following conditions:
  * *(1)* `Tʹ` is a subtype of `T`, or `Tʹ` and `T` are the same type. In this case, the resulting function has the type `T -> T`.
  * *(2)* `T` is a subtype of `Tʹ`. In this scenario, the resulting function has the type `T -> Tʹ`.

This concept is straightforward. Expression should return an original value of the original type `T` when the `If` condition is false. 
Otherwise, it should return the transformed value with a resulting type `Tʹ`, which is the return type of the last function in the `Then` chain.
To unify these two values, which have different types, into a single type, one of them must be a subtype of the other (or, naturally, they can be the same).

Additionally, there is another case where two types can be unified:
  * *(3)* When there exists a type `B` that serves as the base type for both `T` and `Tʹ`. In this case, the resulting function type is `T -> B`.

However, it is not possible to infer type `B` automatically, as it is not guaranteed to be unique, accordingly C# can't provide mechanisms to handle this scenario. 
Therefore, the type `B` must be explicitly specified using the `WithReturn<B>` argument, as illustrated in example *(b)*.

</br>

**ˣ** *"`End` method without any additional parameters" means that there is no need to pass any explicit parameters for execution.
Technically, these methods can have at least one 'this parameter' since they can be implemented as extensions. 
Additionally, default parameters are possible. The following code snippet demonstrates the signatures of two methods with the same name, 
where the second method includes an additional 'default parameter' to work around C#'s method overloading limitations (and it functions correctly).*

```CSharp
public static Func<I, I> End<I, T>(
    this ˣ.If<I>.Then<T> o)
        where T : I
            { ... }

public static Func<I, T> End<I, T>(
    this ˣ.If<I>.Then<T> o,
    AdHocPolyMarker? _ = null)
        where I : T
            { ... }
```

 
 
     
   
