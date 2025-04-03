namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenTest_10
    {
        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_1000( 1 -> 2 )")]
        [TestCase(12, ExpectedResult = 13, TestName = "Test_1000( 12 -> 13 )")]
        [TestCase(11, ExpectedResult = 14, TestName = "Test_1000( 11 -> 14 )")]
        public int Test_1000(int x)
        {
            var f =
                 From_Λ_To_Λ_With(Add(1))
                .If(Λ_Is(Even)).AndIf(Λ_Is(MoreThen(10)))   // 1 -> 2, 12 -> 13
                    .Then(From_Λ_To_Δ_With(Add(2)))         // 11 -> 14
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2, false, ExpectedResult = 13, TestName = "Test_1001( 2, false -> 13 )")]
        [TestCase(2, true,  ExpectedResult = 13, TestName = "Test_1001( 2, true -> 13 )")]
        [TestCase(3, false, ExpectedResult = 14, TestName = "Test_1001( 3, false -> 14 )")]
        [TestCase(3, true,  ExpectedResult = 36, TestName = "Test_1001( 3, true -> 36 )")]
        public int Test_1001(int x, bool isΛΛ)
        {
            var from_Λ_To_Λ_OrTo_ΛΛ_With =
                From_Λ_To_Λ_OrTo_ΛΛ(isΛΛ);

            var f =
                 From_A_To_Λ_With(Add(1))
                .Then(from_Λ_To_Λ_OrTo_ΛΛ_With(Add(10)))    // (2, false) -> 13
                .If(Λ_Is(Even)).AndIf(Is<ΛΛ>)               // (2, true) -> 13, (3, false) -> 14
                    .Then(From_Λ_To_B_With(Add(2)))
                    .Then(From_B_To_Δ_With(Add(20)))        // (3, true) -> 36
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, "Λ",   ExpectedResult = 113, TestName = "Test_1002( 2, Λ -> 113 )")]
        [TestCase(1, "Λ",   ExpectedResult = 112, TestName = "Test_1002( 1, Λ -> 112 )")]
        [TestCase(2, "ΛΛ",  ExpectedResult = 113, TestName = "Test_1002( 2, ΛΛ -> 113 )")]
        [TestCase(1, "ΛΛ",  ExpectedResult = 112, TestName = "Test_1002( 1, ΛΛ -> 112 )")]
        [TestCase(1, "ΛΛΛ", ExpectedResult = 112, TestName = "Test_1002( 1, ΛΛΛ -> 112 )")]
        [TestCase(2, "ΛΛΛ", ExpectedResult = 335, TestName = "Test_1002( 2, ΛΛΛ -> 335 )")]
        public int Test_1002(int x, string to)
        {
            var from_E_To_Λ_OrTo_ΛΛ_OrTo_ΛΛΛ_With =
                From_E_To_Λ_OrTo_ΛΛ_OrTo_ΛΛΛ(to);

            var f =
                 From_D_To_B_With(Add(1))
                .Then(From_B_To_E_With(Add(10)))
                .Then(from_E_To_Λ_OrTo_ΛΛ_OrTo_ΛΛΛ_With(Add(100)))
                .If(Is<ΛΛ>)                                         // (2, Λ) -> 113, (1, Λ) -> 112
                .AndIf(Λ_Is(Odd))                                   // (2, ΛΛ) -> 113, (1, ΛΛ) -> 112
                .AndIf(Is<ΛΛΛ>)                                     // (1, ΛΛΛ) -> 112
                    .Then(From_ΛΛΛ_To_B_With(Add(2)))
                    .Then(From_B_To_E_With(Add(20)))
                    .Then(From_E_To_Δ_With(Add(200)))               // (2, ΛΛΛ) -> 335
                .End(WithReturn<A>);

            A result = f(new D(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,   TestName = "Test_1003( 2 -> 3 )")]
        [TestCase(3,   ExpectedResult = 4,   TestName = "Test_1003( 3 -> 4 )")]
        [TestCase(20,  ExpectedResult = 21,  TestName = "Test_1003( 20 -> 21 )")]
        [TestCase(21,  ExpectedResult = 24,  TestName = "Test_1003( 20 -> 24 )")]
        [TestCase(221, ExpectedResult = 224, TestName = "Test_1003( 221 -> 224 )")]
        [TestCase(121, ExpectedResult = 127, TestName = "Test_1003( 121 -> 127 )")]
        public int Test_1003(int x)
        {
            var f =
                 From_A_To_Λ_With(Add(1))                   // 2 -> 3, 3 -> 4
                .If(Λ_Is(Even))                             // 20 -> 21
                .AndIf(Λ_Is(MoreThen(10)))
                    .Then(From_Λ_To_ΛΛ_With(Add(2)))        // 21 -> 24
                    .If(ΛΛ_Is(MoreThen(100)))               // 221 -> 224
                    .AndIf(ΛΛ_Is(LessThen(200)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(3)))   // 121 -> 127
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    false, false, ExpectedResult = 113,  TestName = "Test_1005( 2, false, false -> 113 )")]
        [TestCase(2,    true,  false, ExpectedResult = 113,  TestName = "Test_1005( 2, true, false -> 113 )")]
        [TestCase(1,    false, false, ExpectedResult = 112,  TestName = "Test_1005( 1, false, false -> 112 )")]
        [TestCase(1,    true,  false, ExpectedResult = 334,  TestName = "Test_1005( 1, true, false -> 334 )")]
        [TestCase(1001, true,  false, ExpectedResult = 1334, TestName = "Test_1005( 1001, true, false -> 1334 )")]
        [TestCase(1001, true,  true,  ExpectedResult = 1667, TestName = "Test_1005( 1001, true, true -> 1667 )")]
        public int Test_1005(int x, bool firstIsΔΔ, bool secondIsΔΔΔ)
        {
            var from_D_To_Δ_OrTo_ΔΔ_With =
                From_D_To_Δ_OrTo_ΔΔ(firstIsΔΔ);

            var from_E_To_ΔΔ_OrTo_ΔΔΔ_With =
                From_E_To_ΔΔ_OrTo_ΔΔΔ(secondIsΔΔΔ);

            var f =
                 From_A_To_B_With(Add(1))
                .Then(From_B_To_D_With(Add(10)))
                .Then(from_D_To_Δ_OrTo_ΔΔ_With(Add(100)))           // (2, false, false) -> 113
                .If(Δ_Is(Even))                                     // (2, true,  false) -> 113
                .AndIf(Is<ΔΔ>)                                      // (1, true,  false) -> 112
                    .Then(From_ΔΔ_To_C_With(Add(2)))
                    .Then(From_C_To_E_With(Add(20)))
                    .Then(from_E_To_ΔΔ_OrTo_ΔΔΔ_With(Add(200)))     // (1, true, false) -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))                      // (1001, true, false) -> 1334
                    .AndIf(Is<ΔΔΔ>)
                        .Then(From_ΔΔΔ_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_ΔΛ_With(Add(300)))          // (1001, true, true) -> 1667
                    .End(WithReturn<Δ>)
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }
    }
}
