namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class ThenIfTest
    {
        [TestCase(2, ExpectedResult = 3, TestName = "Test5( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test5( 1 -> 4 )")]
        public int Test05(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))              // 2 -> 3
                .ThenIf(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 13, TestName = "Test6( 2 -> 13 )")]
        [TestCase(1, ExpectedResult = 34, TestName = "Test6( 1 -> 34 )")]
        public int Test06(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))       // 2 -> 13
                .ThenIf(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))   // 1 -> 34
                .End();


            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test7( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test7( 2 -> 335 )")]
        public int Test07(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))
                .Then(From_A_To_A_With(Plus(100)))      // 1 -> 112
                .ThenIf(A_Is(Odd))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))
                    .Then(From_A_To_A_With(Plus(200)))  // 2 -> 335
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 113, TestName = "Test8( 2 -> 113 )")]
        [TestCase(1, ExpectedResult = 334, TestName = "Test8( 1 -> 334 )")]
        public int Test08(int x)
        {
            var f =
                 From_A_To_B_With(Plus(1))
                .Then(From_B_To_C_With(Plus(10)))
                .Then(From_C_To_D_With(Plus(100)))      // 2 -> 113
                .ThenIf(D_Is(Even))
                    .Then(From_D_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_D_With(Plus(200)))  // 1 -> 334
                .End();

            D result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 2, TestName = "Test9( 1 -> 2 )")]
        [TestCase(2, ExpectedResult = 5, TestName = "Test9( 2 -> 5 )")]
        public int Test09(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))              // 1 -> 2
                .ThenIf(A_Is(Odd))
                    .Then(From_A_To_Aʹ_With(Plus(2)))   // 2 -> 5
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 21,  TestName = "Test10( 10 -> 21 )")]
        [TestCase(90, ExpectedResult = 123, TestName = "Test10( 90 -> 123 )")]
        public int Test10(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))       // 10 -> 21
                .ThenIf(A_Is(MoreThen(100)))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_Aʹ_With(Plus(20)))  // 90 -> 123
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test11( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test11( 2 -> 335 )")]
        public int Test11(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_B_With(Plus(100)))      // 1 -> 112
                .ThenIf(B_Is(Odd))
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_Bʹ_With(Plus(200))) // 2 -> 335
                .End();

            B result = f(new A(x));

            return result.Value;
        }


        [TestCase(2, ExpectedResult = 3, TestName = "Test12( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test12( 1 -> 4 )")]
        public int Test12(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Plus(1))             // 2 -> 3
                .ThenIf(Aʹ_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 12, TestName = "Test13( 1 -> 12 )")]
        [TestCase(2, ExpectedResult = 35, TestName = "Test13( 2 -> 35 )")]
        public int Test13(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_Aʹ_With(Plus(10)))      // 1 -> 12
                .ThenIf(Aʹ_Is(Odd))
                    .Then(From_A_To_A_With(Plus(2)))
                    .Then(From_A_To_A_With(Plus(20)))   // 2 -> 35
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 112, TestName = "Test14( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test14( 2 -> 335 )")]
        public int Test14(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Bʹ_With(Plus(100)))     // 1 -> 112
                .ThenIf(Bʹ_Is(Odd))
                    .Then(From_B_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_B_With(Plus(200)))  // 2 -> 335
                .End();
            
            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test15( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test15( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test15( 999 -> 1005 )")]
        public int Test15(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))                  // 2 -> 3
                .ThenIf(A_Is(Even))
                    .Then(From_A_To_A_With(Plus(2)))        // 1 -> 4
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Plus(3)))    // 999 -> 1005
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test16( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test16( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test16( 68 -> 142 )")]
        public int Test16(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))           // 1 -> 12
                .ThenIf(A_Is(Odd))
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test17( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test17( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test17( 1001 -> 1667 )")]
        public int Test17(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .Then(From_A_To_A_With(Plus(10)))
                .Then(From_A_To_A_With(Plus(100)))          // 2 -> 113
                .ThenIf(A_Is(Even))
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test18( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test18( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test18( 999 -> 1005 )")]
        public int Test18(int x)
        {
            var f =
                 From_A_To_B_With(Plus(1))                  // 2 -> 3 
                .ThenIf(B_Is(Even))
                    .Then(From_B_To_Bʹ_With(Plus(2)))       // 1 -> 4
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Plus(3)))   // 999 -> 1005
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test19( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test19( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test19( 68 -> 142 )")]
        public int Test19(int x)
        {
            var f =
                 From_A_To_D_With(Plus(1))
                .Then(From_D_To_C_With(Plus(10)))           // 1 -> 12
                .ThenIf(C_Is(Odd))
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test20( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test20( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test20( 1001 -> 1667 )")]
        public int Test20(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_C_With(Plus(100)))          // 2 -> 113
                .ThenIf(C_Is(Even))
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test21( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test21( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test21( 10 -> 16 )")]
        public int Test21(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Plus(1))                 // 1 -> 2
                .ThenIf(Aʹ_Is(Odd))
                    .Then(From_Aʹ_To_A_With(Plus(2)))       // 2 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Plus(3)))    // 10 -> 16
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }


        [TestCase(1,  ExpectedResult = 2,  TestName = "Test22( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test22( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test22( 10 -> 16 )")]
        public int Test22(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Plus(1))                 // 1 -> 2
                .ThenIf(Aʹ_Is(Odd))
                    .Then(From_Aʹ_To_A_With(Plus(2)))       // 2 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Plus(3)))   // 10 -> 16
                   .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test23( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test23( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test23( 999 -> 1005 )")]
        public int Test23(int x)
        {
            var f =
                 From_A_To_Bʹ_With(Plus(1))                 // 2 -> 3
                .ThenIf(B_Is(Even))
                    .Then(From_B_To_B_With(Plus(2)))        // 1 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_B_With(Plus(3)))    // 999 -> 1005
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test24( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test24( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test24( 999 -> 1005 )")]
        public int Test24(int x)
        {
            var f =
                 From_A_To_B_With(Plus(1))                  // 2 -> 3
                .ThenIf(B_Is(Even))
                    .Then(From_B_To_Bʹ_With(Plus(2)))       // 1 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_Bʹ_To_B_With(Plus(3)))   // 999 -> 1005
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test25( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test25( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test25( 1001 -> 1667 )")]
        public int Test25(int x)
        {
            var f =
                  From_A_To_E_With(Plus(1))
                 .Then(From_E_To_D_With(Plus(10)))
                 .Then(From_D_To_Bʹ_With(Plus(100)))        // 2 -> 113
                 .ThenIf(Bʹ_Is(Even))
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test26( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test26( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test26( 1001 -> 1667 )")]
        public int Test26(int x)
        {
            var f =
                 From_A_To_E_With(Plus(1))
                .Then(From_E_To_D_With(Plus(10)))
                .Then(From_D_To_Bʹ_With(Plus(100)))         // 2 -> 113
                .ThenIf(Bʹ_Is(Even))
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test27( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 4,  TestName = "Test27( 2 -> 4 )")]
        [TestCase(3,  ExpectedResult = 6,  TestName = "Test27( 3 -> 6 )")]
        [TestCase(4,  ExpectedResult = 8,  TestName = "Test27( 4 -> 8 )")]
        [TestCase(5,  ExpectedResult = 10, TestName = "Test27( 5 -> 10 )")]
        [TestCase(6,  ExpectedResult = 12, TestName = "Test27( 6 -> 12 )")]
        [TestCase(7,  ExpectedResult = 14, TestName = "Test27( 7 -> 14 )")]
        [TestCase(8,  ExpectedResult = 16, TestName = "Test27( 8 -> 16 )")]
        [TestCase(9,  ExpectedResult = 18, TestName = "Test27( 9 -> 18 )")]
        [TestCase(10, ExpectedResult = 20, TestName = "Test27( 10 -> 20 )")]
        [TestCase(11, ExpectedResult = 22, TestName = "Test27( 11 -> 22 )")]
        public int Test27(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))  // 1 -> 2     
                .ThenIf(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Plus(1)))  // 2 -> 3
                    .If(A_Is(MoreThen(4)))
                        .Then(From_A_To_A_With(Plus(1))) // 3 -> 6
                        .If(A_Is(MoreThen(6)))
                            .Then(From_A_To_A_With(Plus(1))) // 4 -> 8
                            .If(A_Is(MoreThen(8)))
                                .Then(From_A_To_A_With(Plus(1))) // 5 -> 10  
                                .If(A_Is(MoreThen(10)))
                                    .Then(From_A_To_A_With(Plus(1))) // 6 -> 12
                                    .If(A_Is(MoreThen(12)))
                                        .Then(From_A_To_A_With(Plus(1))) // 7 -> 14
                                        .If(A_Is(MoreThen(14)))
                                            .Then(From_A_To_A_With(Plus(1))) // 8 -> 16
                                            .If(A_Is(MoreThen(16)))
                                                .Then(From_A_To_A_With(Plus(1))) // 9 -> 18
                                                .If(A_Is(MoreThen(18)))
                                                    .Then(From_A_To_A_With(Plus(1))) // 10 -> 20
                                                    .If(A_Is(MoreThen(20)))
                                                        .Then(From_A_To_A_With(Plus(1))) // 11 -> 22
                                                    .End()
                                                .End()
                                            .End()
                                        .End()
                                    .End()
                                .End()
                            .End()
                        .End()
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }
    }
}
