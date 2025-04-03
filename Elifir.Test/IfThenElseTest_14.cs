namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenElseTest_14
    {
        [TestCase(2, ExpectedResult = 13, TestName = "Test_1400( 2 -> 13 )")]
        [TestCase(0, ExpectedResult = 21, TestName = "Test_1400( 0 -> 21 )")]
        public int Test_1400(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(10)))    // 2 -> 13
               .Else()
                    .Then(From_A_To_A_With(Add(20)))    // 0 -> 21
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 37, TestName = "Test_1401( 1 -> 37 )")]
        [TestCase(2, ExpectedResult = 50, TestName = "Test_1401( 1 -> 50 )")]
        public int Test_1401(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .Then(From_A_To_A_With(Add(11)))
               .If(A_Is(Odd))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(22)))   // 1 -> 37
               .Else()
                    .Then(From_A_To_A_With(Add(3)))
                    .Then(From_A_To_A_With(Add(33)))   // 1 -> 50
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 3332, TestName = "Test_1402( 2 -> 3332 )")]
        [TestCase(1, ExpectedResult = 4441, TestName = "Test_1402( 1 -> 4441 )")]
        public int Test_1402(int x)
        {
            var f =
                From_A_To_A_With(Add(10))
               .Then(From_A_To_A_With(Add(100)))
               .Then(From_A_To_A_With(Add(1000)))
               .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))
                    .Then(From_A_To_A_With(Add(2000)))  // 2 -> 3332
               .Else()
                    .Then(From_A_To_A_With(Add(30)))
                    .Then(From_A_To_A_With(Add(300)))
                    .Then(From_A_To_A_With(Add(3000)))  // 1 -> 4441
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 18, TestName = "Test_1403( 3 -> 18 )")]
        [TestCase(1, ExpectedResult = 26, TestName = "Test_1403( 1 -> 26 )")]
        public int Test_1403(int x)
        {
            var f =
                From_A_To_A_With(Add(5))
               .If(A_Is(MoreThen(7)))
                    .Then(From_A_To_Aʹ_With(Add(10)))   // 3 -> 18
               .Else()
                    .Then(From_A_To_A_With(Add(20)))    // 1 -> 26
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 18, TestName = "Test_1404( 3 -> 18 )")]
        [TestCase(1, ExpectedResult = 26, TestName = "Test_1404( 1 -> 26 )")]
        public int Test_1404(int x)
        {
            var f =
                From_A_To_A_With(Add(5))
               .If(A_Is(MoreThen(7)))
                    .Then(From_A_To_A_With(Add(10)))    // 3 -> 18
               .Else()
                    .Then(From_A_To_Aʹ_With(Add(20)))   // 1 -> 26
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 18, TestName = "Test_1405( 3 -> 18 )")]
        [TestCase(1, ExpectedResult = 26, TestName = "Test_1405( 1 -> 26 )")]
        public int Test_1405(int x)
        {
            var f =
                From_B_To_B_With(Add(5))
               .If(B_Is(MoreThen(7)))
                    .Then(From_B_To_Aʹ_With(Add(10)))   // 3 -> 18
               .Else()
                    .Then(From_B_To_A_With(Add(20)))    // 1 -> 26
               .End();

            A result = f(new B(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 3332, TestName = "Test_1406( 2 -> 3332 )")]
        [TestCase(1, ExpectedResult = 4441, TestName = "Test_1406( 1 -> 4441 )")]
        public int Test_1406(int x)
        {
            var f =
                From_A_To_B_With(Add(10))
               .Then(From_B_To_C_With(Add(100)))
               .Then(From_C_To_D_With(Add(1000)))
               .If(D_Is(Even))
                    .Then(From_D_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))
                    .Then(From_C_To_B_With(Add(2000)))  // 2 -> 3332
               .Else()
                    .Then(From_D_To_C_With(Add(30)))
                    .Then(From_C_To_B_With(Add(300)))
                    .Then(From_B_To_B_With(Add(3000)))  // 1 -> 4441
               .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 3332, TestName = "Test_1407( 2 -> 3332 )")]
        [TestCase(1, ExpectedResult = 4441, TestName = "Test_1407( 1 -> 4441 )")]
        public int Test_1407(int x)
        {
            var f =
                From_A_To_B_With(Add(10))
               .Then(From_B_To_C_With(Add(100)))
               .Then(From_C_To_D_With(Add(1000)))
               .If(D_Is(Even))
                    .Then(From_D_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))
                    .Then(From_C_To_Bʹ_With(Add(2000)))  // 2 -> 3332
               .Else()
                    .Then(From_D_To_C_With(Add(30)))
                    .Then(From_C_To_B_With(Add(300)))
                    .Then(From_B_To_B_With(Add(3000)))  // 1 -> 4441
               .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 3332, TestName = "Test_1408( 2 -> 3332 )")]
        [TestCase(1, ExpectedResult = 4441, TestName = "Test_1408( 1 -> 4441 )")]
        public int Test_1408(int x)
        {
            var f =
                From_A_To_B_With(Add(10))
               .Then(From_B_To_C_With(Add(100)))
               .Then(From_C_To_D_With(Add(1000)))
               .If(D_Is(Even))
                    .Then(From_D_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))
                    .Then(From_C_To_B_With(Add(2000)))  // 2 -> 3332
               .Else()
                    .Then(From_D_To_C_With(Add(30)))
                    .Then(From_C_To_B_With(Add(300)))
                    .Then(From_B_To_Bʹ_With(Add(3000)))  // 1 -> 4441
               .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(true,  ExpectedResult = 12, TestName = "Test_1413( true, 1 -> 12 )")]
        [TestCase(false, ExpectedResult = 22, TestName = "Test_1413( false, 1 -> 22 )")]
        public int Test_1413(bool isAʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(isAʹ);

            var f =
                from_A_To_A_OrTo_Aʹ_With(Add(1))
               .If(Is<Aʹ>)
                    .Then(From_Aʹ_To_A_With(Add(10)))   // (true, 1) -> 12
               .Else()
                    .Then(From_A_To_A_With(Add(20)))    // (false, 1) -> 22
               .End();

            A result = f(new A(1));

            return result.Value;
        }

        [TestCase(true,  ExpectedResult = 331, TestName = "Test_1414( true, 1 -> 331 )")]
        [TestCase(false, ExpectedResult = 441, TestName = "Test_1414( false, 1 -> 441 )")]
        public int Test_1414(bool isAʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(isAʹ);

            var f =
                From_A_To_A_With(Add(10))
               .Then(from_A_To_A_OrTo_Aʹ_With(Add(100)))
               .If(Is<Aʹ>)
                    .Then(From_Aʹ_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))   // (true, 1) -> 331
               .Else()
                    .Then(From_A_To_A_With(Add(30)))
                    .Then(From_A_To_Aʹ_With(Add(300)))  // (false, 1) -> 441
               .End();

            A result = f(new A(1));

            return result.Value;
        }

        [TestCase(true,  ExpectedResult = 3331, TestName = "Test_1415( true, 1 -> 3331 )")]
        [TestCase(false, ExpectedResult = 4441, TestName = "Test_1415( false, 1 -> 4441 )")]
        public int Test_1415(bool isAʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(isAʹ);

            var f =
                From_A_To_A_With(Add(10))
               .Then(From_A_To_A_With(Add(100)))
               .Then(from_A_To_A_OrTo_Aʹ_With(Add(1000)))
               .If(Is<Aʹ>)
                    .Then(From_Aʹ_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))
                    .Then(From_A_To_Aʹ_With(Add(2000))) // (true, 1) -> 3331
               .Else()
                    .Then(From_A_To_A_With(Add(30)))
                    .Then(From_A_To_A_With(Add(300)))
                    .Then(From_A_To_A_With(Add(3000)))  // (false, 1) -> 4441
               .End();

            A result = f(new A(1));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 13, TestName = "Test_1116( 2 -> 13 )")]
        [TestCase(13, ExpectedResult = 44, TestName = "Test_1116( 13 -> 44 )")]
        [TestCase(0,  ExpectedResult = 31, TestName = "Test_1116( 0 -> 31 )")]
        public int Test_1416(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Aʹ_With(Add(10)))       // 2 -> 13
                    .If(A_Is(MoreThen(20)))
                        .Then(From_A_To_A_With(Add(20)))    // 13 -> 44
                    .End()
               .Else()
                    .Then(From_A_To_A_With(Add(30)))        // 0 -> 31
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 21, TestName = "Test_1117( 10 -> 21 )")]
        [TestCase(2,  ExpectedResult = 23, TestName = "Test_1117( 2 -> 23 )")]
        [TestCase(6,  ExpectedResult = 57, TestName = "Test_1117( 6 -> 57 )")]
        public int Test_1417(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_A_With(Add(10)))        // 10 -> 21
               .Else()
                    .Then(From_A_To_A_With(Add(20)))        // 2 -> 23
                    .If(A_Is(MoreThen(25)))
                        .Then(From_A_To_Aʹ_With(Add(30)))   // 6 -> 57
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 13, TestName = "Test_1418( 2 -> 13 )")]
        [TestCase(12, ExpectedResult = 43, TestName = "Test_1418( 12 -> 43 )")]
        [TestCase(1,  ExpectedResult = 32, TestName = "Test_1418( 1 -> 32 )")]
        [TestCase(11, ExpectedResult = 82, TestName = "Test_1418( 11 -> 82 )")]
        public int Test_1418(int x)
        {
            var f =
                From_C_To_B_With(Add(1))
               .If(B_Is(Odd))
                    .Then(From_B_To_Aʹ_With(Add(10)))       // 2 -> 13
                    .If(Aʹ_Is(MoreThen(20)))
                        .Then(From_Aʹ_To_A_With(Add(20)))   // 12 -> 43
                    .End()
               .Else()
                    .Then(From_B_To_A_With(Add(30)))        // 1 -> 32
                    .If(A_Is(MoreThen(40)))
                        .Then(From_A_To_Aʹ_With(Add(40)))   // 11 -> 82
                    .End()
               .End();

            A result = f(new C(x));

            return result.Value;
        }

        [TestCase(0,   ExpectedResult = 1,   TestName = "Test_1420( 0 -> 1 )")]
        [TestCase(249, ExpectedResult = 280, TestName = "Test_1420( 249 -> 280 )")]
        [TestCase(149, ExpectedResult = 190, TestName = "Test_1420( 149 -> 190 )")]
        [TestCase(59,  ExpectedResult = 150, TestName = "Test_1420( 59 -> 150 )")]
        [TestCase(39,  ExpectedResult = 170, TestName = "Test_1420( 39 -> 170 )")]
        [TestCase(19,  ExpectedResult = 190, TestName = "Test_1420( 19 -> 190 )")]
        public int Test_1420(int x)
        {
            var f =
                From_C_To_B_With(Add(1))
               .If(B_Is(MoreThen(100)))                             // 0 -> 1
                    .Then(From_B_To_C_With(Add(10)))
                    .If(C_Is(MoreThen(200)))
                        .Then(From_C_To_B_With(Add(20)))            // 249 -> 280
                    .Else()
                        .Then(From_C_To_Bʹ_With(Add(30)))           // 149 -> 190
                    .End()
               .Else()
                    .If(B_Is(MoreThen(50)))
                        .Then(From_B_To_E_With(Add(40)))
                        .Then(From_E_To_Bʹ_With(Add(50)))           // 59 -> 150
                    .Else()
                        .If(B_Is(MoreThen(30)))
                            .Then(From_B_To_D_With(Add(60)))
                            .Then(From_D_To_B_With(Add(70)))        // 39 -> 170
                        .Else()
                            .If(B_Is(MoreThen(10)))
                                .Then(From_B_To_E_With(Add(80)))
                                .Then(From_E_To_Bʹ_With(Add(90)))   // 19 -> 190
                            .End()
                        .End()
                    .End()
                .End();

            B result = f(new C(x));

            return result.Value;
        }

        [TestCase("Aʺʺʺʺʹ", ExpectedResult = 102,       TestName = "Test_1421( 0, Aʺʺʺʺʹ -> 102 )")]
        [TestCase("Aʺʺʺʺ",  ExpectedResult = 111,       TestName = "Test_1421( 0, Aʺʺʺʺ -> 111 )")]
        [TestCase("Aʺʺʺʹ",  ExpectedResult = 101,       TestName = "Test_1421( 0, Aʺʺʺʹ -> 101 )")]
        [TestCase("Aʺʺʺ",   ExpectedResult = 101001,    TestName = "Test_1421( 0, Aʺʺʺ -> 101001 )")]
        [TestCase("Aʺʺʹ",   ExpectedResult = 110001,    TestName = "Test_1421( 0, Aʺʺʹ -> 110001 )")]
        [TestCase("Aʺʺ",    ExpectedResult = 100001,    TestName = "Test_1421( 0, Aʺʺ -> 100001 )")]
        [TestCase("Aʺʹ",    ExpectedResult = 1000001,   TestName = "Test_1421( 0, Aʺʹ -> 1000001 )")]
        [TestCase("Aʺ",     ExpectedResult = 10000001,  TestName = "Test_1421( 0, Aʺ -> 10000001 )")]
        [TestCase("Aʹ",     ExpectedResult = 100000001, TestName = "Test_1421( 0, Aʹ -> 100000001 )")]
        [TestCase("A",      ExpectedResult = 1,         TestName = "Test_1421( 0, A -> 1 )")]
        public int Test_1421(string ofTypeX)
        {
            var from_D_To_SomeA_With =
                From_D_To_SomeA(ofTypeX);

            var f =
                 from_D_To_SomeA_With(Add(1))
                .If(Is<Aʺʺʺʹ>)
                    .If(Is<Aʺʺʺʺ>)
                        .If(Is<Aʺʺʺʺʹ>)
                            .Then(From_A_To_A_With(Add(1)))                 // (0, Aʺʺʺʺʹ) -> 102 // +100
                        .Else()
                            .Then(From_A_To_A_With(Add(10)))                // (0, Aʺʺʺʺ) -> 111 // +100
                        .End()
                    .End()
                    .Then(From_A_To_A_With(Add(100)))                       // (0, Aʺʺʺʹ) -> 101
                .Else()
                    .If(Is<Aʺʺ>)
                        .If(Is<Aʺʺʺ>)
                            .Then(From_A_To_A_With(Add(1000)))              // (0, Aʺʺʺ) -> 101001 // +100000
                        .Else()
                            .If(Is<Aʺʺʹ>)
                                .Then(From_A_To_A_With(Add(10000)))         // (0, Aʺʺʹ) -> 110001 // +100000
                            .End()
                        .End()
                        .Then(From_A_To_A_With(Add(100000)))                // (0, Aʺʺ) -> 100001
                    .Else()
                        .If(Is<Aʺʹ>)
                            .Then(From_A_To_A_With(Add(1000000)))           // (0, Aʺʹ) -> 1000001
                        .Else()
                            .If(Is<Aʺ>)
                                .Then(From_A_To_A_With(Add(10000000)))      // (0, Aʺ) -> 10000001
                            .Else()
                                .If(Is<Aʹ>)
                                    .Then(From_A_To_A_With(Add(100000000))) // (0, Aʹ) -> 100000001
                                .End()
                            .End()
                        .End()
                    .End()
                .End();                                                     // (0, A) -> 1

            A result = f(new D(0));

            return result.Value;
        }

        [TestCase(48, ExpectedResult = 149, TestName = "Test_1430( 48 -> 149 )")]
        [TestCase(38, ExpectedResult = 239, TestName = "Test_1430( 38 -> 239 )")]
        [TestCase(28, ExpectedResult = 329, TestName = "Test_1430( 28 -> 329 )")]
        [TestCase(18, ExpectedResult = 419, TestName = "Test_1430( 18 -> 419 )")]
        [TestCase(8,  ExpectedResult = 509, TestName = "Test_1430( 8 -> 509 )")]
        public int Test_1430(int x)
        {
            var f =
                 From_C_To_A_With(Add(1))
                .If(A_Is(MoreThen(10)))
                    .If(A_Is(MoreThen(20)))
                        .If(A_Is(MoreThen(30)))
                            .If(A_Is(MoreThen(40)))
                                .Then(From_A_To_A_With(Add(100)))   // 48 -> 149
                            .Else()
                                .Then(From_A_To_A_With(Add(200)))   // 38 -> 239
                            .End()
                        .Else()
                            .Then(From_A_To_A_With(Add(300)))       // 28 -> 329
                        .End()
                    .Else()
                        .Then(From_A_To_A_With(Add(400)))           // 18 -> 419
                    .End()
                .Else()
                    .Then(From_A_To_A_With(Add(500)))               // 8 -> 509
                .End();

            A result = f(new C(x));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 14, TestName = "Test_1431( 2 -> 14 )")]
        [TestCase(13, ExpectedResult = 47, TestName = "Test_1431( 13 -> 47 )")]
        [TestCase(0,  ExpectedResult = 34, TestName = "Test_1431( 0 -> 34 )")]
        public int Test_1431(int x)
        {
            var f =
                From_C_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_B_With(Add(1)))
                    .Then(From_B_To_Aʹ_With(Add(10)))       // 2 -> 14
                    .If(A_Is(MoreThen(20)))
                        .Then(From_A_To_C_With(Add(2)))
                        .Then(From_C_To_A_With(Add(20)))    // 13 -> 47
                    .End()
               .Else()
                    .Then(From_A_To_A_With(Add(3)))
                    .Then(From_A_To_A_With(Add(30)))        // 0 -> 34
               .End();

            A result = f(new C(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 44, TestName = "Test_1432( 11 -> 44 )")]
        [TestCase(3,  ExpectedResult = 47, TestName = "Test_1432( 3 -> 47 )")]
        [TestCase(7,  ExpectedResult = 95, TestName = "Test_1432( 7 -> 95 )")]
        public int Test_1432(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .Then(From_A_To_A_With(Add(10)))
               .If(A_Is(MoreThen(20)))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))        // 11 -> 44
               .Else()
                    .Then(From_A_To_A_With(Add(3)))
                    .Then(From_A_To_A_With(Add(30)))        // 3 -> 47
                    .If(A_Is(MoreThen(50)))
                        .Then(From_A_To_A_With(Add(4)))
                        .Then(From_A_To_Aʹ_With(Add(40)))   // 7 -> 95
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3,  ExpectedResult = 36, TestName = "Test_1433( 3 -> 36 )")]
        [TestCase(13, ExpectedResult = 79, TestName = "Test_1433( 13 -> 79 )")]
        [TestCase(2,  ExpectedResult = 57, TestName = "Test_1433( 2 -> 57 )")]
        [TestCase(12, ExpectedResult = 122, TestName = "Test_1433( 12 -> 122 )")]
        public int Test_1433(int x)
        {
            var f =
                From_E_To_C_With(Add(1))
               .Then(From_C_To_B_With(Add(10)))
               .If(B_Is(Even))
                    .Then(From_B_To_C_With(Add(2)))
                    .Then(From_C_To_Aʹ_With(Add(20)))       // 3 -> 36
                    .If(Aʹ_Is(MoreThen(40)))
                        .Then(From_Aʹ_To_E_With(Add(3)))
                        .Then(From_E_To_A_With(Add(30)))    // 13 -> 79
                    .End()
               .Else()
                    .Then(From_B_To_D_With(Add(4)))
                    .Then(From_D_To_A_With(Add(40)))        // 2 -> 57
                    .If(A_Is(MoreThen(60)))
                        .Then(From_A_To_E_With(Add(5)))
                        .Then(From_E_To_Aʹ_With(Add(50)))   // 12 -> 122
                    .End()
               .End();

            A result = f(new E(x));

            return result.Value;
        }

        [TestCase(1,   ExpectedResult = 2,   TestName = "Test_1434( 1 -> 2 )")]
        [TestCase(250, ExpectedResult = 284, TestName = "Test_1434( 250 -> 284 )")]
        [TestCase(150, ExpectedResult = 195, TestName = "Test_1434( 150 -> 195 )")]
        [TestCase(60,  ExpectedResult = 155, TestName = "Test_1434( 60 -> 155 )")]
        [TestCase(40,  ExpectedResult = 177, TestName = "Test_1434( 40 -> 177 )")]
        [TestCase(20,  ExpectedResult = 199, TestName = "Test_1434( 20 -> 199 )")]
        public int Test_1434(int x)
        {
            var f =
                From_D_To_B_With(Add(1))
               .If(B_Is(MoreThen(100)))                             // 1 -> 2
                    .Then(From_B_To_E_With(Add(1)))
                    .Then(From_E_To_C_With(Add(10)))
                    .If(C_Is(MoreThen(200)))
                        .Then(From_C_To_D_With(Add(2)))
                        .Then(From_D_To_B_With(Add(20)))            // 250 -> 284
                    .Else()
                        .Then(From_C_To_E_With(Add(3)))
                        .Then(From_E_To_Bʹ_With(Add(30)))           // 150 -> 195
                    .End()
               .Else()
                    .If(B_Is(MoreThen(50)))
                        .Then(From_B_To_E_With(Add(4)))
                        .Then(From_E_To_D_With(Add(40)))
                        .Then(From_D_To_Bʹ_With(Add(50)))           // 60 -> 155
                    .Else()
                        .If(B_Is(MoreThen(30)))
                            .Then(From_B_To_E_With(Add(6)))
                            .Then(From_E_To_D_With(Add(60)))
                            .Then(From_D_To_B_With(Add(70)))        // 40 -> 177
                        .Else()
                            .If(B_Is(MoreThen(10)))
                                .Then(From_B_To_E_With(Add(8)))
                                .Then(From_E_To_C_With(Add(80)))
                                .Then(From_C_To_Bʹ_With(Add(90)))   // 20 -> 199
                            .End()
                        .End()
                    .End()
                .End();

            B result = f(new D(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 4,  TestName = "Test_1435( 1 -> 4 )")]
        [TestCase(2, ExpectedResult = 6,  TestName = "Test_1435( 2 -> 6 )")]
        [TestCase(8, ExpectedResult = 16, TestName = "Test_1435( 8 -> 16 )")]
        public int Test_1435(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(Even))
                    .Then(From_A_To_Aʹ_With(Add(2)))        // 1 -> 4
               .Else()
                    .Then(From_A_To_Aʹ_With(Add(3)))        // 2 -> 6
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_A_With(Add(4)))    // 8 -> 16
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 4,  TestName = "Test_1436( 1 -> 4 )")]
        [TestCase(2, ExpectedResult = 6,  TestName = "Test_1436( 2 -> 6 )")]
        [TestCase(8, ExpectedResult = 16, TestName = "Test_1436( 8 -> 16 )")]
        public int Test_1436(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))         // 1 -> 4
               .Else()
                    .Then(From_A_To_A_With(Add(3)))         // 2 -> 6
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Add(4)))    // 8 -> 16
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(14, ExpectedResult = 15, TestName = "Test_1437( 14 -> 15 )")]
        [TestCase(11, ExpectedResult = 17, TestName = "Test_1437( 11 -> 17 )")]
        [TestCase(1,  ExpectedResult = 8,  TestName = "Test_1437( 1 -> 8 )")]
        public int Test_1437(int x)
        {
            var f =
                From_A_To_A_With(Add(1))                    // 15 -> 15
               .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Add(3)))    // 11 -> 17
                    .Else()
                        .Then(From_A_To_A_With(Add(4)))     // 1 -> 8
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(14, ExpectedResult = 15, TestName = "Test_1438( 14 -> 15 )")]
        [TestCase(11, ExpectedResult = 15, TestName = "Test_1438( 11 -> 15 )")]
        [TestCase(1,  ExpectedResult = 6,  TestName = "Test_1438( 1 -> 6 )")]
        public int Test_1438(int x)
        {
            var f =
                From_A_To_A_With(Add(1))                    // 14 -> 15
               .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(1)))
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Add(2)))     // 11 -> 15
                    .Else()
                        .Then(From_A_To_Aʹ_With(Add(3)))    // 1 -> 6
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }
    }
}
