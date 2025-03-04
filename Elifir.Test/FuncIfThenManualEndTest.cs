namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class FuncIfThenManualEndTest
    {
        [TestCase(2, ExpectedResult = 3, TestName = "Test_0400( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test_0400( 1 -> 4 )")]
        public int Test_0400(int x)
        {
            var f =
                 From_Λ_To_Λ_With(Plus(1))              // 2 -> 3
                .If(Λ_Is(Even))
                    .Then(From_Λ_To_Δ_With(Plus(2)))    // 1 -> 4
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 13, TestName = "Test_0401( 2 -> 13 )")]
        [TestCase(1, ExpectedResult = 34, TestName = "Test_0401( 1 -> 34 )")]
        public int Test_0401(int x)
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

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0402( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0402( 2 -> 335 )")]
        public int Test_0402(int x)
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0403( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0403( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test_0403( 999 -> 1005 )")]
        public int Test_0403(int x)
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

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test_0404( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test_0404( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test_0404( 68 -> 142 )")]
        public int Test_0404(int x)
        {
            var f =
                 From_C_To_E_With(Plus(1))
                .Then(From_E_To_Λ_With(Plus(10)))           // 1 -> 12
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_ΛΛ_With(Plus(20)))      // 2 -> 35
                    .If(ΛΛ_Is(MoreThen(100)))
                        .Then(From_ΛΛ_To_D_With(Plus(20)))
                        .Then(From_D_To_ΛΔ_With(Plus(21)))  // 68 -> 142
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
                 From_A_To_B_With(Plus(1))
                .Then(From_B_To_D_With(Plus(10)))
                .Then(From_D_To_Δ_With(Plus(100)))          // 2 -> 113
                .If(Δ_Is(Even))
                    .Then(From_Δ_To_C_With(Plus(2)))
                    .Then(From_C_To_E_With(Plus(20)))
                    .Then(From_E_To_ΔΔ_With(Plus(200)))     // 1 -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300))) // 1001 -> 1667
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0407( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0407( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0407( 1001 -> 1667 )")]
        public int Test_0407(int x)
        {
            var f =
                 From_B_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_A_With(Plus(100)))          // 2 -> 113
                .If(A_Is(Even))
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))     // 1 -> 334
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300))) // 1001 -> 1667
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


        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0409( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test_0409( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test_0409( 10 -> 16 )")]
        public int Test_0409(int x)
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0410( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0410( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test_0410( 999 -> 1005 )")]
        public int Test_0410(int x)
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0411( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0411( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0411( 1001 -> 1667 )")]
        public int Test_0411(int x)
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0412( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0412( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0412( 1001 -> 1667 )")]
        public int Test_0412(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Δ_With(Plus(100)))              // 2 -> 113
                .If(Δ_Is(Even))
                    .Then(From_Δ_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 1 -> 334
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
