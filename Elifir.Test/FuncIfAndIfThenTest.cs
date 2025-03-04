namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class FuncIfAndIfThenTest
    {
        [TestCase(2,   ExpectedResult = 3,   TestName = "Test130( 2 -> 3 )")]
        [TestCase(8,   ExpectedResult = 9,   TestName = "Test130( 8 -> 9 )")]
        [TestCase(100, ExpectedResult = 101, TestName = "Test130( 100 -> 101 )")]
        [TestCase(11,  ExpectedResult = 14,  TestName = "Test130( 11 -> 14 )")]
        public int Test130(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))                  // 2 -> 3, 8 -> 9, 100 -> 101
                .If(A_Is(Even)).AndIf(A_Is(MoreThen(10)))
                    .Then(From_A_To_A_With(Add(2)))        // 11 -> 14
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(0,   ExpectedResult = 11,  TestName = "Test131( 0 -> 11 )")]
        [TestCase(1,   ExpectedResult = 12,  TestName = "Test131( 1 -> 12 )")]
        [TestCase(110, ExpectedResult = 121, TestName = "Test131( 110 -> 121 )")]
        [TestCase(111, ExpectedResult = 144, TestName = "Test131( 111 -> 144 )")]
        public int Test131(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))           // 0 -> 11, 1 -> 12, 110 -> 121
                .If(A_Is(Even)).AndIf(A_Is(MoreThen(50)))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))       // 111 -> 144
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(53,  ExpectedResult = 56,  TestName = "Test132( 53 -> 56 )")]
        [TestCase(1,   ExpectedResult = 4,   TestName = "Test132( 1 -> 4 )")]
        [TestCase(110, ExpectedResult = 113, TestName = "Test132( 110 -> 113 )")]
        [TestCase(70,  ExpectedResult = 295, TestName = "Test132( 70 -> 295 )")]
        public int Test132(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(1)))
                .Then(From_A_To_A_With(Add(1)))      
                .If(A_Is(Odd))                          // 53 -> 56
                .AndIf(A_Is(MoreThen(50)))              // 1 -> 4
                .AndIf(A_Is(LessThen(100)))             // 110 -> 113
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))   // 70 -> 295
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(true,  1, ExpectedResult = 334, TestName = "Test133( true, 1 -> 334 )")]
        [TestCase(false, 1, ExpectedResult = 112, TestName = "Test133( false, 1 -> 112 )")]
        [TestCase(true,  2, ExpectedResult = 113, TestName = "Test133( true, 1 -> 113 )")]
        [TestCase(false, 2, ExpectedResult = 113, TestName = "Test133( false, 1 -> 113 )")]
        public int Test133(bool isCʹ, int x)
        {
            var from_D_To_C_OrTo_Cʹ_With =
                From_D_To_C_OrTo_Cʹ(isCʹ);

            var f =
                 From_A_To_B_With(Add(1))
                .Then(From_B_To_D_With(Add(10)))
                .Then(from_D_To_C_OrTo_Cʹ_With(Add(100)))
                .If(C_Is(Even))                             // (false, 2) -> 113, (true, 2) -> 113
                .AndIf(Object<C>.Is<Cʹ>)                    // (false, 1) -> 334
                    .Then(From_Cʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_C_With(Add(200)))       // (true, 1) -> 334
                .End();

            C result = f(new A(x));

            return result.Value;
        }

        //[TestCase(1, ExpectedResult = 2, TestName = "Test9( 1 -> 2 )")]
        //[TestCase(2, ExpectedResult = 5, TestName = "Test9( 2 -> 5 )")]
        public int Test134(bool isAʹ, int x)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                isAʹ ? From_A_To_Aʹ_With
                     : From_A_To_Aʹ_With;

            var f =
                 From_A_To_A_With(Add(1))              // 1 -> 2
                .If(A_Is(Odd))
                    .Then(From_A_To_Aʹ_With(Add(2)))   // 2 -> 5
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 21,  TestName = "Test10( 10 -> 21 )")]
        [TestCase(90, ExpectedResult = 123, TestName = "Test10( 90 -> 123 )")]
        public int Test10(int x)
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

        [TestCase(1, ExpectedResult = 112, TestName = "Test11( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test11( 2 -> 335 )")]
        public int Test11(int x)
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


        [TestCase(2, ExpectedResult = 3, TestName = "Test12( 2 -> 3 )")]
        [TestCase(1, ExpectedResult = 4, TestName = "Test12( 1 -> 4 )")]
        public int Test12(int x)
        {
            var f =
                 From_A_To_Aʹ_With(Add(1))             // 2 -> 3
                .If(Aʹ_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))    // 1 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 12, TestName = "Test13( 1 -> 12 )")]
        [TestCase(2, ExpectedResult = 35, TestName = "Test13( 2 -> 35 )")]
        public int Test13(int x)
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

        [TestCase(1, ExpectedResult = 112, TestName = "Test14( 1 -> 112 )")]
        [TestCase(2, ExpectedResult = 335, TestName = "Test14( 2 -> 335 )")]
        public int Test14(int x)
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test15( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test15( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test15( 999 -> 1005 )")]
        public int Test15(int x)
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

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test16( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test16( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test16( 68 -> 142 )")]
        public int Test16(int x)
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test17( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test17( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test17( 1001 -> 1667 )")]
        public int Test17(int x)
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test18( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test18( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test18( 999 -> 1005 )")]
        public int Test18(int x)
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

        [TestCase(1,  ExpectedResult = 12,  TestName = "Test19( 1 -> 12 )")]
        [TestCase(2,  ExpectedResult = 35,  TestName = "Test19( 2 -> 35 )")]
        [TestCase(68, ExpectedResult = 142, TestName = "Test19( 68 -> 142 )")]
        public int Test19(int x)
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test20( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test20( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test20( 1001 -> 1667 )")]
        public int Test20(int x)
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test21( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test21( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test21( 10 -> 16 )")]
        public int Test21(int x)
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


        [TestCase(1,  ExpectedResult = 2,  TestName = "Test22( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 5,  TestName = "Test22( 2 -> 5 )")]
        [TestCase(10, ExpectedResult = 16, TestName = "Test22( 10 -> 16 )")]
        public int Test22(int x)
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test23( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test23( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test23( 999 -> 1005 )")]
        public int Test23(int x)
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

        [TestCase(2,   ExpectedResult = 3,    TestName = "Test24( 2 -> 3 )")]
        [TestCase(1,   ExpectedResult = 4,    TestName = "Test24( 1 -> 4 )")]
        [TestCase(999, ExpectedResult = 1005, TestName = "Test24( 999 -> 1005 )")]
        public int Test24(int x)
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test25( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test25( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test25( 1001 -> 1667 )")]
        public int Test25(int x)
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

        [TestCase(2,    ExpectedResult = 113,  TestName = "Test26( 2 -> 113 )")]
        [TestCase(1,    ExpectedResult = 334,  TestName = "Test26( 1 -> 334 )")]
        [TestCase(1001, ExpectedResult = 1667, TestName = "Test26( 1001 -> 1667 )")]
        public int Test26(int x)
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
    }
}
