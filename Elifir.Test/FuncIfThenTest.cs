namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class FuncIfThenTest
    {
        [TestCase(2, ExpectedResult = 3, TestName = "Test_0300( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test_0300( 1 -> 4 )")]
        public int Test_0300(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))              // 2 -> 3
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 13, TestName = "Test_0301( 2 -> 13 )")]
        [TestCase(1, ExpectedResult = 34, TestName = "Test_0301( 1 -> 34 )")]
        public int Test_0301(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))       // 2 -> 13
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))   // 1 -> 34
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0302( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0302( 2 -> 335 )")]
        public int Test_0302(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))
                .Then(From_A_To_A_With(Add(100)))      // 1 -> 112
                .If(A_Is(Odd))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))  // 2 -> 335
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 113, TestName = "Test_0303( 2 -> 113 )")]
        [TestCase(1, ExpectedResult = 334, TestName = "Test_0303( 1 -> 334 )")]
        public int Test_0303(int x)
        {
            var f =
                 From_A_To_B_With(Add(1))
                .Then(From_B_To_C_With(Add(10)))
                .Then(From_C_To_D_With(Add(100)))      // 2 -> 113
                .If(D_Is(Even))
                    .Then(From_D_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_D_With(Add(200)))  // 1 -> 334
                .End();

            D result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 2, TestName = "Test_0304( 1 -> 2 )")]
        [TestCase(2, ExpectedResult = 5, TestName = "Test_0304( 2 -> 5 )")]
        public int Test_0304(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))              // 1 -> 2
                .If(A_Is(Odd))
                    .Then(From_A_To_Aʹ_With(Add(2)))   // 2 -> 5
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 21,  TestName = "Test_0305( 10 -> 21 )")]
        [TestCase(90, ExpectedResult = 123, TestName = "Test_0305( 90 -> 123 )")]
        public int Test_0305(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))       // 10 -> 21
                .If(A_Is(MoreThen(100)))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_Aʹ_With(Add(20)))  // 90 -> 123
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0306( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0306( 2 -> 335 )")]
        public int Test_0306(int x)
        {
            var f =
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_D_With(Add(10)))
                .Then(From_D_To_B_With(Add(100)))      // 1 -> 112
                .If(B_Is(Odd))
                    .Then(From_B_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Bʹ_With(Add(200))) // 2 -> 335
                .End();

            B result = f(new A(x));

            return result.Value;
        }


        [TestCase(2, ExpectedResult = 3, TestName = "Test_0307( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test_0307( 1 -> 4 )")]
        public int Test_0307(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Add(1))             // 2 -> 3
                .If(Aʹ_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 12, TestName = "Test_0308( 1 -> 12 )")]
        [TestCase(2, ExpectedResult = 35, TestName = "Test_0308( 2 -> 35 )")]
        public int Test_0308(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_Aʹ_With(Add(10)))      // 1 -> 12
                .If(Aʹ_Is(Odd))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))   // 2 -> 35
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0309( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0309( 2 -> 335 )")]
        public int Test_0309(int x)
        {
            var f =
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_D_With(Add(10)))
                .Then(From_D_To_Bʹ_With(Add(100)))     // 1 -> 112
                .If(Bʹ_Is(Odd))
                    .Then(From_B_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_B_With(Add(200)))  // 2 -> 335
                .End();
            
            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0310( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0310( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test_0310( 999 -> 1005 )")]
        public int Test_0310(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))                  // 2 -> 3
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))        // 1 -> 4
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Add(3)))    // 999 -> 1005
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test_0311( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test_0311( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test_0311( 68 -> 142 )")]
        public int Test_0311(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))           // 1 -> 12
                .If(A_Is(Odd))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))       // 2 -> 35
                    .If(A_Is(MoreThen(100)))
                        .Then(From_A_To_A_With(Add(20)))
                        .Then(From_A_To_A_With(Add(21)))   // 68 -> 142
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0312( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0312( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0312( 1001 -> 1667 )")]
        public int Test_0312(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))
                .Then(From_A_To_A_With(Add(100)))          // 2 -> 113
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))      // 1 -> 334
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Add(3)))
                        .Then(From_A_To_A_With(Add(30)))
                        .Then(From_A_To_A_With(Add(300)))  // 1001 -> 1667
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0313( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0313( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test_0313( 999 -> 1005 )")]
        public int Test_0313(int x)
        {
            var f =
                 From_A_To_B_With(Add(1))                  // 2 -> 3 
                .If(B_Is(Even))
                    .Then(From_B_To_Bʹ_With(Add(2)))       // 1 -> 4
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Add(3)))   // 999 -> 1005
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test_0314( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test_0314( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test_0314( 68 -> 142 )")]
        public int Test_0314(int x)
        {
            var f =
                 From_A_To_D_With(Add(1))
                .Then(From_D_To_C_With(Add(10)))           // 1 -> 12
                .If(C_Is(Odd))
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(From_D_To_C_With(Add(20)))       // 2 -> 35
                    .If(C_Is(MoreThen(100)))
                        .Then(From_C_To_A_With(Add(20)))
                        .Then(From_A_To_Cʹ_With(Add(21)))  // 68 -> 142
                    .End()
                .End();

            C result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0315( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0315( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0315( 1001 -> 1667 )")]
        public int Test_0315(int x)
        {
            var f =
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_D_With(Add(10)))
                .Then(From_D_To_C_With(Add(100)))          // 2 -> 113
                .If(C_Is(Even))
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(From_D_To_B_With(Add(20)))
                    .Then(From_B_To_Cʹ_With(Add(200)))     // 1 -> 334
                    .If(Cʹ_Is(MoreThen(1000)))
                        .Then(From_Cʹ_To_B_With(Add(3)))
                        .Then(From_B_To_D_With(Add(30)))
                        .Then(From_D_To_Cʹ_With(Add(300))) // 1001 -> 1667
                    .End()
                .End();

            C result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0316( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test_0316( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test_0316( 10 -> 16 )")]
        public int Test_0316(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Add(1))                 // 1 -> 2
                .If(Aʹ_Is(Odd))
                    .Then(From_Aʹ_To_A_With(Add(2)))       // 2 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Add(3)))    // 10 -> 16
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }


        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0317( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test_0317( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test_0317( 10 -> 16 )")]
        public int Test_0317(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Add(1))                 // 1 -> 2
                .If(Aʹ_Is(Odd))
                    .Then(From_Aʹ_To_A_With(Add(2)))       // 2 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Add(3)))   // 10 -> 16
                   .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0318( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0318( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test_0318( 999 -> 1005 )")]
        public int Test_0318(int x)
        {
            var f =
                 From_A_To_Bʹ_With(Add(1))                 // 2 -> 3
                .If(B_Is(Even))
                    .Then(From_B_To_B_With(Add(2)))        // 1 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_B_With(Add(3)))    // 999 -> 1005
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test_0319( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test_0319( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test_0319( 999 -> 1005 )")]
        public int Test_0319(int x)
        {
            var f =
                 From_A_To_B_With(Add(1))                  // 2 -> 3
                .If(B_Is(Even))
                    .Then(From_B_To_Bʹ_With(Add(2)))       // 1 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_Bʹ_To_B_With(Add(3)))   // 999 -> 1005
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0320( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0320( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0320( 1001 -> 1667 )")]
        public int Test_0320(int x)
        {
            var f =
                  From_A_To_E_With(Add(1))
                 .Then(From_E_To_D_With(Add(10)))
                 .Then(From_D_To_Bʹ_With(Add(100)))        // 2 -> 113
                 .If(Bʹ_Is(Even))
                    .Then(From_B_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_B_With(Add(200)))      // 1 -> 334
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_B_With(Add(300)))  // 1001 -> 1667
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test_0321( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test_0321( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test_0321( 1001 -> 1667 )")]
        public int Test_0321(int x)
        {
            var f =
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_D_With(Add(10)))
                .Then(From_D_To_Bʹ_With(Add(100)))         // 2 -> 113
                .If(Bʹ_Is(Even))
                    .Then(From_Bʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_B_With(Add(200)))      // 1 -> 334
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_Bʹ_With(Add(300))) // 1001 -> 1667
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 11, TestName = "Test_0322( false, 8 -> 11 )")]
        [TestCase(true,  ExpectedResult = 13, TestName = "Test_0322( true, 8 -> 13 )")]
        public int Test_0322(bool isΛΛ)
        {
            var from_D_To_Λ_OrTo_ΛΛ_With =
                From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

            var f =
                 from_D_To_Λ_OrTo_ΛΛ_With(Add(3))
                .If(Object<Λ>.Is<ΛΛ>)                   // (false, 8) -> 11
                    .Then(From_ΛΛ_To_Δ_With(Add(2)))    // (true, 8) -> 13
                .End(WithReturn<A>);

            A result = f(new D(8));

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 9,  TestName = "Test_0323( false, 5 -> 9 )")]
        [TestCase(true,  ExpectedResult = 31, TestName = "Test_0323( true, 5 -> 31 )")]
        public int Test_0323(bool isΛΛ)
        {
            var from_D_To_Λ_OrTo_ΛΛ_With =
                From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

            var f =
                 From_C_To_D_With(Add(1))
                .Then(from_D_To_Λ_OrTo_ΛΛ_With(Add(3)))
                .If(Object<Λ>.Is<ΛΛ>)                   // (false, 5) -> 9
                    .Then(From_ΛΛ_To_B_With(Add(2)))
                    .Then(From_B_To_Δ_With(Add(20)))    // (true, 5) -> 31
                .End(WithReturn<A>);

            A result = f(new C(5));

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 62,  TestName = "Test_0324( false, 8 -> 62 )")]
        [TestCase(true,  ExpectedResult = 284, TestName = "Test_0324( true, 8 -> 284 )")]
        public int Test_0324(bool isΛΛ)
        {
            var from_D_To_Λ_OrTo_ΛΛ_With =
                From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

            var f =
                 From_B_To_C_With(Add(11))
                .Then(From_C_To_D_With(Add(40)))
                .Then(from_D_To_Λ_OrTo_ΛΛ_With(Add(3)))
                .If(Object<Λ>.Is<ΛΛ>)                   // (false, 8) -> 62
                    .Then(From_Λ_To_B_With(Add(2)))
                    .Then(From_B_To_E_With(Add(20)))
                    .Then(From_E_To_Δ_With(Add(200)))   // (true, 8) -> 284
                .End(WithReturn<A>);

            A result = f(new B(8));

            return result.Value;
        }

        [TestCase(false, 3,    ExpectedResult = 103,  TestName = "Test_0325( false, 3 -> 103 )")]
        [TestCase(true,  3,    ExpectedResult = 105,  TestName = "Test_0325( true, 3 -> 105 )")]
        [TestCase(false, 3000, ExpectedResult = 3100, TestName = "Test_0325( false, 3000 -> 3100 )")]
        [TestCase(true,  3000, ExpectedResult = 3105, TestName = "Test_0325( true, 3000 -> 3105 )")]
        public int Test_0325(bool isΔΔ, int x)
        {
            var from_D_To_Δ_OrTo_ΔΔ_With =
                From_D_To_Δ_OrTo_ΔΔ(isΔΔ);

            var f =
                 from_D_To_Δ_OrTo_ΔΔ_With(Add(100))         // (false, 3) -> 103
                .If(Object<Δ>.Is<ΔΔ>)                       // (true, 3) -> 105
                    .Then(From_ΔΔ_To_ΛΔ_With(Add(2)))       // (false, 3000) -> 3100
                    .If(ΛΔ_Is(MoreThen(1000)))
                        .Then(From_ΛΔ_To_ΛΛ_With(Add(3)))   // (true, 3000) -> 3105
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new D(x));

            return result.Value;
        }

        [TestCase(1, false, ExpectedResult = 18, TestName = "Test_0326( 1, false -> 18 )")]
        [TestCase(1, true,  ExpectedResult = 18, TestName = "Test_0326( 1, true -> 18 )")]
        [TestCase(2, false, ExpectedResult = 41, TestName = "Test_0326( 2, false -> 41 )")]
        [TestCase(2, true,  ExpectedResult = 82, TestName = "Test_0326( 2, true -> 82 )")]
        public int Test_0326(int x, bool secondIsΛΛΛ)
        {
            var from_B_To_ΛΛ_OrTo_ΛΛΛ_With =
                From_B_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

            var f = 
                 From_C_To_E_With(Add(9))
                .Then(From_E_To_Δ_With(Add(8)))                    // (1, false) -> 18
                .If(Δ_Is(Odd))                                      // (1, true) -> 18
                    .Then(From_Δ_To_B_With(Add(2)))
                    .Then(from_B_To_ΛΛ_OrTo_ΛΛΛ_With(Add(20)))     // (2, false) -> 41
                    .If(Object<ΛΛ>.Is<ΛΛΛ>)
                        .Then(From_ΛΛΛ_To_D_With(Add(20)))
                        .Then(From_D_To_ΛΔ_With(Add(21)))          // (2, true) -> 82
                    .End(WithReturn<Λ>) 
                .End(WithReturn<A>);

            A result = f(new C(x));

            return result.Value;
        }

        [TestCase(false, false, ExpectedResult = 34,  TestName = "Test_0327( false, false, 25 -> 34 )")]
        [TestCase(false, true,  ExpectedResult = 34,  TestName = "Test_0327( false, true, 25 -> 34 )")]
        [TestCase(true,  false, ExpectedResult = 256, TestName = "Test_0327( true, false, 25 -> 256 )")]
        [TestCase(true,  true,  ExpectedResult = 589, TestName = "Test_0327( true, true, 25 -> 589 )")]
        public int Test_0327(bool firstIsΔΔ, bool secondIsΛΛΛ)
        {
            var from_D_To_Δ_OrTo_ΔΔ_With =
                From_D_To_Δ_OrTo_ΔΔ(firstIsΔΔ);

            var from_E_To_ΛΛ_OrTo_ΛΛΛ_With =
                From_E_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

            var f =                                                 
                 From_C_To_D_With(Add(4))
                .Then(from_D_To_Δ_OrTo_ΔΔ_With(Add(5)))            // (false, false, 25) -> 34
                .If(Object<Δ>.Is<ΔΔ>)                               // (false, true, 25) -> 34
                    .Then(From_ΔΔ_To_C_With(Add(2)))
                    .Then(From_C_To_E_With(Add(20)))
                    .Then(from_E_To_ΛΛ_OrTo_ΛΛΛ_With(Add(200)))    // (true, false, 25) -> 256
                    .If(Object<ΛΛ>.Is<ΛΛΛ>)
                        .Then(From_ΛΛΛ_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_ΛΔ_With(Add(300)))         // (true, false, 25) -> 589
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new C(25));

            return result.Value;
        }

        [TestCase(false, false, ExpectedResult = 10, TestName = "Test_0328( false, false, 3 -> 10 )")]
        [TestCase(false, true,  ExpectedResult = 10, TestName = "Test_0328( false, true, 3 -> 10 )")]
        [TestCase(true,  false, ExpectedResult = 32, TestName = "Test_0328( true, false, 3 -> 32 )")]
        [TestCase(true,  true,  ExpectedResult = 73, TestName = "Test_0328( true, true, 3 -> 73 )")]
        public int Test_0328(bool firstIsΔΔ, bool secondIsΛΛΛ)
        {
            var from_D_To_Δ_OrTo_ΔΔ_With =
                From_D_To_Δ_OrTo_ΔΔ(firstIsΔΔ);

            var from_D_To_ΛΛ_OrTo_ΛΛΛ_With =
                From_D_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

            var f =                       
                 From_C_To_D_With(Add(3))
                .Then(from_D_To_Δ_OrTo_ΔΔ_With(Add(4)))        // (false, false, 3) -> 10
                .If(Object<Δ>.Is<ΔΔ>)                           // (false, true, 3) -> 10
                    .Then(From_ΔΔ_To_D_With(Add(2)))
                    .Then(from_D_To_ΛΛ_OrTo_ΛΛΛ_With(Add(20))) // (true, false, 3) -> 32
                    .If(Object<ΛΛ>.Is<ΛΛΛ>)
                        .Then(From_ΛΛΛ_To_A_With(Add(20)))
                        .Then(From_A_To_ΛΛΔ_With(Add(21)))     // (true, true, 3) -> 73
                    .End()
                .End(WithReturn<A>);

            A result = f(new C(3));

            return result.Value;
        }

        [TestCase(false, 2,   ExpectedResult = 122,  TestName = "Test_0329( false, 2 -> 122 )")]
        [TestCase(true,  300, ExpectedResult = 642,  TestName = "Test_0329( true, 300 -> 642 )")]
        [TestCase(true,  800, ExpectedResult = 1475, TestName = "Test_0329( true, 800 -> 1475 )")]
        public int Test_0329(bool isAʹ, int x)
        {
            var from_A_To_A_Or_To_Aʹ_With =
                From_A_To_A_Or_To_Aʹ(isAʹ);

            var f =
                  From_E_To_C_With(Add(11))
                 .Then(From_C_To_A_With(Add(100)))
                 .Then(from_A_To_A_Or_To_Aʹ_With(Add(9)))
                 .If(Object<A>.Is<Aʹ>)                          // (false, 2) -> 122
                    .Then(From_Aʹ_To_D_With(Add(2)))
                    .Then(From_D_To_B_With(Add(20)))
                    .Then(From_B_To_ΔΔ_With(Add(200)))         // (true, 300) -> 642
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Add(3)))
                        .Then(From_B_To_D_With(Add(30)))
                        .Then(From_D_To_ΔΛ_With(Add(300)))     // (true, 800) -> 1475
                    .End(WithReturn<Δ>)
                .End();

            A result = f(new E(x));

            return result.Value;
        }

        [TestCase(false, 2, ExpectedResult = 3,  TestName = "Test_0330( false, 2 -> 3 )")]
        [TestCase(true,  3, ExpectedResult = 6,  TestName = "Test_0330( true, 3 -> 6 )")]
        [TestCase(true,  8, ExpectedResult = 14, TestName = "Test_0330( true, 8 -> 14 )")]
        public int Test_0330(bool isΛΛ, int x)
        {
            var from_D_To_Λ_OrTo_ΛΛ_With =
                From_D_To_Λ_OrTo_ΛΛ(isΛΛ);

            var f =
                 from_D_To_Λ_OrTo_ΛΛ_With(Add(1))
                .If(Object<Λ>.Is<ΛΛ>)                       // (false, 2) -> 3
                    .Then(From_ΛΛ_To_ΔΔ_With(Add(2)))      // (true, 3) -> 6
                    .If(ΔΔ_Is(MoreThen(10)))
                        .Then(From_ΔΔ_To_Δ_With(Add(3)))   // (true, 8) -> 14
                    .End()
                .End(WithReturn<A>);

            A result = f(new D(x));

            return result.Value;
        }

        [TestCase(1, false, ExpectedResult = 2, TestName = "Test_0331( 1, false -> 2 )")]
        [TestCase(1, true,  ExpectedResult = 2, TestName = "Test_0331( 1, true -> 2 )")]
        [TestCase(2, false, ExpectedResult = 5, TestName = "Test_0331( 2, false -> 5 )")]
        [TestCase(2, true,  ExpectedResult = 8, TestName = "Test_0331( 2, true -> 8 )")]
        public int Test_0331(int x, bool isΔΔ)
        {
            var from_Λ_To_Δ_OrTo_ΔΔ_With =
                From_Λ_To_Δ_OrTo_ΔΔ(isΔΔ);

            var f =
                 From_D_To_Λ_With(Add(1))                      // (1, false) -> 2
                .If(Λ_Is(Odd))                                  // (1, true) -> 2
                    .Then(from_Λ_To_Δ_OrTo_ΔΔ_With(Add(2)))    // (2, false) -> 5
                    .If(Object<Δ>.Is<ΔΔ>)
                        .Then(From_ΔΔ_To_ΔΔΔ_With(Add(3)))     // (3, true) -> 9
                    .End()
                .End(WithReturn<A>);

            A result = f(new D(x));

            return result.Value;
        }
        
        [TestCase(3, false, ExpectedResult = 9,   TestName = "Test_0332( 3, false -> 9 )")]
        [TestCase(3, true,  ExpectedResult = 9,   TestName = "Test_0332( 3, true -> 9 )")]
        [TestCase(2, false, ExpectedResult = 230, TestName = "Test_0332( 2, false -> 230 )")]
        [TestCase(2, true,  ExpectedResult = 563, TestName = "Test_0332( 2, true -> 563 )")]
        public int Test_0332(int x, bool isΔΔ)
        {
            var from_Λ_To_ΔΔ_OrTo_ΔΔ_With =
                From_Λ_To_ΔΔ_OrTo_ΔΔΔ(isΔΔ);

            var f =                                                 
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_B_With(Add(2)))
                .Then(From_B_To_Δ_With(Add(3)))                    // (3, false) -> 9
                .If(Δ_Is(Even))                                     // (3, true) -> 9
                    .Then(From_A_To_D_With(Add(2)))
                    .Then(From_D_To_Λ_With(Add(20)))
                    .Then(from_Λ_To_ΔΔ_OrTo_ΔΔ_With(Add(200)))     // (2, false) -> 230
                    .If(Object<ΔΔ>.Is<ΔΔΔ>)
                        .Then(From_ΔΔΔ_To_B_With(Add(3)))
                        .Then(From_B_To_D_With(Add(30)))
                        .Then(From_D_To_ΔΛ_With(Add(300)))         // (2, true) -> 563
                    .End(WithReturn<A>)
                .End();

            A result = f(new A(x));

            return result.Value;
        }
    }
}
