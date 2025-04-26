namespace Nuisho.Elifir.Test;

using static Syntax;
using static Utils;

[TestFixture]
public class IfThenTest_04
{
    [TestCase(2, ExpectedResult = 3, TestName = "Test_0400( 2 -> 3 )")]
    [TestCase(1, ExpectedResult = 4, TestName = "Test_0400( 1 -> 4 )")]
    public int Test_0400(int x)
    {
        var f =
             From_Λ_To_Λ_With(Add(1))              // 2 -> 3
            .If(Λ_Is(Even))
                .Then(From_Λ_To_Δ_With(Add(2)))    // 1 -> 4
            .End(WithReturn<A>);

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(2, ExpectedResult = 13, TestName = "Test_0401( 2 -> 13 )")]
    [TestCase(1, ExpectedResult = 34, TestName = "Test_0401( 1 -> 34 )")]
    public int Test_0401(int x)
    {
        var f =
             From_A_To_Λ_With(Add(1))
            .Then(From_Λ_To_Λ_With(Add(10)))       // 2 -> 13
            .If(Λ_Is(Even))
                .Then(From_Λ_To_B_With(Add(2)))
                .Then(From_B_To_Δ_With(Add(20)))   // 1 -> 34
            .End(WithReturn<A>);

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1, ExpectedResult = 112, TestName = "Test_0402( 1 -> 112 )")]
    [TestCase(2, ExpectedResult = 335, TestName = "Test_0402( 2 -> 335 )")]
    public int Test_0402(int x)
    {
        var f =
             From_D_To_B_With(Add(1))
            .Then(From_B_To_E_With(Add(10)))
            .Then(From_E_To_Λ_With(Add(100)))      // 1 -> 112
            .If(Λ_Is(Odd))
                .Then(From_Λ_To_B_With(Add(2)))
                .Then(From_B_To_E_With(Add(20)))
                .Then(From_E_To_Δ_With(Add(200)))  // 2 -> 335
            .End(WithReturn<A>);

        A result = f(new D(x));

        return result.Value;
    }

    [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0403( 2 -> 3 )")]
    [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0403( 1 -> 4 )")]
    [TestCase(999, ExpectedResult = 1005, TestName = "Test_0403( 999 -> 1005 )")]
    public int Test_0403(int x)
    {
        var f =
             From_A_To_Λ_With(Add(1))                  // 2 -> 3
            .If(Λ_Is(Even))
                .Then(From_Λ_To_ΛΛ_With(Add(2)))       // 1 -> 4
                .If(ΛΛ_Is(MoreThen(1000)))
                    .Then(From_ΛΛ_To_ΛΔ_With(Add(3)))  // 999 -> 1005
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 12,  TestName = "Test_0404( 1 -> 12 )")]
    [TestCase(2,  ExpectedResult = 35,  TestName = "Test_0404( 2 -> 35 )")]
    [TestCase(68, ExpectedResult = 142, TestName = "Test_0404( 68 -> 142 )")]
    public int Test_0404(int x)
    {
        var f =
             From_C_To_E_With(Add(1))
            .Then(From_E_To_Λ_With(Add(10)))           // 1 -> 12
            .If(Λ_Is(Odd))
                .Then(From_Λ_To_B_With(Add(2)))
                .Then(From_B_To_ΛΛ_With(Add(20)))      // 2 -> 35
                .If(ΛΛ_Is(MoreThen(100)))
                    .Then(From_ΛΛ_To_D_With(Add(20)))
                    .Then(From_D_To_ΛΔ_With(Add(21)))  // 68 -> 142
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        A result = f(new C(x));

        return result.Value;
    }

    [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0405( 2 -> 113 )")]
    [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0405( 1 -> 334 )")]
    [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0405( 1001 -> 1667 )")]
    public int Test_0405(int x)
    {
        var f =
             From_A_To_B_With(Add(1))
            .Then(From_B_To_D_With(Add(10)))
            .Then(From_D_To_Δ_With(Add(100)))          // 2 -> 113
            .If(Δ_Is(Even))
                .Then(From_Δ_To_C_With(Add(2)))
                .Then(From_C_To_E_With(Add(20)))
                .Then(From_E_To_ΔΔ_With(Add(200)))     // 1 -> 334
                .If(ΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔ_To_E_With(Add(3)))
                    .Then(From_E_To_B_With(Add(30)))
                    .Then(From_B_To_ΔΛ_With(Add(300))) // 1001 -> 1667
                .End(WithReturn<Δ>)
            .End(WithReturn<A>);

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 12,  TestName = "Test_0406( 1 -> 12 )")]
    [TestCase(2,  ExpectedResult = 35,  TestName = "Test_0406( 2 -> 35 )")]
    [TestCase(68, ExpectedResult = 142, TestName = "Test_0406( 68 -> 142 )")]
    public int Test_0406(int x)
    {
        var f =
             From_A_To_D_With(Add(1))
            .Then(From_D_To_ΔΛ_With(Add(10)))          // 1 -> 12
            .If(ΔΛ_Is(Odd))
                .Then(From_ΔΛ_To_D_With(Add(2)))
                .Then(From_D_To_ΔΔ_With(Add(20)))      // 2 -> 35
                .If(ΔΔ_Is(MoreThen(100)))
                    .Then(From_ΔΔ_To_A_With(Add(20)))
                    .Then(From_A_To_ΔΔ_With(Add(21)))  // 68 -> 142
                .End()
            .End(WithReturn<Δ>);

        Δ result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0407( 2 -> 113 )")]
    [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0407( 1 -> 334 )")]
    [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0407( 1001 -> 1667 )")]
    public int Test_0407(int x)
    {
        var f =
             From_B_To_E_With(Add(1))
            .Then(From_E_To_D_With(Add(10)))
            .Then(From_D_To_A_With(Add(100)))          // 2 -> 113
            .If(A_Is(Even))
                .Then(From_A_To_D_With(Add(2)))
                .Then(From_D_To_B_With(Add(20)))
                .Then(From_B_To_ΔΔ_With(Add(200)))     // 1 -> 334
                .If(ΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔ_To_B_With(Add(3)))
                    .Then(From_B_To_D_With(Add(30)))
                    .Then(From_D_To_ΔΛ_With(Add(300))) // 1001 -> 1667
                .End(WithReturn<Δ>)
            .End();

        A result = f(new B(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0408( 1 -> 2 )")]
    [TestCase(2,  ExpectedResult = 5,  TestName = "Test_0408( 2 -> 5 )")]
    [TestCase(10, ExpectedResult = 16, TestName = "Test_0408( 10 -> 16 )")]
    public int Test_0408(int x)
    {
        var f =
             From_A_To_Λ_With(Add(1))                  // 1 -> 2
            .If(Λ_Is(Odd))
                .Then(From_Λ_To_ΔΔ_With(Add(2)))       // 2 -> 5
                .If(ΔΔ_Is(MoreThen(10)))
                    .Then(From_ΔΔ_To_Δ_With(Add(3)))   // 10 -> 16
                .End()
            .End(WithReturn<A>);

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0409( 1 -> 2 )")]
    [TestCase(2,  ExpectedResult = 5,  TestName = "Test_0409( 2 -> 5 )")]
    [TestCase(10, ExpectedResult = 16, TestName = "Test_0409( 10 -> 16 )")]
    public int Test_0409(int x)
    {
        var f =
             From_A_To_Λ_With(Add(1))                  // 1 -> 2
            .If(Λ_Is(Odd))
                .Then(From_Λ_To_Δ_With(Add(2)))        // 2 -> 5
                .If(Δ_Is(MoreThen(10)))
                    .Then(From_Δ_To_ΔΔ_With(Add(3)))   // 10 -> 16
                .End()
            .End(WithReturn<A>);

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0410( 2 -> 3 )")]
    [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0410( 1 -> 4 )")]
    [TestCase(999, ExpectedResult = 1005, TestName = "Test_0410( 999 -> 1005 )")]
    public int Test_0410(int x)
    {
        var f =
             From_A_To_Δ_With(Add(1))                      // 2 -> 3
            .If(Δ_Is(Even))
                .Then(From_Δ_To_ΔΔ_With(Add(2)))           // 1 -> 4
                .If(ΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔ_To_ΔΛ_With(Add(3)))      // 999 -> 1005
                .End(WithReturn<A>)
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0411( 2 -> 113 )")]
    [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0411( 1 -> 334 )")]
    [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0411( 1001 -> 1667 )")]
    public int Test_0411(int x)
    {
        var f =
             From_B_To_E_With(Add(1))
            .Then(From_E_To_D_With(Add(10)))
            .Then(From_D_To_Δ_With(Add(100)))              // 2 -> 113
            .If(Δ_Is(Even))
                .Then(From_A_To_D_With(Add(2)))
                .Then(From_D_To_B_With(Add(20)))
                .Then(From_B_To_ΔΔ_With(Add(200)))         // 1 -> 334
                .If(ΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔ_To_B_With(Add(3)))
                    .Then(From_B_To_D_With(Add(30)))
                    .Then(From_D_To_ΔΛ_With(Add(300)))     // 1001 -> 1667
                .End(WithReturn<A>)
            .End();

        A result = f(new B(x));

        return result.Value;
    }

    [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0412( 2 -> 113 )")]
    [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0412( 1 -> 334 )")]
    [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0412( 1001 -> 1667 )")]
    public int Test_0412(int x)
    {
        var f =
             From_A_To_E_With(Add(1))
            .Then(From_E_To_D_With(Add(10)))
            .Then(From_D_To_Δ_With(Add(100)))              // 2 -> 113
            .If(Δ_Is(Even))
                .Then(From_Δ_To_E_With(Add(2)))
                .Then(From_E_To_B_With(Add(20)))
                .Then(From_B_To_ΔΔ_With(Add(200)))         // 1 -> 334
                .If(ΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔ_To_E_With(Add(3)))
                    .Then(From_E_To_B_With(Add(30)))
                    .Then(From_B_To_ΔΛ_With(Add(300)))     // 1001 -> 1667
                .End(WithReturn<Δ>)
            .End();

        Δ result = f(new A(x));

        return result.Value;
    }

    [TestCase(false, ExpectedResult = 5, TestName = "Test_0420( false, 3 -> 5 )")]
    [TestCase(true,  ExpectedResult = 7, TestName = "Test_0420( true, 2 -> 7 )")]
    public int Test_0420(bool isΛΛ)
    {
        var from_D_To_Λ_OrTo_ΛΛ_With =
            From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

        var f =
             from_D_To_Λ_OrTo_ΛΛ_With(Add(2))
            .If(Is<ΛΛ>)                             // (false, 3) -> 5
                .Then(From_ΛΛ_To_Δ_With(Add(2)))    // (true, 3) -> 7
            .End(WithReturn<A>);

        A result = f(new D(3));

        return result.Value;
    }

    [TestCase(false, ExpectedResult = 15, TestName = "Test_0421( false, 5 -> 15 )")]
    [TestCase(true,  ExpectedResult = 37, TestName = "Test_0421( true, 5 -> 37 )")]
    public int Test_0421(bool isΛΛ)
    {
        var from_D_To_Λ_OrTo_ΛΛ_With =
            From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

        var f =
             from_D_To_Λ_OrTo_ΛΛ_With(Add(10))
            .If(Is<ΛΛ>)                             // (false, 5) -> 15
                .Then(From_ΛΛ_To_B_With(Add(2)))
                .Then(From_B_To_Δ_With(Add(20)))    // (true, 5) -> 37
            .End(WithReturn<A>);

        A result = f(new D(5));

        return result.Value;
    }

    [TestCase(false, ExpectedResult = 105, TestName = "Test_0422( false, 5 -> 105 )")]
    [TestCase(true,  ExpectedResult = 327, TestName = "Test_0422( true, 5 -> 327 )")]
    public int Test_0422(bool isΛΛ)
    {
        var from_D_To_Λ_OrTo_ΛΛ_With =
            From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

        var f =
             from_D_To_Λ_OrTo_ΛΛ_With(Add(100))
            .If(Is<ΛΛ>)                             // (false, 5) -> 105
                .Then(From_Λ_To_B_With(Add(2)))
                .Then(From_B_To_E_With(Add(20)))
                .Then(From_E_To_Δ_With(Add(200)))   // (true, 5) -> 327
            .End(WithReturn<A>);

        A result = f(new D(5));

        return result.Value;
    }

    [TestCase(false, 3,    ExpectedResult = 9,    TestName = "Test_0423( false, 3 -> 9 )")]
    [TestCase(true,  3,    ExpectedResult = 11,   TestName = "Test_0423( true, 3 -> 11 )")]
    [TestCase(false, 3000, ExpectedResult = 3006, TestName = "Test_0423( false, 3000 -> 3006 )")]
    [TestCase(true,  3000, ExpectedResult = 3011, TestName = "Test_0423( true, 3000 -> 3011 )")]
    public int Test_0423(bool isΔΔ, int x)
    {
        var from_D_To_Δ_OrTo_ΔΔ_With =
            From_D_To_Δ_OrTo_ΔΔ(isΔΔ);

        var f =
             from_D_To_Δ_OrTo_ΔΔ_With(Add(6))           // (false, 3) -> 9
            .If(Is<ΔΔ>)                                 // (true, 3) -> 11
                .Then(From_ΔΔ_To_ΛΔ_With(Add(2)))       // (false, 3000) -> 3006
                .If(ΛΔ_Is(MoreThen(1000)))
                    .Then(From_ΛΔ_To_ΛΛ_With(Add(3)))   // (true, 3000) -> 3011
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        A result = f(new D(x));

        return result.Value;
    }

    [TestCase(2, false, ExpectedResult = 10, TestName = "Test_0424( 2, false -> 10 )")]
    [TestCase(2, true,  ExpectedResult = 10, TestName = "Test_0424( 2, true -> 10 )")]
    [TestCase(3, false, ExpectedResult = 33, TestName = "Test_0424( 3, false -> 33 )")]
    [TestCase(3, true,  ExpectedResult = 74, TestName = "Test_0424( 3, false -> 74 )")]
    public int Test_0424(int x, bool secondIsΛΛΛ)
    {
        var from_B_To_ΛΛ_OrTo_ΛΛΛ_With =
            From_B_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

        var f =
             From_E_To_B_With(Add(1))
            .Then(From_B_To_Δ_With(Add(7)))                 // (2, false) -> 10
            .If(Δ_Is(Odd))                                  // (2, true) -> 10
                .Then(From_Δ_To_B_With(Add(2)))
                .Then(from_B_To_ΛΛ_OrTo_ΛΛΛ_With(Add(20)))  // (3, false) -> 33
                .If(Is<ΛΛΛ>)
                    .Then(From_ΛΛΛ_To_D_With(Add(20)))
                    .Then(From_D_To_ΛΔ_With(Add(21)))       // (3, false) -> 74
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        A result = f(new E(x));

        return result.Value;
    }

    [TestCase(false, false, ExpectedResult = 136, TestName = "Test_0425( false, false, 25 -> 136 )")]
    [TestCase(false, true,  ExpectedResult = 136, TestName = "Test_0425( false, true, 25 -> 136 )")]
    [TestCase(true,  false, ExpectedResult = 358, TestName = "Test_0425( true, false, 25 -> 358 )")]
    [TestCase(true,  true,  ExpectedResult = 691, TestName = "Test_0425( true, true, 25 -> 691 )")]
    public int Test_0425(bool firstIsΔΔ, bool secondIsΛΛΛ)
    {
        var from_D_To_Δ_OrTo_ΔΔ_With =
            From_D_To_Δ_OrTo_ΔΔ(firstIsΔΔ);

        var from_E_To_ΛΛ_OrTo_ΛΛΛ_With =
            From_E_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

        var f =
             From_E_To_A_With(Add(1))
            .Then(From_A_To_D_With(Add(10)))
            .Then(from_D_To_Δ_OrTo_ΔΔ_With(Add(100)))           // (false, false, 25) -> 136
            .If(Is<ΔΔ>)                                         // (false, true, 25) -> 136
                .Then(From_ΔΔ_To_C_With(Add(2)))
                .Then(From_C_To_E_With(Add(20)))
                .Then(from_E_To_ΛΛ_OrTo_ΛΛΛ_With(Add(200)))     // (true, false, 25) -> 358
                .If(Is<ΛΛΛ>)
                    .Then(From_ΛΛΛ_To_E_With(Add(3)))
                    .Then(From_E_To_B_With(Add(30)))
                    .Then(From_B_To_ΛΔ_With(Add(300)))          // (true, false, 25) -> 691
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        A result = f(new E(25));

        return result.Value;
    }

    [TestCase(false, false, ExpectedResult = 113, TestName = "Test_0426( false, false, 3 -> 113 )")]
    [TestCase(false, true,  ExpectedResult = 113, TestName = "Test_0426( false, true, 3 -> 113 )")]
    [TestCase(true,  false, ExpectedResult = 135, TestName = "Test_0426( true, false, 3 -> 135 )")]
    [TestCase(true,  true,  ExpectedResult = 176, TestName = "Test_0426( true, true, 3 -> 176 )")]
    public int Test_0426(bool firstIsΔΔ, bool secondIsΛΛΛ)
    {
        var from_D_To_Δ_OrTo_ΔΔ_With =
            From_D_To_Δ_OrTo_ΔΔ(firstIsΔΔ);

        var from_D_To_ΛΛ_OrTo_ΛΛΛ_With =
            From_D_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

        var f =
             From_C_To_D_With(Add(10))
            .Then(from_D_To_Δ_OrTo_ΔΔ_With(Add(100)))       // (false, false, 3) -> 113
            .If(Is<ΔΔ>)                                     // (false, true, 3) -> 113
                .Then(From_ΔΔ_To_D_With(Add(2)))
                .Then(from_D_To_ΛΛ_OrTo_ΛΛΛ_With(Add(20)))  // (true, false, 3) -> 135
                .If(Is<ΛΛΛ>)
                    .Then(From_ΛΛΛ_To_A_With(Add(20)))
                    .Then(From_A_To_ΛΛΔ_With(Add(21)))      // (true, true, 3) -> 176
                .End()
            .End(WithReturn<A>);

        A result = f(new C(3));

        return result.Value;
    }

    [TestCase(false, 2,   ExpectedResult = 113,    TestName = "Test_0427( false, 2 -> 113 )")]
    [TestCase(true,  300, ExpectedResult = 633,  TestName = "Test_0427( true, 300 -> 633 )")]
    [TestCase(true,  800, ExpectedResult = 1466, TestName = "Test_0427( true, 800 -> 1466 )")]
    public int Test_0427(bool isAʹ, int x)
    {
        var from_A_To_A_Or_To_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
             From_C_To_E_With(Add(1))
            .Then(From_E_To_A_With(Add(10)))
            .Then(from_A_To_A_Or_To_Aʹ_With(Add(100)))
            .If(Is<Aʹ>)                                 // (false, 2) -> 113
                .Then(From_Aʹ_To_D_With(Add(2)))
                .Then(From_D_To_B_With(Add(20)))
                .Then(From_B_To_ΔΔ_With(Add(200)))      // (true, 300) -> 633
                .If(ΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔ_To_B_With(Add(3)))
                    .Then(From_B_To_D_With(Add(30)))
                    .Then(From_D_To_ΔΛ_With(Add(300)))  // (true, 800) -> 1466
                .End(WithReturn<Δ>)
            .End();

        A result = f(new C(x));

        return result.Value;
    }

    [TestCase(false, 2, ExpectedResult = 3,  TestName = "Test_0428( false, 2 -> 3 )")]
    [TestCase(true,  3, ExpectedResult = 6,  TestName = "Test_0428( true, 3 -> 6 )")]
    [TestCase(true,  9, ExpectedResult = 15, TestName = "Test_0428( true, 9 -> 15 )")]
    public int Test_0428(bool isΛΛ, int x)
    {
        var from_D_To_Λ_OrTo_ΛΛ_With =
            From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

        var f =
             from_D_To_Λ_OrTo_ΛΛ_With(Add(1))
            .If(Is<ΛΛ>)                                 // (false, 2) -> 3
                .Then(From_ΛΛ_To_ΔΔ_With(Add(2)))       // (true, 3) -> 6
                .If(ΔΔ_Is(MoreThen(10)))
                    .Then(From_ΔΔ_To_Δ_With(Add(3)))    // (true, 9) -> 15
                .End()
            .End(WithReturn<A>);

        A result = f(new D(x));

        return result.Value;
    }

    [TestCase(1, false, ExpectedResult = 2, TestName = "Test_0429( 1, false -> 2 )")]
    [TestCase(1, true,  ExpectedResult = 2, TestName = "Test_0429( 1, true -> 2 )")]
    [TestCase(2, false, ExpectedResult = 5, TestName = "Test_0429( 2, false -> 7 )")]
    [TestCase(2, true,  ExpectedResult = 8, TestName = "Test_0429( 2, true -> 8 )")]
    public int Test_0429(int x, bool isΔΔ)
    {
        var from_Λ_To_Δ_OrTo_ΔΔ_With =
            From_Λ_To_Δ_OrTo_ΔΔ(isΔΔ);

        var f =
             From_B_To_Λ_With(Add(1))                       // (2, false) -> 2
            .If(Λ_Is(Odd))                                  // (2, true) -> 2
                .Then(from_Λ_To_Δ_OrTo_ΔΔ_With(Add(2)))     // (2, false) -> 5
                .If(Is<ΔΔ>)
                    .Then(From_ΔΔ_To_ΔΔΔ_With(Add(3)))      // (2, true) -> 8
                .End()
            .End(WithReturn<A>);

        A result = f(new B(x));

        return result.Value;
    }

    [TestCase(2, false, ExpectedResult = 113, TestName = "Test_0430( 2, false -> 113 )")]
    [TestCase(2, true,  ExpectedResult = 113, TestName = "Test_0430( 2, true -> 113 )")]
    [TestCase(3, false, ExpectedResult = 336, TestName = "Test_0430( 2, false -> 336 )")]
    [TestCase(3, true,  ExpectedResult = 669, TestName = "Test_0430( 2, true -> 669 )")]
    public int Test_0430(int x, bool isΔΔ)
    {
        var from_Λ_To_ΔΔ_OrTo_ΔΔ_With =
            From_Λ_To_ΔΔ_OrTo_ΔΔΔ(isΔΔ);

        var f =
             From_D_To_E_With(Add(1))
            .Then(From_E_To_B_With(Add(10)))
            .Then(From_B_To_Δ_With(Add(100)))               // (2, false) -> 114
            .If(Δ_Is(Even))                                 // (2, true) -> 114
                .Then(From_A_To_D_With(Add(2)))
                .Then(From_D_To_Λ_With(Add(20)))
                .Then(from_Λ_To_ΔΔ_OrTo_ΔΔ_With(Add(200)))  // (3, false) -> 336
                .If(Is<ΔΔΔ>)
                    .Then(From_ΔΔΔ_To_B_With(Add(3)))
                    .Then(From_B_To_D_With(Add(30)))
                    .Then(From_D_To_ΔΛ_With(Add(300)))      // (3, true) -> 669
                .End(WithReturn<A>)
            .End();

        A result = f(new D(x));

        return result.Value;
    }
}
