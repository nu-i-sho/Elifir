namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenManualEndTest
    {
        [TestCase(1, ExpectedResult = 1, TestName = "Test_0200( 1 -> 1 )")]
        [TestCase(2, ExpectedResult = 4, TestName = "Test_0200( 2 -> 4 )")]
        public int Test_0200(int x)
        {
            var f =
                 If(Λ_Is(Even))                         // 1 -> 1
                    .Then(From_Λ_To_Δ_With(Plus(2)))    // 2 -> 4
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(5, ExpectedResult = 5,  TestName = "Test_0201( 5 -> 5 )")]
        [TestCase(2, ExpectedResult = 24, TestName = "Test_0201( 2 -> 24 )")]
        public int Test_0201(int x)
        {
            var f =
                 If(Λ_Is(Even))                         // 5 -> 5
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_Δ_With(Plus(20)))   // 1 -> 24
                .End(WithReturn<A>);


            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(8, ExpectedResult = 8,   TestName = "Test_0202( 8 -> 8 )")]
        [TestCase(7, ExpectedResult = 229, TestName = "Test_0202( 7 -> 229 )")]
        public int Test_0202(int x)
        {
            var f =
                 If(Λ_Is(Odd))                          // 8 -> 8
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_E_With(Plus(20)))
                    .Then(From_E_To_Δ_With(Plus(200)))  // 7 -> 229
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(5,    ExpectedResult = 5,    TestName = "Test_0203( 5 -> 5 )")]
        [TestCase(8,    ExpectedResult = 10,   TestName = "Test_0203( 8 -> 10 )")]
        [TestCase(1000, ExpectedResult = 1005, TestName = "Test_0203( 1000 -> 1005 )")]
        public int Test_0203(int x)
        {
            var f =
                 If(Λ_Is(Even))                             // 5 -> 5
                    .Then(From_Λ_To_ΛΛ_With(Plus(2)))       // 8 -> 10
                    .If(ΛΛ_Is(MoreThen(1000)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Plus(3)))  // 1000 -> 1005
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 2,   TestName = "Test_0204( 2 -> 2 )")]
        [TestCase(3,  ExpectedResult = 25,  TestName = "Test_0204( 3 -> 25 )")]
        [TestCase(79, ExpectedResult = 142, TestName = "Test_0204( 79 -> 142 )")]
        public int Test_0204(int x)
        {
            var f =
                 If(Λ_Is(Odd))                                  // 2 -> 2
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_ΛΛ_With(Plus(20)))          // 3 -> 25
                    .If(ΛΛ_Is(MoreThen(100)))
                        .Then(From_ΛΛ_To_D_With(Plus(20)))
                        .Then(From_D_To_ΛΔ_With(Plus(21)))      // 79 -> 142
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(3,   ExpectedResult = 3,    TestName = "Test_0205( 1 -> 3 )")]
        [TestCase(4,   ExpectedResult = 226,  TestName = "Test_0205( 4 -> 226 )")]
        [TestCase(800, ExpectedResult = 1355, TestName = "Test_0205( 800 -> 1355 )")]
        public int Test_0205(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 3 -> 3
                    .Then(From_Δ_To_C_With(Plus(2)))
                    .Then(From_C_To_E_With(Plus(20)))
                    .Then(From_E_To_ΔΔ_With(Plus(200)))         // 4 -> 226
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300)))     // 800 -> 1355
                    .End(WithReturn<Δ>)
                .End(WithReturn<A>);

            A result = f(new Δ(x));

            return result.Value;
        }


        [TestCase(8,  ExpectedResult = 8,   TestName = "Test_0206( 8 -> 8 )")]
        [TestCase(1,  ExpectedResult = 23,  TestName = "Test_0206( 1 -> 23 )")]
        [TestCase(97, ExpectedResult = 160, TestName = "Test_0206( 97 -> 160 )")]
        public int Test_0206(int x)
        {
            var f =
                 If(ΔΛ_Is(Odd))                             // 8 -> 8
                    .Then(From_ΔΛ_To_D_With(Plus(2)))
                    .Then(From_D_To_ΔΔ_With(Plus(20)))      // 2 -> 35
                    .If(ΔΔ_Is(MoreThen(100)))
                        .Then(From_ΔΔ_To_A_With(Plus(20)))
                        .Then(From_A_To_ΔΔ_With(Plus(21)))  // 97 -> 160
                    .End()
                .End(WithReturn<Δ>);

            Δ result = f(new ΔΛ(x));

            return result.Value;
        }

        [TestCase(1,   ExpectedResult = 1,    TestName = "Test_0207( 1 -> 1 )")]
        [TestCase(4,   ExpectedResult = 226,  TestName = "Test_0207( 4 -> 226 )")]
        [TestCase(804, ExpectedResult = 1359, TestName = "Test_0207( 804 -> 1359 )")]
        public int Test_0207(int x)
        {
            var f =
                 If(A_Is(Even))                                 // 1 -> 1
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 4 -> 226
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // 804 -> 1359
                    .End(WithReturn<Δ>)
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1000, ExpectedResult = 1000, TestName = "Test_0208( 1000 -> 1000 )")]
        [TestCase(3,    ExpectedResult = 5,    TestName = "Test_0208( 3 -> 5 )")]
        [TestCase(11,   ExpectedResult = 16,   TestName = "Test_0208( 11 -> 16 )")]
        public int Test_0208(int x)
        {
            var f =
                 If(Λ_Is(Odd))                              // 1000 -> 1000
                    .Then(From_Λ_To_ΔΔ_With(Plus(2)))       // 3 -> 5
                    .If(ΔΔ_Is(MoreThen(10)))
                        .Then(From_ΔΔ_To_Δ_With(Plus(3)))   // 11 -> 16
                    .End()
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 2,  TestName = "Test_0209( 2 -> 2 )")]
        [TestCase(5, ExpectedResult = 7,  TestName = "Test_0209( 5 -> 7 )")]
        [TestCase(9, ExpectedResult = 14, TestName = "Test_0209( 9 -> 14 )")]
        public int Test_0209(int x)
        {
            var f =
                 If(Λ_Is(Odd))                              // 2 -> 2
                    .Then(From_Λ_To_Δ_With(Plus(2)))        // 5 -> 7
                    .If(Δ_Is(MoreThen(10)))
                        .Then(From_Δ_To_ΔΔ_With(Plus(3)))   // 9 -> 14
                    .End()
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(999,  ExpectedResult = 999,  TestName = "Test_0210( 999 -> 999 )")]
        [TestCase(2,    ExpectedResult = 4,    TestName = "Test_0210( 2 -> 4 )")]
        [TestCase(1600, ExpectedResult = 1605, TestName = "Test_0210( 1600 -> 1605 )")]
        public int Test_0210(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 999 -> 999
                    .Then(From_Δ_To_ΔΔ_With(Plus(2)))           // 2 -> 4
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_ΔΛ_With(Plus(3)))      // 1600 -> 1605
                    .End(WithReturn<A>)
                .End();

            A result = f(new Δ(x));

            return result.Value;
        }

        [TestCase(3,    ExpectedResult = 3,    TestName = "Test_0211( 3 -> 3 )")]
        [TestCase(8,    ExpectedResult = 230,  TestName = "Test_0211( 8 -> 230 )")]
        [TestCase(1008, ExpectedResult = 1563, TestName = "Test_0211( 1008 -> 1563 )")]
        public int Test_0211(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 3 -> 3
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 8 -> 230
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // 1008 -> 1563
                    .End(WithReturn<A>)
                .End();

            A result = f(new Δ(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test_0212( 1 -> 1 )")]
        [TestCase(20,   ExpectedResult = 242,  TestName = "Test_0212( 20 -> 242 )")]
        [TestCase(2000, ExpectedResult = 2555, TestName = "Test_0212( 2000 -> 2555 )")]
        public int Test_0212(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 1 -> 1
                    .Then(From_Δ_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 20 -> 242
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300)))     // 2000 -> 2555
                    .End(WithReturn<Δ>)
                .End();

            Δ result = f(new Δ(x));

            return result.Value;
        }
    }
}
