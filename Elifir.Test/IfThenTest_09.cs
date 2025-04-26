namespace Nuisho.Elifir.Test;

using static Syntax;
using static Utils;

[TestFixture]
public class IfThenTest_09
{
    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_0900( 1 -> 1 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_0900( 2 -> 2 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_0900( 12 -> 14 )")]
    public int Test_0900(int x)
    {
        var f =
             If(Λ_Is(Even)).AndIf(Λ_Is(MoreThen(10)))   // 1 -> 1, 2 -> 2
                .Then(From_Λ_To_Δ_With(Add(2)))         // 12 -> 14
            .End(WithReturn<A>);

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5, false, ExpectedResult = 5,  TestName = "Test_0901( 5, false -> 5 )")]
    [TestCase(5, true,  ExpectedResult = 5,  TestName = "Test_0901( 5, true -> 5 )")]
    [TestCase(4, false, ExpectedResult = 4,  TestName = "Test_0901( 4, false -> 4 )")]
    [TestCase(4, true,  ExpectedResult = 26, TestName = "Test_0901( 4, true -> 26 )")]
    public int Test_0901(int x, bool isΛΛ)
    {
        var f =                                     // (5, false) -> 5, (5, true) -> 5
             If(Λ_Is(Even)).AndIf(Is<ΛΛ>)           // (4, false) -> 4
                .Then(From_ΛΛ_To_B_With(Add(2)))
                .Then(From_B_To_Δ_With(Add(20)))    // (4, true) -> 26
            .End(WithReturn<A>);

        Λ arg = isΛΛ
            ? new ΛΛ(x)
            : new Λ(x);

        A result = f(arg);

        return result.Value;
    }

    [TestCase(8, false, ExpectedResult = 8,   TestName = "Test_0902( 8, false -> 8 )")]
    [TestCase(7, false, ExpectedResult = 7,   TestName = "Test_0902( 7, false -> 7 )")]
    [TestCase(8, true,  ExpectedResult = 8,   TestName = "Test_0902( 8, true -> 8 )")]
    [TestCase(7, true,  ExpectedResult = 229, TestName = "Test_0902( 7, true -> 229 )")]
    public int Test_0902(int x, bool isΛΛ)
    {
        var f =
              If(Object<Λ>.Is<ΛΛ>)                  // (8, false) -> 8, (7, false) -> 7
             .AndIf(Λ_Is(Odd))                      // (8, true) -> 8,
                .Then(From_ΛΛ_To_B_With(Add(2)))
                .Then(From_B_To_E_With(Add(20)))
                .Then(From_E_To_Δ_With(Add(200)))   // (7, true) -> 229
            .End(WithReturn<A>);

        Λ arg = isΛΛ
            ? new ΛΛ(x)
            : new Λ(x);

        A result = f(arg);

        return result.Value;
    }

    [TestCase("Λ",   5,   ExpectedResult = 5,    TestName = "Test_0903( Λ, 5 -> 5 )")]
    [TestCase("ΛΛ",  5,   ExpectedResult = 5,    TestName = "Test_0903( ΛΛ, 5 -> 5 )")]
    [TestCase("ΛΔ",  5,   ExpectedResult = 5,    TestName = "Test_0903( ΛΔ, 5 -> 5 )")]
    [TestCase("ΛΛΛ", 5,   ExpectedResult = 7,    TestName = "Test_0903( ΛΛΛ, 5 -> 7 )")]
    [TestCase("ΛΛΛ", 999, ExpectedResult = 1004, TestName = "Test_0903( ΛΛΛ, 999 -> 1004 )")]
    public int Test_0903(string to, int x)
    {
        var f =
             If(Object<Λ>.Is<ΛΛ>)                       // (Λ, 5) -> 5
            .AndIf(Is<ΛΛΛ>)                             // (ΛΛ, 5) -> 5, (ΛΔ, 5) -> 5
                .Then(From_Λ_To_ΛΛ_With(Add(2)))        // (ΛΛΛ, 5) -> 7
                .If(ΛΛ_Is(MoreThen(1000)))
                    .Then(From_ΛΛ_To_ΛΔ_With(Add(3)))   // (ΛΛΛ, 999) -> 1004
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        Λ arg = to switch
        {
            "Λ" => new Λ(x),
            "ΛΛ" => new ΛΛ(x),
            "ΛΔ" => new ΛΔ(x),
            "ΛΛΛ" => new ΛΛΛ(x),
            _ => throw new NotSupportedException()
        };

        A result = f(arg);

        return result.Value;
    }

    [TestCase(2,  true,  ExpectedResult = 2,   TestName = "Test_0904( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,   TestName = "Test_0904( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 25,  TestName = "Test_0904( 3, false -> 25 )")]
    [TestCase(3,  true,  ExpectedResult = 25,  TestName = "Test_0904( 3, true -> 25 )")]
    [TestCase(91, false, ExpectedResult = 113, TestName = "Test_0904( 91, false -> 113 )")]
    [TestCase(91, true,  ExpectedResult = 154, TestName = "Test_0904( 91, true -> 154 )")]
    public int Test_0904(int x, bool isΛΛΔ)
    {
        var from_B_To_ΛΛ_With =
            From_B_To_ΛΛ_OrTo_ΛΛΔ(isΛΛΔ);

        var f =
             If(Λ_Is(Odd))                              // (2, false) -> 2, (2, true) -> 2
                .Then(From_Λ_To_B_With(Add(2)))
                .Then(from_B_To_ΛΛ_With(Add(20)))       // (3, false) -> 25
                .If(ΛΛ_Is(MoreThen(100)))               // (3, true) -> 25, (91, false) -> 113
                .AndIf(Is<ΛΛΔ>)
                    .Then(From_ΛΛΔ_To_D_With(Add(20)))
                    .Then(From_D_To_ΛΔ_With(Add(21)))   // (91, true) -> 154
                .End(WithReturn<Λ>)
            .End(WithReturn<A>);

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(1,   "Δ",   false, ExpectedResult = 1,    TestName = "Test_0905( 1, Δ, false -> 1 )")]
    [TestCase(1,   "ΔΔ",  false, ExpectedResult = 1,    TestName = "Test_0905( 1, ΔΔ, false -> 1 )")]
    [TestCase(1,   "ΔΔΔ", false, ExpectedResult = 1,    TestName = "Test_0905( 1, ΔΔΔ, false -> 1 )")]
    [TestCase(1,   "Δ",   true,  ExpectedResult = 1,    TestName = "Test_0905( 1, Δ, true -> 1 )")]
    [TestCase(1,   "ΔΔ",  true,  ExpectedResult = 1,    TestName = "Test_0905( 1, ΔΔ, true -> 1 )")]
    [TestCase(1,   "ΔΔΔ", true,  ExpectedResult = 1,    TestName = "Test_0905( 1, ΔΔΔ, true -> 1 )")]
    [TestCase(2,   "Δ",   false, ExpectedResult = 2,    TestName = "Test_0905( 2, Δ, false -> 2 )")]
    [TestCase(2,   "ΔΔ",  false, ExpectedResult = 2,    TestName = "Test_0905( 2, ΔΔ, false -> 2 )")]
    [TestCase(2,   "Δ",   true,  ExpectedResult = 2,    TestName = "Test_0905( 2, Δ, true -> 2 )")]
    [TestCase(2,   "ΔΔ",  true,  ExpectedResult = 2,    TestName = "Test_0905( 2, ΔΔ, true -> 2 )")]
    [TestCase(2,   "ΔΔΔ", false, ExpectedResult = 224,  TestName = "Test_0905( 2, ΔΔΔ, false -> 224 )")]
    [TestCase(2,   "ΔΔΔ", true,  ExpectedResult = 224,  TestName = "Test_0905( 2, ΔΔΔ, true -> 224 )")]
    [TestCase(302, "ΔΔΔ", false, ExpectedResult = 524,  TestName = "Test_0905( 302, ΔΔΔ, false -> 524 )")]
    [TestCase(802, "ΔΔΔ", true,  ExpectedResult = 1024, TestName = "Test_0905( 802, ΔΔΔ, true -> 1024 )")]
    [TestCase(302, "ΔΔΔ", true,  ExpectedResult = 857,  TestName = "Test_0905( 302, ΔΔΔ, true -> 857 )")]
    public int Test_0905(int x, string firstTo, bool secondIsΔΔΛ)
    {
        var from_E_To_ΔΔ_OrTo_ΔΔΛ_With =
            From_E_To_ΔΔ_OrTo_ΔΔΛ(secondIsΔΔΛ);
                                                            // (1, Δ,   false) -> 1, (1, ΔΔ, false) -> 1
        var f =                                             // (1, ΔΔΔ, false) -> 1, (1, Δ,  true)  -> 1
             If(Δ_Is(Even))                                 // (1, ΔΔ,  true)  -> 1, (1, ΔΔΔ, true) -> 1
            .AndIf(Is<ΔΔ>)                                  // (2, Δ,   false) -> 2, (2, ΔΔ, false) -> 2
            .AndIf(Is<ΔΔΔ>)                                 // (2, Δ,   true)  -> 2, (2, ΔΔ, true)  -> 2
                .Then(From_ΔΔΔ_To_C_With(Add(2)))
                .Then(From_C_To_E_With(Add(20)))
                .Then(from_E_To_ΔΔ_OrTo_ΔΔΛ_With(Add(200))) // (2,   ΔΔΔ, false) -> 224,  (2,   ΔΔΔ, true) -> 224
                .If(ΔΔ_Is(MoreThen(500)))                   // (302, ΔΔΔ, false)  -> 524, (802, ΔΔΔ, true) -> 1024
                .AndIf(Is<ΔΔΛ>)
                .AndIf(ΔΔ_Is(LessThen(1000)))
                    .Then(From_ΔΔΛ_To_E_With(Add(3)))
                    .Then(From_E_To_B_With(Add(30)))
                    .Then(From_B_To_ΔΛ_With(Add(300)))      // (302, ΔΔΔ, true) -> 857
                .End(WithReturn<Δ>)
            .End(WithReturn<A>);

        Δ arg = firstTo switch
        {
            "Δ" => new Δ(x),
            "ΔΔ" => new ΔΔ(x),
            "ΔΔΔ" => new ΔΔΔ(x),
            _ => throw new NotSupportedException()
        };

        A result = f(arg);

        return result.Value;
    }

    [TestCase(8,  ExpectedResult = 8,   TestName = "Test_0906( 8 -> 8 )")]
    [TestCase(12, ExpectedResult = 12,  TestName = "Test_0906( 12 -> 12 )")]
    [TestCase(9,  ExpectedResult = 9,   TestName = "Test_0906( 9 -> 9 )")]
    [TestCase(11, ExpectedResult = 33,  TestName = "Test_0906( 11 -> 33 )")]
    [TestCase(81, ExpectedResult = 144, TestName = "Test_0906( 81 -> 144 )")]
    public int Test_0906(int x)
    {
        var f =
             If(ΔΛ_Is(Odd))                             // 8 -> 8, 12 -> 12
            .AndIf(ΔΛ_Is(MoreThen(10)))                 // 9 -> 9
                .Then(From_ΔΛ_To_D_With(Add(2)))
                .Then(From_D_To_ΔΔ_With(Add(20)))       // 11 -> 33
                .If(ΔΔ_Is(MoreThen(100)))
                    .Then(From_ΔΔ_To_A_With(Add(20)))
                    .Then(From_A_To_ΔΔ_With(Add(21)))   // 81 -> 144
                .End()
            .End(WithReturn<Δ>);

        Δ result = f(new ΔΛ(x));

        return result.Value;
    }

    [TestCase(1,    false, ExpectedResult = 1,    TestName = "Test_0907( 1, false -> 1 )")]
    [TestCase(2,    false, ExpectedResult = 2,    TestName = "Test_0907( 2, false -> 2 )")]
    [TestCase(16,   false, ExpectedResult = 16,   TestName = "Test_0907( 16, false -> 16 )")]
    [TestCase(22,   false, ExpectedResult = 22,   TestName = "Test_0907( 22, false -> 22 )")]
    [TestCase(26,   false, ExpectedResult = 248,  TestName = "Test_0907( 26, false -> 248 )")]
    [TestCase(26,   true,  ExpectedResult = 248,  TestName = "Test_0907( 26, true -> 248 )")]
    [TestCase(2116, false, ExpectedResult = 2338, TestName = "Test_0907( 2116, false -> 2338 )")]
    [TestCase(2116, true,  ExpectedResult = 2671, TestName = "Test_0907( 2116, true -> 2671 )")]
    public int Test_0907(int x, bool isΔΔΔ)
    {
        var from_B_To_ΔΔ_OrTo_ΔΔΔ_With =
            From_B_To_ΔΔ_OrTo_ΔΔΔ(isΔΔΔ);

        var f =
             If(A_Is(Even))                                 // (1, false) -> 1, (2, false) -> 2
            .AndIf(A_Is(EndingWith("6")))                   // (16, false) -> 16, (22, false) -> 22
            .AndIf(A_Is(StartingWith("2")))
                .Then(From_A_To_D_With(Add(2)))
                .Then(From_D_To_B_With(Add(20)))
                .Then(from_B_To_ΔΔ_OrTo_ΔΔΔ_With(Add(200))) // (26, false) -> 248, (26, true) -> 248
                .If(Is<ΔΔΔ>)                                // (2116, false) -> 2338
                .AndIf(ΔΔΔ_Is(MoreThen(1000)))
                    .Then(From_ΔΔΔ_To_B_With(Add(3)))
                    .Then(From_B_To_D_With(Add(30)))
                    .Then(From_D_To_ΔΛ_With(Add(300)))      // (2116, true) -> 2671
                .End(WithReturn<Δ>)
            .End();

        A result = f(new A(x));

        return result.Value;
    }
}
