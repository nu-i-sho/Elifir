namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class IfThenTest
    {
        [TestCase(1, ExpectedResult = 1, TestName = "Test_0101( 1 -> 1 )")]
        [TestCase(2, ExpectedResult = 4, TestName = "Test_0101( 2 -> 4 )")]
        public int Test_0101(int x)
        {
            var f =
                 If(A_Is(Even))                         // 1 -> 1
                    .Then(From_A_To_A_With(Add(2)))     // 2 -> 4
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 1,  TestName = "Test_0102( 1 -> 1 )")]
        [TestCase(8, ExpectedResult = 30, TestName = "Test_0102( 8 -> 30 )")]
        public int Test_0102(int x)
        {
            var f =
                 If(A_Is(Even))                         // 1 -> 1
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))    // 8 -> 30
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 11,  TestName = "Test_0103( 11 -> 11 )")]
        [TestCase(22, ExpectedResult = 244, TestName = "Test_0103( 22 -> 244 )")]
        public int Test_0103(int x)
        {
            var f =
                 If(A_Is(Even))                         // 11 -> 11
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))   // 22 -> 244
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 11,  TestName = "Test_0104( 11 -> 11 )")]
        [TestCase(22, ExpectedResult = 244, TestName = "Test_0104( 22 -> 244 )")]
        public int Test_0104(int x)
        {
            var f =
                 If(D_Is(Even))                         // 11 -> 11
                    .Then(From_D_To_C_With(Add(2)))
                    .Then(From_C_To_E_With(Add(20)))
                    .Then(From_E_To_D_With(Add(200)))   // 22 -> 244
                .End();

            D result = f(new D(x));

            return result.Value;
        }

        [TestCase(8, ExpectedResult = 8,  TestName = "Test_0105( 8 -> 8 )")]
        [TestCase(9, ExpectedResult = 11, TestName = "Test_0105( 9 -> 11 )")]
        public int Test_0105(int x)
        {
            var f =
                 If(A_Is(Odd))                          // 9 -> 11
                    .Then(From_A_To_Aʹ_With(Add(2)))    // 8 -> 10
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(99,  ExpectedResult = 99,  TestName = "Test_0106( 99 -> 99 )")]
        [TestCase(101, ExpectedResult = 123, TestName = "Test_0106( 101 -> 123 )")]
        public int Test_0106(int x)
        {
            var f =
                 If(A_Is(MoreThen(100)))                // 99 -> 99
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_Aʹ_With(Add(20)))   // 101 -> 123
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 10,  TestName = "Test_0107( 10 -> 10 )")]
        [TestCase(11, ExpectedResult = 233, TestName = "Test_0107( 11 -> 233 )")]
        public int Test_0107(int x)
        {
            var f =
                 If(B_Is(Odd))                          // 11 -> 233
                    .Then(From_B_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Bʹ_With(Add(200)))  // 2 -> 335
                .End();

            B result = f(new B(x));

            return result.Value;
        }


        [TestCase(1, ExpectedResult = 1, TestName = "Test_0108( 1 -> 1 )")]
        [TestCase(2, ExpectedResult = 4, TestName = "Test_0108( 2 -> 4 )")]
        public int Test_0108(int x)
        {
            var f =
                 If(Aʹ_Is(Even))                        // 1 -> 1
                    .Then(From_Aʹ_To_A_With(Add(2)))    // 2 -> 4
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 2,  TestName = "Test_0109( 2 -> 2 )")]
        [TestCase(9, ExpectedResult = 31, TestName = "Test_0109( 9 -> 31 )")]
        public int Test_0109(int x)
        {
            var f =
                 If(Aʹ_Is(Odd))                         // 2 -> 2
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))    // 9 -> 31
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(8, ExpectedResult = 8,   TestName = "Test_0110( 8 -> 8 )")]
        [TestCase(3, ExpectedResult = 225, TestName = "Test_0110( 3 -> 225 )")]
        public int Test_0110(int x)
        {
            var f =
                 If(Bʹ_Is(Odd))                         // 8 -> 8
                    .Then(From_B_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_B_With(Add(200)))   // 3 -> 225
                .End();
            
            B result = f(new Bʹ(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test_0111( 1 -> 1 )")]
        [TestCase(2,    ExpectedResult = 4,    TestName = "Test_0111( 2 -> 4 )")]
        [TestCase(1000, ExpectedResult = 1005, TestName = "Test_0111( 1000 -> 1005 )")]
        public int Test_0111(int x)
        {
            var f =
                 If(A_Is(Even))                             // 1 -> 1
                    .Then(From_A_To_A_With(Add(2)))         // 2 -> 4
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Add(3)))     // 1000 -> 1005
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(6,  ExpectedResult = 6,   TestName = "Test_0112( 6 -> 6 )")]
        [TestCase(7,  ExpectedResult = 29,  TestName = "Test_0112( 7 -> 29 )")]
        [TestCase(81, ExpectedResult = 144, TestName = "Test_0112( 81 -> 143 )")]
        public int Test_0112(int x)
        {
            var f =
                 If(A_Is(Odd))                              // 6 -> 6
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))        // 7 -> 29
                    .If(A_Is(MoreThen(100)))
                        .Then(From_A_To_A_With(Add(20)))
                        .Then(From_A_To_A_With(Add(21)))    // 81 -> 144
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(33,  ExpectedResult = 33,   TestName = "Test_0113( 33 -> 33 )")]
        [TestCase(34,  ExpectedResult = 256,  TestName = "Test_0113( 34 -> 256 )")]
        [TestCase(800, ExpectedResult = 1355, TestName = "Test_0113( 800 -> 1355 )")]
        public int Test_0113(int x)
        {
            var f =
                 If(A_Is(Even))                             // 33 -> 33
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))       // 34 -> 256 
                    .If(A_Is(MoreThen(1000)))
                        .Then(From_A_To_A_With(Add(3)))
                        .Then(From_A_To_A_With(Add(30)))
                        .Then(From_A_To_A_With(Add(300)))   // 800 -> 1355
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(7,    ExpectedResult = 7,    TestName = "Test_0114( 7 -> 7 )")]
        [TestCase(8,    ExpectedResult = 10,   TestName = "Test_0114( 8 -> 10 )")]
        [TestCase(1200, ExpectedResult = 1205, TestName = "Test_0114( 1200 -> 1205 )")]
        public int Test_0114(int x)
        {
            var f =
                 If(B_Is(Even))                             // 7 -> 7
                    .Then(From_B_To_Bʹ_With(Add(2)))        // 8 -> 10
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Add(3)))    // 1200 -> 1205
                    .End()
                .End();

            B result = f(new B(x));

            return result.Value;
        }

        [TestCase(6,  ExpectedResult = 6,   TestName = "Test_0115( 6 -> 6 )")]
        [TestCase(5,  ExpectedResult = 27,  TestName = "Test_0115( 5 -> 27 )")]
        [TestCase(89, ExpectedResult = 152, TestName = "Test_0115( 89 -> 152 )")]
        public int Test_0115(int x)
        {
            var f =
                 If(C_Is(Odd))                              // 6 -> 6
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(From_D_To_C_With(Add(20)))        // 5 -> 27
                    .If(C_Is(MoreThen(100)))
                        .Then(From_C_To_A_With(Add(20)))
                        .Then(From_A_To_Cʹ_With(Add(21)))   // 89 -> 152
                    .End()
                .End();

            C result = f(new C(x));

            return result.Value;
        }

        [TestCase(999, ExpectedResult = 999,  TestName = "Test_0116( 999 -> 999 )")]
        [TestCase(666, ExpectedResult = 888,  TestName = "Test_0116( 666 -> 888 )")]
        [TestCase(888, ExpectedResult = 1443, TestName = "Test_0116( 888 -> 1443 )")]
        public int Test_0116(int x)
        {
            var f =
                 If(C_Is(Even))                             // 999 -> 999
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(From_D_To_B_With(Add(20)))
                    .Then(From_B_To_Cʹ_With(Add(200)))      // 666 -> 888
                    .If(Cʹ_Is(MoreThen(1000)))
                        .Then(From_Cʹ_To_B_With(Add(3)))
                        .Then(From_B_To_D_With(Add(30)))
                        .Then(From_D_To_Cʹ_With(Add(300)))  // 888 -> 1443
                    .End()
                .End();

            C result = f(new C(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 2,  TestName = "Test_0117( 2 -> 2 )")]
        [TestCase(3, ExpectedResult = 5,  TestName = "Test_0117( 3 -> 5 )")]
        [TestCase(9, ExpectedResult = 14, TestName = "Test_0117( 9 -> 14 )")]
        public int Test_0117(int x)
        {
            var f =
                 If(Aʹ_Is(Odd))                             // 2 -> 2
                    .Then(From_Aʹ_To_A_With(Add(2)))        // 3 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Add(3)))     // 10 -> 14
                    .End()
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }


        [TestCase(2, ExpectedResult = 2,  TestName = "Test_0118( 2 -> 2 )")]
        [TestCase(3, ExpectedResult = 5,  TestName = "Test_0118( 3 -> 5 )")]
        [TestCase(9, ExpectedResult = 14, TestName = "Test_0118( 9 -> 14 )")]
        public int Test_0118(int x)
        {
            var f =
                 If(Aʹ_Is(Odd))                             // 2 -> 2
                    .Then(From_Aʹ_To_A_With(Add(2)))        // 3 -> 5
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Add(3)))    // 10 -> 14
                   .End()
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test_0119( 1 -> 1 )")]
        [TestCase(2,    ExpectedResult = 4,    TestName = "Test_0119( 2 -> 4 )")]
        [TestCase(1400, ExpectedResult = 1405, TestName = "Test_0119( 1400 -> 1405 )")]
        public int Test_0119(int x)
        {
            var f =
                 If(B_Is(Even))                             // 1 -> 1
                    .Then(From_B_To_B_With(Add(2)))         // 2 -> 4
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_B_With(Add(3)))     // 1400 -> 1405
                    .End()
                .End();

            B result = f(new B(x));

            return result.Value;
        }

        [TestCase(113,  ExpectedResult = 113,  TestName = "Test_0120( 113 -> 113 )")]
        [TestCase(20,   ExpectedResult = 242,  TestName = "Test_0120( 20 -> 242 )")]
        [TestCase(1002, ExpectedResult = 1557, TestName = "Test_0120( 1002 -> 1557 )")]
        public int Test_0120(int x)
        {
            var f =
                  If(Bʹ_Is(Even))                           // 113 -> 113
                    .Then(From_B_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_B_With(Add(200)))       // 20 -> 242
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_B_With(Add(300)))   // 1002 -> 1557
                    .End()
                .End();

            B result = f(new Bʹ(x));

            return result.Value;
        }

        [TestCase(113,  ExpectedResult = 113,  TestName = "Test_0121( 113 -> 113 )")]
        [TestCase(20,   ExpectedResult = 242,  TestName = "Test_0121( 20 -> 242 )")]
        [TestCase(1002, ExpectedResult = 1557, TestName = "Test_0121( 1002 -> 1557 )")]
        public int Test_0121(int x)
        {
            var f =
                 If(Bʹ_Is(Even))                            // 113 -> 113
                    .Then(From_Bʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_B_With(Add(200)))       // 20 -> 242
                    .If(B_Is(MoreThen(1000)))
                        .Then(From_B_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_Bʹ_With(Add(300)))  // 1002 -> 1557
                    .End()
                .End();

            B result = f(new Bʹ(x));

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 7, TestName = "Test_0122( false, 7 -> 7 )")]
        [TestCase(true,  ExpectedResult = 9, TestName = "Test_0122( true, 7 -> 9 )")]
        public int Test_0122(bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (false, 7) -> 7
                    .Then(From_A_To_A_With(Add(2)))     // (true, 7) -> 9
                .End();

            A arg = isAʹ 
                ? new Aʹ(7) 
                : new A(7);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 3,  TestName = "Test_0123( false, 3 -> 3 )")]
        [TestCase(true,  ExpectedResult = 25, TestName = "Test_0123( true, 3 -> 25 )")]
        public int Test_0123(bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (false, 3) -> 3
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))    // (true, 3) -> 25
                .End();

            A arg = isAʹ
                ? new Aʹ(3)
                : new A(3);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 50,  TestName = "Test_0124( false, 50 -> 50 )")]
        [TestCase(true,  ExpectedResult = 272, TestName = "Test_0124( true, 50 -> 272 )")]
        public int Test_0124(bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (false, 50) -> 50
                    .Then(From_Aʹ_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_Aʹ_With(Add(200)))  // (true, 50) -> 272
                .End();

            A arg = isAʹ
                ? new Aʹ(50)
                : new A(50);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 11, TestName = "Test_0125( false, 11 -> 11 )")]
        [TestCase(true,  ExpectedResult = 233, TestName = "Test_0125( true, 11 -> 233 )")]
        public int Test_0125(bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (false, 11) -> 11
                    .Then(From_Aʹ_To_C_With(Add(2)))
                    .Then(From_C_To_E_With(Add(20)))
                    .Then(From_E_To_A_With(Add(200)))   // (true, 11) -> 233
                .End();

            A arg = isAʹ
                ? new Aʹ(11)
                : new A(11);

            A result = f(arg);

            return result.Value;

        }

        [TestCase(false, ExpectedResult = 2, TestName = "Test_0126( false, 2 -> 2 )")]
        [TestCase(true,  ExpectedResult = 4, TestName = "Test_0126( true, 2 -> 4 )")]
        public int Test_0126(bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (false, 2) -> 2
                    .Then(From_Aʹ_To_Aʹ_With(Add(2)))   // (true, 2) -> 4
                .End();

            A arg = isAʹ
                ? new Aʹ(2)
                : new A(2);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 99,  TestName = "Test_0127( false, 99 -> 99 )")]
        [TestCase(true,  ExpectedResult = 121, TestName = "Test_0127( true, 99 -> 121 )")]
        public int Test_0127(bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (false, 99) -> 99
                    .Then(From_Aʹ_To_A_With(Add(2)))
                    .Then(From_A_To_Aʹ_With(Add(20)))   // (true, 99) -> 121
                .End();

            A arg = isAʹ
                ? new Aʹ(99)
                : new A(99);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 10,  TestName = "Test_0128( false, 10 -> 10 )")]
        [TestCase(true,  ExpectedResult = 232, TestName = "Test_0128( true, 10 -> 232 )")]
        public int Test_0128(bool isBʹ)
        {
            var f =
                 If(Object<B>.Is<Bʹ>)                   // (false, 10) -> 10
                    .Then(From_Bʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Bʹ_With(Add(200)))  // (true, 10) -> 232
                .End();

            B arg = isBʹ
                ? new Bʹ(10)
                : new B(10);

            B result = f(arg);

            return result.Value;
        }


        [TestCase(false, false, ExpectedResult = 1, TestName = "Test_0132( false, false, 1 -> 1 )")]
        [TestCase(false, true,  ExpectedResult = 1, TestName = "Test_0132( false, true, 1 -> 1 )")]
        [TestCase(true,  false, ExpectedResult = 3, TestName = "Test_0132( true, false, 1 -> 3 )")]
        [TestCase(true,  true,  ExpectedResult = 6, TestName = "Test_0132( true, true, 1 -> 6 )")]
        public int Test_0132(bool firstIsAʹ, bool secondIsAʹ)
        {
            var from_Aʹ_To_A_Or_To_Aʹ_With =
                From_Aʹ_To_A_OrTo_Aʹ(secondIsAʹ);

            var f =                                             // (false, true, 1) -> 1
                 If(Object<A>.Is<Aʹ>)                           // (false, true, 1) -> 1
                    .Then(from_Aʹ_To_A_Or_To_Aʹ_With(Add(2)))   // (true, false, 1) -> 3
                    .If(Object<A>.Is<Aʹ>)
                        .Then(From_A_To_A_With(Add(3)))         // (true, false, 1) -> 6
                    .End()
                .End();

            A arg = firstIsAʹ
                ? new Aʹ(1)
                : new A(1);

            A result = f(arg);

            return result.Value;
        }
        
        [TestCase(false, false, ExpectedResult = 7,  TestName = "Test_0133( false, false, 7 -> 7 )")]
        [TestCase(false, true,  ExpectedResult = 7,  TestName = "Test_0133( false, true, 7 -> 7 )")]
        [TestCase(true,  false, ExpectedResult = 29, TestName = "Test_0133( true, false, 7 -> 29 )")]
        [TestCase(true,  true,  ExpectedResult = 70, TestName = "Test_0133( true, true, 7 -> 70 )")]
        public int Test_0133(bool firstIsAʹ, bool secondIsAʹ)
        {
            var from_A_To_A_Or_To_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(secondIsAʹ);

            var f =                                             // (false, false, 7) -> 7
                 If(Object<A>.Is<Aʹ>)                           // (false, true,  7) -> 7
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(from_A_To_A_Or_To_Aʹ_With(Add(20)))   // (true, false, 7) -> 29
                    .If(Object<A>.Is<Aʹ>)
                        .Then(From_A_To_A_With(Add(20)))
                        .Then(From_A_To_A_With(Add(21)))        // (true, true, 7) -> 71
                    .End()
                .End();

            A arg = firstIsAʹ
                ? new Aʹ(7)
                : new A(7);

            A result = f(arg);

            return result.Value;
        }
        
        [TestCase(false, false, ExpectedResult = 7,   TestName = "Test_0134( false, false, 7 -> 7 )")]
        [TestCase(false, true,  ExpectedResult = 7,   TestName = "Test_0134( false, true, 7 -> 7 )")]
        [TestCase(true,  false, ExpectedResult = 229, TestName = "Test_0134( true, false, 7 -> 229 )")]
        [TestCase(true,  true,  ExpectedResult = 562, TestName = "Test_0134( true, true, 7 -> 562 )")]
        public int Test_0134(bool firstIsAʹ, bool secondIsAʹ)
        {
            var from_A_To_A_Or_To_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(secondIsAʹ);

            var f =                                             // (false, false, 7) -> 7
                 If(Object<A>.Is<Aʹ>)                           // (false, true,  7) -> 7
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(from_A_To_A_Or_To_Aʹ_With(Add(200)))  // (true, false, 7) -> 229
                    .If(Object<A>.Is<Aʹ>)
                        .Then(From_A_To_A_With(Add(3)))
                        .Then(From_A_To_A_With(Add(30)))
                        .Then(From_A_To_A_With(Add(300)))       // (true, true, 7) -> 562
                    .End()
                .End();

            A arg = firstIsAʹ
                ? new Aʹ(7)
                : new A(7);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, 2,    ExpectedResult = 2,    TestName = "Test_0135( false, 2 -> 2 )")]
        [TestCase(false, 2000, ExpectedResult = 2000, TestName = "Test_0135( false, 2000 -> 2000 )")]
        [TestCase(true,  2,    ExpectedResult = 4,    TestName = "Test_0135( true, 2 -> 4 )")]
        [TestCase(true,  2000, ExpectedResult = 2005, TestName = "Test_0134( true, 2000 -> 2005 )")]
        public int Test_0135(bool isBʹ, int x)
        {
            var f =                                         // (false, 2) -> 2
                 If(Object<B>.Is<Bʹ>)                       // (false, 2000) -> 2000
                    .Then(From_B_To_Bʹ_With(Add(2)))        // (true, 2) -> 4
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Add(3)))    // (true, 2000) -> 2005
                    .End()
                .End();

            B arg = isBʹ
                ? new Bʹ(x)
                : new B(x);

            var result = f(arg);

            return result.Value;
        }

        [TestCase(2, false, ExpectedResult = 2,  TestName = "Test_0136( 2, false -> 2 )")]
        [TestCase(2, true,  ExpectedResult = 2,  TestName = "Test_0136( 2, true -> 2 )")]
        [TestCase(3, false, ExpectedResult = 25, TestName = "Test_0136( 3, false -> 25 )")]
        [TestCase(3, true,  ExpectedResult = 66, TestName = "Test_0136( 3, true -> 66 )")]
        public int Test_0136(int x, bool secondIsCʹ)
        {
            var from_D_To_C_Or_To_Cʹ_With =
                From_D_To_C_OrTo_Cʹ(secondIsCʹ);

            var f =                                             // (2, false) -> 2
                 If(C_Is(Odd))                                  // (2, true) -> 2
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(from_D_To_C_Or_To_Cʹ_With(Add(20)))   // (3, false) -> 25
                    .If(Object<C>.Is<Cʹ>)
                        .Then(From_Cʹ_To_A_With(Add(20)))
                        .Then(From_A_To_Cʹ_With(Add(21)))       // (3, true) -> 66
                    .End()
                .End();

            C result = f(new C(x));

            return result.Value;
        }

        [TestCase(3, false, ExpectedResult = 3,   TestName = "Test_0137( 3, false -> 3 )")]
        [TestCase(3, true,  ExpectedResult = 3,   TestName = "Test_0137( 3, true -> 3 )")]
        [TestCase(2, false, ExpectedResult = 224, TestName = "Test_0137( 2, false -> 224 )")]
        [TestCase(2, true,  ExpectedResult = 557, TestName = "Test_0137( 3, true -> 557 )")]
        public int Test_0137(int x, bool secondIsCʹ)
        {
            var from_B_To_C_Or_To_Cʹ_With =
                From_B_To_C_OrTo_Cʹ(secondIsCʹ);

            var f =                                                 // (3, false) -> 3
                 If(C_Is(Even))                                     // (3, true) -> 3
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(From_D_To_B_With(Add(20)))
                    .Then(from_B_To_C_Or_To_Cʹ_With(Add(200)))      // (2, false) -> 224
                    .If(Object<C>.Is<Cʹ>)
                        .Then(From_Cʹ_To_B_With(Add(3)))
                        .Then(From_B_To_D_With(Add(30)))
                        .Then(From_D_To_Cʹ_With(Add(300)))          // (2, true) -> 557
                    .End()
                .End();

            C result = f(new C(x));

            return result.Value;
        }

        [TestCase(8, false, ExpectedResult = 8,  TestName = "Test_0138( 8, false -> 8 )")]
        [TestCase(8, true,  ExpectedResult = 8,  TestName = "Test_0138( 8, true -> 8 )")]
        [TestCase(5, false, ExpectedResult = 7,  TestName = "Test_0138( 5, false -> 7 )")]
        [TestCase(5, true,  ExpectedResult = 10, TestName = "Test_0138( 5, true -> 10 )")]
        public int Test_0138(int x, bool secondIsAʹ)
        {
            var from_Aʹ_To_A_Or_To_Aʹ_With =
                From_Aʹ_To_A_OrTo_Aʹ(secondIsAʹ);

            var f =                                             // (8, false) -> 8
                 If(Aʹ_Is(Odd))                                 // (8, true) -> 8
                    .Then(from_Aʹ_To_A_Or_To_Aʹ_With(Add(2)))   // (5, false) -> 7
                    .If(Object<A>.Is<Aʹ>)
                        .Then(From_A_To_A_With(Add(3)))         // (5, true) -> 10
                    .End()
                .End();

            A result = f(new Aʹ(x));

            return result.Value;
        }

        [TestCase(false, false, ExpectedResult = 54,  TestName = "Test_0141( 54, false, false -> 54 )")]
        [TestCase(false, true,  ExpectedResult = 54,  TestName = "Test_0141( 54, false, true -> 54 )")]
        [TestCase(true,  false, ExpectedResult = 276, TestName = "Test_0141( 54, true, false -> 276 )")]
        [TestCase(true,  true,  ExpectedResult = 609, TestName = "Test_0141( 54, true, true -> 609 )")]
        public int Test_0141(bool firstIsBʹ, bool secondIsBʹ)
        {
            var from_B_To_A_Or_To_Aʹ_With =
                From_B_To_B_OrTo_Bʹ(secondIsBʹ);

            var f =                                             // (54, false, false) -> 54
                  If(Object<B>.Is<Bʹ>)                          // (54, false, true) -> 54
                    .Then(From_Bʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(from_B_To_A_Or_To_Aʹ_With(Add(200)))  // (54, true, false) -> 276
                    .If(Object<B>.Is<Bʹ>)
                        .Then(From_B_To_E_With(Add(3)))
                        .Then(From_E_To_B_With(Add(30)))
                        .Then(From_B_To_B_With(Add(300)))       // (54, true, true) -> 609
                    .End()
                .End();


            B arg = firstIsBʹ
                ? new Bʹ(54)
                : new B(54);

            var result = f(arg);

            return result.Value;
        }

        [TestCase(49, ExpectedResult = 149, TestName = "Test_0150( 49 -> 149 )")]
        [TestCase(9,  ExpectedResult = 9,   TestName = "Test_0150( 9 -> 9 )")]
        public int Test_0150(int x)
        {
            var f =
                 If(A_Is(MoreThen(10)))
                    .If(A_Is(MoreThen(20)))
                        .If(A_Is(MoreThen(30)))
                            .If(A_Is(MoreThen(40)))
                                .Then(From_A_To_A_With(Add(100)))   // 49 -> 149
                            .End()
                        .End()
                    .End()
                .End();                                             // 9 -> 9

            A result = f(new A(x));

            return result.Value;
        }
    }
}
