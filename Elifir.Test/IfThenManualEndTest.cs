namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenManualEndTest
    {
        [TestCase(2, ExpectedResult = 3, TestName = "Test40( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test40( 1 -> 4 )")]
        public int Test40(int x)
        {
            var f =
                 From_Λ_To_Λ_With(Plus(1))              // 2 -> 3
                .If(Λ_Is(Even))
                    .Then(From_Λ_To_Δ_With(Plus(2)))    // 1 -> 4
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 13, TestName = "Test41( 2 -> 13 )")]
        [TestCase(1, ExpectedResult = 34, TestName = "Test41( 1 -> 34 )")]
        public int Test41(int x)
        {
            var f =
                 From_A_To_Λ_With(Plus(1))
                .Then(From_Λ_To_Λ_With(Plus(10)))       // 2 -> 13
                .If(Λ_Is(Even))
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_Δ_With(Plus(20)))   // 1 -> 34
                .End(WithReturn<A>);


            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test42( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test42( 2 -> 335 )")]
        public int Test42(int x)
        {
            var f =
                 From_D_To_B_With(Plus(1))
                .Then(From_B_To_E_With(Plus(10)))
                .Then(From_E_To_Λ_With(Plus(100)))      // 1 -> 112
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_E_With(Plus(20)))
                    .Then(From_E_To_Δ_With(Plus(200)))  // 2 -> 335
                .End(WithReturn<A>);

            A result = f(new D(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test43( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test43( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test43( 999 -> 1005 )")]
        public int Test43(int x)
        {
            var f =
                 From_A_To_Λ_With(Plus(1))                  // 2 -> 3
                .If(Λ_Is(Even))
                    .Then(From_Λ_To_ΛΛ_With(Plus(2)))       // 1 -> 4
                    .If(ΛΛ_Is(MoreThen(1000)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Plus(3)))  // 999 -> 1005
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test44( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test44( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test44( 68 -> 142 )")]
        public int Test44(int x)
        {
            var f =
                 From_C_To_E_With(Plus(1))
                .Then(From_E_To_Λ_With(Plus(10)))               // 1 -> 12
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_ΛΛ_With(Plus(20)))          // 2 -> 35
                    .If(ΛΛ_Is(MoreThen(100)))
                        .Then(From_ΛΛ_To_D_With(Plus(20)))
                        .Then(From_D_To_ΛΔ_With(Plus(21)))      // 68 -> 142
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new C(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test45( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test45( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test45( 1001 -> 1667 )")]
        public int Test45(int x)
        {
            var f =
                 From_A_To_B_With(Plus(1))
                .Then(From_B_To_D_With(Plus(10)))
                .Then(From_D_To_Δ_With(Plus(100)))              // 2 -> 113
                .If(Δ_Is(Even))
                    .Then(From_Δ_To_C_With(Plus(2)))
                    .Then(From_C_To_E_With(Plus(20)))
                    .Then(From_E_To_ΔΔ_With(Plus(200)))         // 1 -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300)))     // 1001 -> 1667
                    .End(WithReturn<Δ>)
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }


        [TestCase(1,  ExpectedResult = 12,  TestName = "Test46( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test46( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test46( 68 -> 142 )")]
        public int Test46(int x)
        {
            var f =
                 From_A_To_D_With(Plus(1))
                .Then(From_D_To_ΔΛ_With(Plus(10)))          // 1 -> 12
                .If(ΔΛ_Is(Odd))
                    .Then(From_ΔΛ_To_D_With(Plus(2)))
                    .Then(From_D_To_ΔΔ_With(Plus(20)))      // 2 -> 35
                    .If(ΔΔ_Is(MoreThen(100)))
                        .Then(From_ΔΔ_To_A_With(Plus(20)))
                        .Then(From_A_To_ΔΔ_With(Plus(21)))  // 68 -> 142
                    .End()
                .End(WithReturn<Δ>);

            Δ result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test47( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test47( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test47( 1001 -> 1667 )")]
        public int Test47(int x)
        {
            var f =
                 From_B_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_A_With(Plus(100)))              // 2 -> 113
                .If(A_Is(Even))
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 1 -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // 1001 -> 1667
                    .End(WithReturn<Δ>)
                .End();

            A result = f(new B(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test48( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test48( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test48( 10 -> 16 )")]
        public int Test48(int x)
        {
            var f =
                 From_A_To_Λ_With(Plus(1))                  // 1 -> 2
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_ΔΔ_With(Plus(2)))       // 2 -> 5
                    .If(ΔΔ_Is(MoreThen(10)))
                        .Then(From_ΔΔ_To_Δ_With(Plus(3)))   // 10 -> 16
                    .End()
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }


        [TestCase(1,  ExpectedResult = 2,  TestName = "Test49( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test49( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test49( 10 -> 16 )")]
        public int Test49(int x)
        {
            var f =
                 From_A_To_Λ_With(Plus(1))                  // 1 -> 2
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_Δ_With(Plus(2)))        // 2 -> 5
                    .If(Δ_Is(MoreThen(10)))
                        .Then(From_Δ_To_ΔΔ_With(Plus(3)))   // 10 -> 16
                    .End()
                .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test50( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test50( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test50( 999 -> 1005 )")]
        public int Test50(int x)
        {
            var f =
                 From_A_To_Δ_With(Plus(1))                      // 2 -> 3
                .If(Δ_Is(Even))
                    .Then(From_Δ_To_ΔΔ_With(Plus(2)))           // 1 -> 4
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_ΔΛ_With(Plus(3)))      // 999 -> 1005
                    .End(WithReturn<A>)
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test51( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test51( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test51( 1001 -> 1667 )")]
        public int Test51(int x)
        {
            var f =
                 From_B_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Δ_With(Plus(100)))              // 2 -> 113
                .If(Δ_Is(Even))
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 1 -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // 1001 -> 1667
                    .End(WithReturn<A>)
                .End();

            A result = f(new B(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test52( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test52( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test52( 1001 -> 1667 )")]
        public int Test52(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Δ_With(Plus(100)))             // 2 -> 113
                .If(Δ_Is(Even))
                    .Then(From_Δ_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))          // 1 -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300)))     // 1001 -> 1667
                    .End(WithReturn<Δ>)
                .End();

            Δ result = f(new A(x));

            return result.Value;
        }
    }
}
