namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenTest_08
    {
        [TestCase(1,   ExpectedResult = 1,   TestName = "Test_0800( 1 -> 1 )")]
        [TestCase(8,   ExpectedResult = 8,   TestName = "Test_0800( 8 -> 8 )")]
        [TestCase(101, ExpectedResult = 101, TestName = "Test_0800( 101 -> 101 )")]
        [TestCase(12,  ExpectedResult = 14,  TestName = "Test_0800( 12 -> 14 )")]
        public int Test_0800(int x)
        {
            var f =
                 If(A_Is(Even)).AndIf(A_Is(MoreThen(10)))  // 1 -> 1, 8 -> 8, 101 -> 101
                    .Then(From_A_To_A_With(Add(2)))        // 12 -> 14
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,   ExpectedResult = 1,   TestName = "Test_0801( 1 -> 1 )")]
        [TestCase(111, ExpectedResult = 111, TestName = "Test_0801( 111 -> 111 )")]
        [TestCase(112, ExpectedResult = 134, TestName = "Test_0801( 112 -> 134 )")]
        public int Test_0801(int x)
        {
            var f =
                 If(A_Is(Even)).AndIf(A_Is(MoreThen(50)))   // 1 -> 1, 111 -> 111
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))        // 112 -> 134
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(50,  ExpectedResult = 50,  TestName = "Test_0802( 50 -> 50 )")]
        [TestCase(1,   ExpectedResult = 1,   TestName = "Test_0802( 1 -> 1 )")]
        [TestCase(111, ExpectedResult = 111, TestName = "Test_0802( 111 -> 111 )")]
        [TestCase(89,  ExpectedResult = 311, TestName = "Test_0802( 89 -> 311 )")]
        public int Test_8502(int x)
        {
            var f =
                 If(A_Is(Odd))                          // 50 -> 50
                .AndIf(A_Is(MoreThen(50)))              // 1 -> 1
                .AndIf(A_Is(LessThen(100)))             // 111 -> 111
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))   // 89 -> 311
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(false, 2, ExpectedResult = 2,   TestName = "Test_0803( false, 2 -> 2 )")]
        [TestCase(true,  1, ExpectedResult = 1,   TestName = "Test_0803( true, 1 -> 1 )")]
        [TestCase(true,  2, ExpectedResult = 224, TestName = "Test_0803( true, 2 -> 224 )")]
        public int Test_0803(bool isCʹ, int x)
        {
            var f =
                 If(C_Is(Even))                         // (false, 2) -> 2
                .AndIf(Is<Cʹ>)                          // (true, 1) -> 1
                    .Then(From_Cʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_C_With(Add(200)))   // (true, 2) -> 224
                .End();

            C arg = isCʹ
                ? new Cʹ(x)
                : new C(x);

            C result = f(arg);

            return result.Value;
        }

        [TestCase(10,  false, ExpectedResult = 10,  TestName = "Test_0804( 10, false -> 10 )")]
        [TestCase(10,  true,  ExpectedResult = 10,  TestName = "Test_0804( 10, true -> 10 )")]
        [TestCase(200, false, ExpectedResult = 200, TestName = "Test_0804( 200, false -> 200 )")]
        [TestCase(200, true,  ExpectedResult = 222, TestName = "Test_0804( 200, true -> 222 )")]
        public int Test_0804(int x, bool isAʹ)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (10, false) -> 10
                .AndIf(Aʹ_Is(MoreThen(100)))            // (10, true) -> 10, (200, false) -> 200
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_Aʹ_With(Add(20)))   // (200, true) -> 222
                .End();

            A arg = isAʹ
                ? new Aʹ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase("A",      ExpectedResult = 111, TestName = "Test_0805( 111, A -> 111 )")]
        [TestCase("Aʹ",     ExpectedResult = 111, TestName = "Test_0805( 111, Aʹ -> 111 )")]
        [TestCase("Aʺ",     ExpectedResult = 333, TestName = "Test_0805( 111, Aʺ -> 333 )")]
        [TestCase("Aʺʹ",    ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʹ -> 333 )")]
        [TestCase("Aʺʺ",    ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺ -> 333 )")]
        [TestCase("Aʺʺʹ",   ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺʹ -> 333 )")]
        [TestCase("Aʺʺʺ",   ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺʺ -> 333 )")]
        [TestCase("Aʺʺʺʹ",  ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺʺʹ -> 333 )")]
        [TestCase("Aʺʺʺʺ",  ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺʺʺ -> 333 )")]
        [TestCase("Aʺʺʺʺʹ", ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺʺʺʹ -> 333 )")]
        [TestCase("Aʺʺʺʺʺ", ExpectedResult = 333, TestName = "Test_0805( 111, Aʺʺʺʺʺ -> 333 )")]
        public int Test_0805(string ofTypeX)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (111, A) -> 111
                .AndIf(Is<Aʺ>)                          // (111, Aʹ) -> 111
                    .Then(From_Aʺ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Aʹ_With(Add(200)))  // (111, Aʺ) -> 333, (111, Aʺʹ) -> 333
                .End();                                 // (111, Aʺʺ) -> 333, (111, Aʺʺʹ) -> 333
                                                        // (111, Aʺʺʺ) -> 333, (111, Aʺʺʺʹ) -> 333
                                                        // (111, Aʺʺʺʺ) -> 333, (111, Aʺʺʺʺʹ) -> 333
                                                        // (111, Aʺʺʺʺʺ) -> 333

            A result = f(From_Int_To_SomeA(ofTypeX)(111));

            return result.Value;
        }

        [TestCase("A",      ExpectedResult = 111, TestName = "Test_0806( 111, A -> 111 )")]
        [TestCase("Aʹ",     ExpectedResult = 111, TestName = "Test_0806( 111, Aʹ -> 111 )")]
        [TestCase("Aʺ",     ExpectedResult = 111, TestName = "Test_0806( 111, Aʺ -> 111 )")]
        [TestCase("Aʺʹ",    ExpectedResult = 111, TestName = "Test_0806( 111, Aʺʹ -> 111 )")]
        [TestCase("Aʺʺ",    ExpectedResult = 111, TestName = "Test_0806( 111, Aʺʺ -> 111 )")]
        [TestCase("Aʺʺʹ",   ExpectedResult = 111, TestName = "Test_0806( 111, Aʺʺʹ -> 111 )")]
        [TestCase("Aʺʺʺ",   ExpectedResult = 111, TestName = "Test_0806( 111, Aʺʺʺ -> 111 )")]
        [TestCase("Aʺʺʺʹ",  ExpectedResult = 333, TestName = "Test_0806( 111, Aʺʺʺʹ -> 333 )")]
        [TestCase("Aʺʺʺʺ",  ExpectedResult = 333, TestName = "Test_0806( 111, Aʺʺʺʺ -> 333 )")]
        [TestCase("Aʺʺʺʺʹ", ExpectedResult = 333, TestName = "Test_0806( 111, Aʺʺʺʺʹ -> 333 )")]
        [TestCase("Aʺʺʺʺʺ", ExpectedResult = 333, TestName = "Test_0806( 111, Aʺʺʺʺʺ -> 333 )")]
        public int Test_0806(string ofTypeX)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                   // (111, A) -> 111
                .AndIf(Is<Aʺ>)                          // (111, Aʹ) -> 111
                .AndIf(Is<Aʺʹ>)                         // (111, Aʺ) -> 111
                .AndIf(Is<Aʺʺ>)                         // (111, Aʺʹ) -> 111
                .AndIf(Is<Aʺʺʹ>)                        // (111, Aʺʺ) -> 111
                .AndIf(Is<Aʺʺʺ>)                        // (111, Aʺʺʹ) -> 111
                .AndIf(Is<Aʺʺʺʹ>)                       // (111, Aʺʺʺ) -> 111
                    .Then(From_Aʺʺʺʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Aʹ_With(Add(200)))  // (111, Aʺʺʺʹ) -> 333, (111, Aʺʺʺʺ) -> 333
                .End();                                 // (111, Aʺʺʺʺʹ) -> 333, (111, Aʺʺʺʺʺ) -> 333

            A arg = From_Int_To_SomeA(ofTypeX)(111);
            A result = f(arg);

            return result.Value;
        }

        [TestCase(1,   false, ExpectedResult = 1,   TestName = "Test_0807( 1, false -> 1 )")]
        [TestCase(2,   false, ExpectedResult = 2,   TestName = "Test_0807( 2, false -> 2 )")]
        [TestCase(101, false, ExpectedResult = 101, TestName = "Test_0807( 101, false -> 101 )")]
        [TestCase(1,   true,  ExpectedResult = 1,   TestName = "Test_0807( 1, true -> 1 )")]
        [TestCase(2,   true,  ExpectedResult = 2,   TestName = "Test_0807( 2, true -> 2 )")]
        [TestCase(200, true,  ExpectedResult = 202, TestName = "Test_0807( 200, true -> 202 )")]
        [TestCase(200, false, ExpectedResult = 200, TestName = "Test_0807( 200, false -> 200 )")]
        [TestCase(102, true,  ExpectedResult = 104, TestName = "Test_0807( 102, true -> 104 )")]
        public int Test_0807(int x, bool isAʺ)
        {
            var f =
                 If(Aʹ_Is(Even))                        // (1, false) -> 1, (2, false) -> 2
                .AndIf(Is<Aʺ>)                          // (101, false) -> 101, (1, true) -> 1
                .AndIf(Aʺ_Is(MoreThen(100)))            // (2, true) -> 2, (200, false) -> 200
                    .Then(From_Aʺ_To_A_With(Add(2)))    // (102, true) -> 104, (200, false) -> 202
                .End();

            Aʹ arg = isAʺ
                ? new Aʺ(x)
                : new Aʹ(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(2,   "Aʹ",   ExpectedResult = 2,   TestName = "Test_0808( 2, Aʹ -> 2 )")]
        [TestCase(1,   "Aʹ",   ExpectedResult = 1,   TestName = "Test_0808( 1, Aʹ -> 1 )")]
        [TestCase(102, "Aʺ",   ExpectedResult = 102, TestName = "Test_0808( 102, Aʺ -> 102 )")]
        [TestCase(2,   "Aʺʹ",  ExpectedResult = 2,   TestName = "Test_0808( 1, Aʺʹ -> 1 )")]
        [TestCase(3,   "Aʺʹ",  ExpectedResult = 25,  TestName = "Test_0808( 3, Aʺʹ -> 25 )")]
        [TestCase(3,   "Aʺʺ",  ExpectedResult = 25,  TestName = "Test_0808( 3, Aʺʺ -> 25 )")]
        [TestCase(3,   "Aʺʺʺ", ExpectedResult = 25,  TestName = "Test_0508( 3, Aʺʺʺ -> 25 )")]
        public int Test_0808(int x, string ofTypeX)
        {
            var f =
                 If(Object<Aʹ>.Is<Aʺ>)                  // (2, Aʹ) -> 2, (1, Aʹ) -> 1
                .AndIf(Aʺ_Is(Odd))                      // (102, Aʺ) -> 102, (2, Aʺʹ) -> 2
                .AndIf(Is<Aʺʹ>)
                    .Then(From_Aʺʹ_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))    // (3, Aʺʹ) -> 25, (3, Aʺʺ) -> 25
                .End();                                 // (3, Aʺʺʺ) -> 25

            Aʹ arg = From_Int_To_SomeAʹ(ofTypeX)(x);
            A result = f(arg);

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test_0809( 1 -> 1 )")]
        [TestCase(2,    ExpectedResult = 2,    TestName = "Test_0809( 2 -> 2 )")]
        [TestCase(13,   ExpectedResult = 13,   TestName = "Test_0809( 13 -> 13 )")]
        [TestCase(12,   ExpectedResult = 14,   TestName = "Test_0809( 12 -> 14 )")]
        [TestCase(3000, ExpectedResult = 3002, TestName = "Test_0809( 3000 -> 3002 )")]
        [TestCase(1988, ExpectedResult = 1993, TestName = "Test_0809( 1988 -> 1993 )")]
        public int Test_0809(int x)
        {
            var f =
                 If(A_Is(Even))                             // 1 -> 1, 2 -> 2
                .AndIf(A_Is(MoreThen(10)))                  // 13 -> 13
                    .Then(From_A_To_A_With(Add(2)))         // 12 -> 14
                    .If(A_Is(MoreThen(1000)))               // 3000 -> 3002
                    .AndIf(A_Is(LessThen(2000)))
                        .Then(From_A_To_A_With(Add(3)))     // 1988 -> 1993
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,   false, false, ExpectedResult = 2,   TestName = "Test_0810( 2, false, false -> 2 )")]
        [TestCase(1,   false, false, ExpectedResult = 1,   TestName = "Test_0810( 1, false, false -> 1 )")]
        [TestCase(2,   true,  false, ExpectedResult = 2,   TestName = "Test_0810( 2, true, false -> 2 )")]
        [TestCase(1,   true,  false, ExpectedResult = 37,  TestName = "Test_0810( 1, true, false -> 37 )")]
        [TestCase(1,   true,  true,  ExpectedResult = 37,  TestName = "Test_0810( 1, true, true -> 37 )")]
        [TestCase(101, true,  false, ExpectedResult = 137, TestName = "Test_0810( 101, true, false -> 137 )")]
        [TestCase(101, true,  true,  ExpectedResult = 178, TestName = "Test_0810( 101, true, true -> 178 )")]
        public int Test_0810(int x, bool firstIsAʹ, bool secondIsBʹ)
        {
            var from_B_To_B_OrTo_Bʹ_With =
                From_B_To_B_OrTo_Bʹ(secondIsBʹ);

            var f =
                 If(A_Is(Odd))                                  // (2, false, false) -> 2, (1, false, false) -> 1
                .AndIf(Is<Aʹ>)                                  // (2, true, false) -> 2
                    .Then(From_Aʹ_To_B_With(Add(2)))
                    .Then(from_B_To_B_OrTo_Bʹ_With(Add(20)))    // (1, true, false) -> 37    // +7, +7
                    .If(B_Is(MoreThen(100)))                    // (1, true, true) -> 37     // +7, +7
                    .AndIf(Is<Bʹ>)                              // (101, true, false) -> 137 // +7, +7
                        .Then(From_Bʹ_To_A_With(Add(20)))
                        .Then(From_A_To_B_With(Add(21)))        // (101, true, true) -> 178  // +7, +7
                    .End()
                    .Then(From_B_To_C_With(Add(7)))
                    .Then(From_C_To_A_With(Add(7)))
                .End();

            var arg = firstIsAʹ
                ? new Aʹ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(2,   false, ExpectedResult = 2,    TestName = "Test_0811( 2, false -> 2 )")]
        [TestCase(2,   true,  ExpectedResult = 2,    TestName = "Test_0811( 2, true -> 2 )")]
        [TestCase(3,   false, ExpectedResult = 225,  TestName = "Test_0811( 3, false -> 225 )")]
        [TestCase(3,   true,  ExpectedResult = 225,  TestName = "Test_0811( 3, true -> 225 )")]
        [TestCase(803, false, ExpectedResult = 1025, TestName = "Test_0811( 803, false -> 1025 )")]
        [TestCase(803, true,  ExpectedResult = 1025, TestName = "Test_0811( 803, true -> 1025 )")]
        [TestCase(701, false, ExpectedResult = 923,  TestName = "Test_0811( 701, false -> 923 )")]
        [TestCase(701, true,  ExpectedResult = 923,  TestName = "Test_0811( 701, true -> 923 )")]
        [TestCase(705, false, ExpectedResult = 927,  TestName = "Test_0811( 703, false -> 927 )")]
        [TestCase(705, true,  ExpectedResult = 1260, TestName = "Test_0811( 703, true -> 1260 )")]
        public int Test_0811(int x, bool isAʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(isAʹ);

            var f =
                 If(A_Is(Odd))                                  // (2, false) -> 2, (2, true) -> 2
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(from_A_To_A_OrTo_Aʹ_With(Add(200)))   // (3, false) -> 225, (3, true) -> 225
                    .If(A_Is(MoreThen(900)))                    // (803, false) -> 1025, (803, true) -> 1025
                    .AndIf(A_Is(LessThen(1000)))                // (701, false) -> 923
                    .AndIf(Is<Aʹ>)                              // (701, true) -> 923
                    .AndIf(Aʹ_Is(EndingWith("7")))              // (703, false) -> 927
                        .Then(From_Aʹ_To_A_With(Add(3)))
                        .Then(From_A_To_A_With(Add(30)))
                        .Then(From_A_To_A_With(Add(300)))       // (705, true) -> 1260
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test_0812( 1 -> 1 )")]
        [TestCase(2,    ExpectedResult = 2,    TestName = "Test_0812( 2 -> 2 )")]
        [TestCase(4,    ExpectedResult = 6,    TestName = "Test_0812( 4 -> 6 )")]
        [TestCase(14,   ExpectedResult = 16,   TestName = "Test_0812( 14 -> 16 )")]
        [TestCase(1004, ExpectedResult = 1009, TestName = "Test_0812( 1004 -> 1009 )")]
        public int Test_0812(int x)
        {
            var f =
                 If(B_Is(Even))                             // 1 -> 1, 2 -> 2
                .AndIf(B_Is(EndingWith("4")))
                    .Then(From_B_To_Bʹ_With(Add(2)))        // 4 -> 6, 14 -> 16
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Add(3)))    // 1004 -> 1009
                    .End()
                .End();

            B result = f(new B(x));

            return result.Value;
        }

        [TestCase(false, 2,  ExpectedResult = 2,  TestName = "Test_0813( false, 2 -> 2 )")]
        [TestCase(false, 12, ExpectedResult = 12, TestName = "Test_0813( false, 12 -> 12 )")]
        [TestCase(true,  2,  ExpectedResult = 2,  TestName = "Test_0813( true, 2 -> 2 )")]
        [TestCase(true,  2,  ExpectedResult = 2,  TestName = "Test_0813( true, 1 -> 1 )")]
        [TestCase(true,  12, ExpectedResult = 14, TestName = "Test_0813( true, 12 -> 14 )")]
        public int Test_0813(bool isAʹ, int x)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                            // (false, 2) -> 2, (false, 12) -> 12
                    .If(Aʹ_Is(Even)).AndIf(Aʹ_Is(MoreThen(10)))  // (true, 2) -> 2, (true, 1) -> 1
                        .Then(From_Aʹ_To_A_With(Add(2)))         // (true, 12) -> 14
                    .End()
                .End();

            A arg = isAʹ
                ? new Aʹ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(true,  2,  ExpectedResult = 2,  TestName = "Test_0814( true, 2 -> 2 )")]
        [TestCase(true,  2,  ExpectedResult = 2,  TestName = "Test_0814( true, 1 -> 1 )")]
        [TestCase(false, 2,  ExpectedResult = 2,  TestName = "Test_0814( false, 2 -> 2 )")]
        [TestCase(false, 12, ExpectedResult = 12, TestName = "Test_0814( false, 12 -> 12 )")]
        [TestCase(true,  12, ExpectedResult = 14, TestName = "Test_0814( true, 12 -> 14 )")]
        public int Test_0814(bool isAʹ, int x)
        {
            var f =
                 If(A_Is(Even)).AndIf(A_Is(MoreThen(10)))   // (true, 2) -> 2, (true, 1) -> 1
                    .If(Is<Aʹ>)                             // (false, 2) -> 2, (false, 12) -> 12
                        .Then(From_Aʹ_To_A_With(Add(2)))    // (true, 12) -> 14
                    .End()
                .End();

            A arg = isAʹ
                ? new Aʹ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(true,  2,  ExpectedResult = 2,  TestName = "Test_0815( true, 2 -> 2 )")]
        [TestCase(true,  2,  ExpectedResult = 2,  TestName = "Test_0815( true, 1 -> 1 )")]
        [TestCase(false, 2,  ExpectedResult = 2,  TestName = "Test_0815( false, 2 -> 2 )")]
        [TestCase(false, 12, ExpectedResult = 14, TestName = "Test_0815( false, 12 -> 14 )")]
        [TestCase(true,  12, ExpectedResult = 16, TestName = "Test_0815( true, 12 -> 14 )")]
        public int Test_0815(bool isAʹ, int x)
        {
            var f =
                 If(A_Is(Even)).AndIf(A_Is(MoreThen(10)))   // (true, 2) -> 2, (true, 1) -> 1, (false, 2) -> 2
                    .If(Is<Aʹ>)                             // (false, 12) -> 14 // +2
                        .Then(From_Aʹ_To_A_With(Add(2)))    // (true, 12) -> 16  // +2
                    .End()
                    .Then(From_A_To_A_With(Add(2)))
                .End();

            A arg = isAʹ
                ? new Aʹ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }
    }
}
