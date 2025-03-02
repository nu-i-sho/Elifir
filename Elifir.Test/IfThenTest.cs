namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class IfThenTest
    {
        [TestCase(1, ExpectedResult = 1, TestName = "Test60( 1 -> 1 )")]
        [TestCase(2, ExpectedResult = 4, TestName = "Test60( 2 -> 4 )")]
        public int Test60(int x)
        {
            var f =
                 If(A_Is(Even))                         // 1 -> 1
                    .Then(From_A_To_A_With(Plus(2)))    // 2 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 1,  TestName = "Test61( 1 -> 1 )")]
        [TestCase(8, ExpectedResult = 30, TestName = "Test61( 8 -> 30 )")]
        public int Test61(int x)
        {
            var f =
                 If(A_Is(Even))                         // 1 -> 1
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))   // 8 -> 30
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 11,  TestName = "Test62( 11 -> 11 )")]
        [TestCase(22, ExpectedResult = 244, TestName = "Test62( 22 -> 244 )")]
        public int Test62(int x)
        {
            var f =
                 If(A_Is(Even))                         // 11 -> 11
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))
                    .Then(From_A_To_A_With(Plus(200)))  // 22 -> 244
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 11,  TestName = "Test63( 11 -> 11 )")]
        [TestCase(22, ExpectedResult = 244, TestName = "Test63( 22 -> 244 )")]
        public int Test63(int x)
        {
            var f =
                 If(D_Is(Even))                         // 11 -> 11
                    .Then(From_D_To_C_With(Plus(2)))
                    .Then(From_C_To_E_With(Plus(20)))
                    .Then(From_E_To_D_With(Plus(200)))  // 22 -> 244
                .End();

            D result = f(new D(x));

            return result.Value;
        }

        [TestCase(8, ExpectedResult = 8, TestName = "Test64( 8 -> 8 )")]
        [TestCase(9, ExpectedResult = 11, TestName = "Test64( 9 -> 11 )")]
        public int Test64(int x)
        {
            var f =
                 If(A_Is(Odd))                          // 9 -> 11
                    .Then(From_A_To_Aʹ_With(Plus(2)))   // 8 -> 10
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(99,  ExpectedResult = 99,  TestName = "Test65( 99 -> 99 )")]
        [TestCase(101, ExpectedResult = 123, TestName = "Test65( 101 -> 123 )")]
        public int Test65(int x)
        {
            var f =
                 If(A_Is(MoreThen(100)))                // 99 -> 99
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_Aʹ_With(Plus(20)))  // 101 -> 123
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 10,  TestName = "Test66( 10 -> 10 )")]
        [TestCase(11, ExpectedResult = 233, TestName = "Test66( 11 -> 233 )")]
        public int Test66(int x)
        {
            var f =
                 If(B_Is(Odd))                          // 11 -> 233
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_Bʹ_With(Plus(200))) // 2 -> 335
                .End();

            B result = f(new B(x));

            return result.Value;
        }


        [TestCase(1, ExpectedResult = 1, TestName = "Test67( 1 -> 1 )")]
        [TestCase(2, ExpectedResult = 4, TestName = "Test67( 2 -> 4 )")]
        public int Test67(int x)
        {
            var f =
                 If(Aʹ_Is(Even))                         // 1 -> 1
                    .Then(From_Aʹ_To_A_With(Plus(2)))    // 2 -> 4
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 2,  TestName = "Test68( 2 -> 2 )")]
        [TestCase(9, ExpectedResult = 31, TestName = "Test68( 9 -> 31 )")]
        public int Test68(int x)
        {
            var f =
                 If(Aʹ_Is(Odd))                         // 2 -> 2
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))   // 9 -> 31
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(8, ExpectedResult = 8,   TestName = "Test69( 8 -> 8 )")]
        [TestCase(3, ExpectedResult = 225, TestName = "Test69( 3 -> 225 )")]
        public int Test69(int x)
        {
            var f =
                 If(Bʹ_Is(Odd))                         // 8 -> 8
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))  // 3 -> 225
                .End();
            
            B result = f(new Bʹ(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test70( 1 -> 1 )")]
        [TestCase(2,    ExpectedResult = 4,    TestName = "Test70( 2 -> 4 )")]
        [TestCase(1000, ExpectedResult = 1005, TestName = "Test70( 1000 -> 1005 )")]
        public int Test70(int x)
        {
            var f =
                 If(A_Is(Even))                             // 1 -> 1
                    .Then(From_A_To_A_With(Plus(2)))        // 2 -> 4
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Plus(3)))    // 1000 -> 1005
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(6,  ExpectedResult = 6,   TestName = "Test72( 6 -> 6 )")]
        [TestCase(7,  ExpectedResult = 29,  TestName = "Test72( 7 -> 29 )")]
        [TestCase(81, ExpectedResult = 144, TestName = "Test72( 81 -> 143 )")]
        public int Test72(int x)
        {
            var f =
                 If(A_Is(Odd))                              // 6 -> 6
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))       // 7 -> 29
                    .If(A_Is(MoreThen(100)))
                        .Then(From_A_To_A_With(Plus(20)))
                        .Then(From_A_To_A_With(Plus(21)))   // 81 -> 144
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(33,  ExpectedResult = 33,   TestName = "Test73( 33 -> 33 )")]
        [TestCase(34,  ExpectedResult = 256,  TestName = "Test73( 34 -> 256 )")]
        [TestCase(800, ExpectedResult = 1355, TestName = "Test73( 800 -> 1355 )")]
        public int Test73(int x)
        {
            var f =
                 If(A_Is(Even))                             // 33 -> 33
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))
                    .Then(From_A_To_A_With(Plus(200)))      // 34 -> 256 
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Plus(3)))
                        .Then(From_A_To_A_With(Plus(30)))
                        .Then(From_A_To_A_With(Plus(300)))  // 800 -> 1355
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(7,    ExpectedResult = 7,    TestName = "Test74( 7 -> 7 )")]
        [TestCase(8,    ExpectedResult = 10,   TestName = "Test74( 8 -> 10 )")]
        [TestCase(1200, ExpectedResult = 1205, TestName = "Test74( 1200 -> 1205 )")]
        public int Test74(int x)
        {
            var f =
                 If(B_Is(Even))                             // 7 -> 7
                    .Then(From_B_To_Bʹ_With(Plus(2)))       // 8 -> 10
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Plus(3)))   // 1200 -> 1205
                    .End()
                .End();

            B result = f(new B(x));

            return result.Value;
        }

        [TestCase(6,  ExpectedResult = 6,   TestName = "Test75( 6 -> 6 )")]
        [TestCase(5,  ExpectedResult = 27,  TestName = "Test75( 5 -> 27 )")]
        [TestCase(89, ExpectedResult = 152, TestName = "Test75( 89 -> 152 )")]
        public int Test75(int x)
        {
            var f =
                 If(C_Is(Odd))                              // 6 -> 6
                    .Then(From_C_To_D_With(Plus(2)))
                    .Then(From_D_To_C_With(Plus(20)))       // 5 -> 27
                    .If(C_Is(MoreThen(100)))
                        .Then(From_C_To_A_With(Plus(20)))
                        .Then(From_A_To_Cʹ_With(Plus(21)))  // 89 -> 152
                    .End()
                .End();

            C result = f(new C(x));

            return result.Value;
        }

        [TestCase(999, ExpectedResult = 999,  TestName = "Test76( 999 -> 999 )")]
        [TestCase(666, ExpectedResult = 888,  TestName = "Test76( 666 -> 888 )")]
        [TestCase(888, ExpectedResult = 1443, TestName = "Test76( 888 -> 1443 )")]
        public int Test76(int x)
        {
            var f =
                 If(C_Is(Even))                             // 999 -> 999
                    .Then(From_C_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_Cʹ_With(Plus(200)))     // 666 -> 888
                    .If(Cʹ_Is(MoreThen(1000)))
                        .Then(From_Cʹ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_Cʹ_With(Plus(300))) // 888 -> 1443
                    .End()
                .End();

            C result = f(new C(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 2,  TestName = "Test77( 2 -> 2 )")]
        [TestCase(3, ExpectedResult = 5,  TestName = "Test77( 3 -> 5 )")]
        [TestCase(9, ExpectedResult = 14, TestName = "Test77( 9 -> 14 )")]
        public int Test77(int x)
        {
            var f =
                 If(Aʹ_Is(Odd))                             // 2 -> 2
                    .Then(From_Aʹ_To_A_With(Plus(2)))       // 3 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Plus(3)))    // 10 -> 14
                    .End()
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }


        [TestCase(2, ExpectedResult = 2,  TestName = "Test78( 2 -> 2 )")]
        [TestCase(3, ExpectedResult = 5,  TestName = "Test78( 3 -> 5 )")]
        [TestCase(9, ExpectedResult = 14, TestName = "Test78( 9 -> 14 )")]
        public int Test78(int x)
        {
            var f =
                 If(Aʹ_Is(Odd))                             // 2 -> 2
                    .Then(From_Aʹ_To_A_With(Plus(2)))       // 3 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Plus(3)))   // 10 -> 14
                   .End()
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test79( 1 -> 1 )")]
        [TestCase(2,    ExpectedResult = 4,    TestName = "Test79( 2 -> 4 )")]
        [TestCase(1400, ExpectedResult = 1405, TestName = "Test79( 1400 -> 1405 )")]
        public int Test79(int x)
        {
            var f =
                 If(B_Is(Even))                             // 1 -> 1
                    .Then(From_B_To_B_With(Plus(2)))        // 2 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_B_With(Plus(3)))    // 1400 -> 1405
                    .End()
                .End();

            B result = f(new B(x));

            return result.Value;
        }

        [TestCase(113,  ExpectedResult = 113,  TestName = "Test80( 113 -> 113 )")]
        [TestCase(20,   ExpectedResult = 242,  TestName = "Test80( 20 -> 242 )")]
        [TestCase(1002, ExpectedResult = 1557, TestName = "Test80( 1002 -> 1557 )")]
        public int Test80(int x)
        {
            var f =
                  If(Bʹ_Is(Even))                           // 113 -> 113
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))      // 20 -> 242
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_B_With(Plus(300)))  // 1002 -> 1557
                    .End()
                .End();

            B result = f(new Bʹ(x));

            return result.Value;
        }

        [TestCase(113,  ExpectedResult = 113,  TestName = "Test81( 113 -> 113 )")]
        [TestCase(20,   ExpectedResult = 242,  TestName = "Test81( 20 -> 242 )")]
        [TestCase(1002, ExpectedResult = 1557, TestName = "Test81( 1002 -> 1557 )")]
        public int Test81(int x)
        {
            var f =
                 If(Bʹ_Is(Even))                            // 113 -> 113
                    .Then(From_Bʹ_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))      // 20 -> 242
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_Bʹ_With(Plus(300))) // 1002 -> 1557
                    .End()
                .End();

            B result = f(new Bʹ(x));

            return result.Value;
        }
    }
}
