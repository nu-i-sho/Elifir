﻿namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class FuncIfThenTest
    {
        [TestCase(2, ExpectedResult = 3, TestName = "Test_0300( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test_0300( 1 -> 4 )")]
        public int Test_0300(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))              // 2 -> 3
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 13, TestName = "Test_0301( 2 -> 13 )")]
        [TestCase(1, ExpectedResult = 34, TestName = "Test_0301( 1 -> 34 )")]
        public int Test_0301(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))       // 2 -> 13
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))   // 1 -> 34
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0302( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0302( 2 -> 335 )")]
        public int Test_0302(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))
                .Then(From_A_To_A_With(Plus(100)))      // 1 -> 112
                .If(A_Is(Odd))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))
                    .Then(From_A_To_A_With(Plus(200)))  // 2 -> 335
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 113, TestName = "Test_0303( 2 -> 113 )")]
        [TestCase(1, ExpectedResult = 334, TestName = "Test_0303( 1 -> 334 )")]
        public int Test_0303(int x)
        {
            var f =
                 From_A_To_B_With(Plus(1))
                .Then(From_B_To_C_With(Plus(10)))
                .Then(From_C_To_D_With(Plus(100)))      // 2 -> 113
                .If(D_Is(Even))
                    .Then(From_D_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_D_With(Plus(200)))  // 1 -> 334
                .End();

            D result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 2, TestName = "Test_0304( 1 -> 2 )")]
        [TestCase(2, ExpectedResult = 5, TestName = "Test_0304( 2 -> 5 )")]
        public int Test_0304(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))              // 1 -> 2
                .If(A_Is(Odd))
                    .Then(From_A_To_Aʹ_With(Plus(2)))   // 2 -> 5
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 21,  TestName = "Test_0305( 10 -> 21 )")]
        [TestCase(90, ExpectedResult = 123, TestName = "Test_0305( 90 -> 123 )")]
        public int Test_0305(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))       // 10 -> 21
                .If(A_Is(MoreThen(100)))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_Aʹ_With(Plus(20)))  // 90 -> 123
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0306( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0306( 2 -> 335 )")]
        public int Test_0306(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_B_With(Plus(100)))      // 1 -> 112
                .If(B_Is(Odd))
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_Bʹ_With(Plus(200))) // 2 -> 335
                .End();

            B result = f(new A(x));

            return result.Value;
        }


        [TestCase(2, ExpectedResult = 3, TestName = "Test_0307( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test_0307( 1 -> 4 )")]
        public int Test_0307(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Plus(1))             // 2 -> 3
                .If(Aʹ_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 12, TestName = "Test_0308( 1 -> 12 )")]
        [TestCase(2, ExpectedResult = 35, TestName = "Test_0308( 2 -> 35 )")]
        public int Test_0308(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_Aʹ_With(Plus(10)))      // 1 -> 12
                .If(Aʹ_Is(Odd))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))   // 2 -> 35
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test_0309( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test_0309( 2 -> 335 )")]
        public int Test_0309(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Bʹ_With(Plus(100)))     // 1 -> 112
                .If(Bʹ_Is(Odd))
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))  // 2 -> 335
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
                 From_A_To_A_With(Plus(1))                  // 2 -> 3
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))        // 1 -> 4
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Plus(3)))    // 999 -> 1005
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
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))           // 1 -> 12
                .If(A_Is(Odd))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))       // 2 -> 35
                    .If(A_Is(MoreThen(100)))
                        .Then(From_A_To_A_With(Plus(20)))
                        .Then(From_A_To_A_With(Plus(21)))   // 68 -> 142
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
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))
                .Then(From_A_To_A_With(Plus(100)))          // 2 -> 113
                .If(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))
                    .Then(From_A_To_A_With(Plus(200)))      // 1 -> 334
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Plus(3)))
                        .Then(From_A_To_A_With(Plus(30)))
                        .Then(From_A_To_A_With(Plus(300)))  // 1001 -> 1667
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
                 From_A_To_B_With(Plus(1))                  // 2 -> 3 
                .If(B_Is(Even))
                    .Then(From_B_To_Bʹ_With(Plus(2)))       // 1 -> 4
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Plus(3)))   // 999 -> 1005
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
                 From_A_To_D_With(Plus(1))
                .Then(From_D_To_C_With(Plus(10)))           // 1 -> 12
                .If(C_Is(Odd))
                    .Then(From_C_To_D_With(Plus(2)))
                    .Then(From_D_To_C_With(Plus(20)))       // 2 -> 35
                    .If(C_Is(MoreThen(100)))
                        .Then(From_C_To_A_With(Plus(20)))
                        .Then(From_A_To_Cʹ_With(Plus(21)))  // 68 -> 142
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
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_C_With(Plus(100)))          // 2 -> 113
                .If(C_Is(Even))
                    .Then(From_C_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_Cʹ_With(Plus(200)))     // 1 -> 334
                    .If(Cʹ_Is(MoreThen(1000)))
                        .Then(From_Cʹ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_Cʹ_With(Plus(300))) // 1001 -> 1667
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
                 From_A_To_Aʹ_With(Plus(1))                 // 1 -> 2
                .If(Aʹ_Is(Odd))
                    .Then(From_Aʹ_To_A_With(Plus(2)))       // 2 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Plus(3)))    // 10 -> 16
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
                 From_A_To_Aʹ_With(Plus(1))                 // 1 -> 2
                .If(Aʹ_Is(Odd))
                    .Then(From_Aʹ_To_A_With(Plus(2)))       // 2 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Plus(3)))   // 10 -> 16
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
                 From_A_To_Bʹ_With(Plus(1))                 // 2 -> 3
                .If(B_Is(Even))
                    .Then(From_B_To_B_With(Plus(2)))        // 1 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_B_With(Plus(3)))    // 999 -> 1005
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
                 From_A_To_B_With(Plus(1))                  // 2 -> 3
                .If(B_Is(Even))
                    .Then(From_B_To_Bʹ_With(Plus(2)))       // 1 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_Bʹ_To_B_With(Plus(3)))   // 999 -> 1005
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
                  From_A_To_E_With(Plus(1))
                 .Then(From_E_To_D_With(Plus(10)))
                 .Then(From_D_To_Bʹ_With(Plus(100)))        // 2 -> 113
                 .If(Bʹ_Is(Even))
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))      // 1 -> 334
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_B_With(Plus(300)))  // 1001 -> 1667
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
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Bʹ_With(Plus(100)))         // 2 -> 113
                .If(Bʹ_Is(Even))
                    .Then(From_Bʹ_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))      // 1 -> 334
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_Bʹ_With(Plus(300))) // 1001 -> 1667
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }
    }
}
