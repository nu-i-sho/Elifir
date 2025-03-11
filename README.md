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

## If Then Else Then End

A similar situation arises with the additional `Else` branch. 
However, in this case, there are three key types involved: `T` (the input parameter type), `Tʹ` (the result type of the `If` branch), and `E` (the result type of the `Else` branch). 
Thus, unification is required between `Tʹ` and `E` rather than between `T` and `Tʹ`.

The following image illustrates this concept clearly and does not require further explanation.

![if-then-else end options](https://raw.githubusercontent.com/nu-i-sho/Elifir/refs/heads/main/readme_img/003.svg)

## Induction

Within any part of the expression, an `If` can be added to create a sub-expression. 
Each sub-expression must be closed with `End`, adhering to the same rules outlined earlier for the top-level expression. 
Every `If` must have a corresponding `End`, and all types within the expression must be harmonized to build the resulting function.

The following image illustrates the process of expression folding.

![expression folding](https://raw.githubusercontent.com/nu-i-sho/Elifir/refs/heads/main/readme_img/004.svg)

## Type Condition

In addition to conventional conditions, Elifir provides sub-typing conditions.
That means we can check the type of object in the `If` and delegate it to a sub-expression cast to this type (while keeping the original type for the `Else` branch).
For example:

```CSharp
class A { ... }
class B : A { ... }
class C { ... }

Func<A, C> convert_A_To_C = ...
Func<B, C> convert_B_To_C = ...

var f =
    If(Object<A>.Is<B>)
      .Then(convert_B_To_C)
   .Else()
      .Then(convert_A_To_C)
   .End();
```

## AndIf

Also, it is possible to combine conditions with the `AndIf` method.
It works for both conventional and type conditions.

```CSharp

var f =
    If(Object<A>.Is<B>).AndIf(B_Is_Something)
      .Then(convert_B_To_C)
      .If(C_Is_Something).AndIf(Object<C>.Is<D>)
                         .AndIf(D_Is_Somthing)
                         .AndIf(Object<D>.Is<E>)
         .Then(convert_E_To_C)
      .End()
   .Else()
      .Then(convert_A_To_C)
   .End();

```

## P.S.: Limitations

### Static Polymorphism
Elifir is implemented using static polymorphism rather than dynamic polymorphism. 
As a result, every modification of a non-finalized expression generates a new type that is incompatible with the previous one. 
Providing this behavior was the main challenge in designing the library, and it is pretty cool, but it produces some conses. 
You can use Elifir to construct functions, but it is not recommended to use any types provided by the library directly. 
For this reason, the names of Elifir types include the symbol "ˣ," which is absent on the keyboard.

We can see Elifir types specific in the following code snippet.

```CSharp
                                 Func<A, B> _0 = 
convert_A_To_B;                  ˣ<Func<A, B>, ˣ.If<B>> _1 = _0
.If(B_Is_Something);             ˣ<Func<A, B>, ˣ.If<B>.Then<C>> _2 = _1
    .Then(convert_B_To_C);       ˣ<Func<A, B>, ˣ.If<B>.Then<D>> _3 = _2
    .Then(convert_C_To_D);       ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Is<E>> _4 = _3
    .If(Object<D>.Is<E>);        ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Then<B>> _5 = _4
       .Then(convert_E_To_B);    ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Then<B>.Else> _6 = _5
    .Else();                     ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Then<B>.Else.Then<B>> _7 = _6
       .Then(convert_D_To_B);    ˣ<ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Then<B>.Else.Then<B>>, ˣ.If<B>> _8 = _7
       .If(B_Is_Something);      ˣ<ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Then<B>.Else.Then<B>>, ˣ.If<B>.Then<B>> _9 = _8
          .Then(convert_B_To_B); ˣ<ˣ<Func<A, B>, ˣ.If<B>.Then<D>>, ˣ.If<D>.Then<B>.Else.Then<B>> _10 = _9
       .End();                   ˣ<Func<A, B>, ˣ.If<B>.Then<B>> _11 = _10
    .End();                      Func<A, B> _12 = _11
.End();

```

### Generics
Each Elifir `If` in expression increases the generic type level of nesting. 
I am aware that the maximum nesting depth for generic types in C# is limited. 
Based on forum discussions, this limit is estimated to be around 1000, but no precise documentation with the exact number exists. 
To investigate further, I conducted some tests.

The first issue I encountered was that IntelliSense crashed Visual Studio. 
To work around this, I continued writing nested `If` statements in Notepad and only compiled the code in Visual Studio without opening the file. 
The next barrier was the error: *"CS8078: An expression is too long or complex to compile."*.
I resolved this by splitting the expression into portions concated through variables, allowing me to extend the testing expression to ten times its original length.

I expected some error that the type was out of the maximum nesting depth of the generic type.

Nothing like that happens, but StackOverflowException during compilation instead.
Also, I found out that when the expression has a compilation error (for example, extra `End`), it is enough to have a much smaller expression to have SO Exception.
It looks like it was caused during error message building.
This investigation summarizes the limitation of nesting in the generic type is about 1000, and still, there is no exact number.
But it is impossible to have comfortable work when it is 100 because of the long compilation time and VS slowing down as IDE. 

### Performance 
The function built by Elifir with 10 nested `If`-s is two times slower than the function implemented with native `if`-s. 
It is like nothing. 
 
 
     
   
