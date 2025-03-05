﻿namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class IfThenElseTest
    {
        [TestCase(3, ExpectedResult = 13, TestName = "Test_1100( 3 -> 13 )")]
        [TestCase(1, ExpectedResult = 21, TestName = "Test_1100( 1 -> 21 )")]
        public int Test_1100(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(10)))    // 3 -> 13
               .Else()
                    .Then(From_A_To_A_With(Add(20)))    // 1 -> 21
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 113, TestName = "Test_1101( 3 -> 113 )")]
        [TestCase(1, ExpectedResult = 221, TestName = "Test_1101( 1 -> 221 )")]
        public int Test_1101(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(10)))
                    .Then(From_A_To_A_With(Add(100)))   // 3 -> 113
               .Else()
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))   // 1 -> 221
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 1113, TestName = "Test_1102( 3 -> 1113 )")]
        [TestCase(1, ExpectedResult = 2221, TestName = "Test_1102( 1 -> 2221 )")]
        public int Test_1102(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(10)))
                    .Then(From_A_To_A_With(Add(100)))
                    .Then(From_A_To_A_With(Add(1000)))  // 3 -> 1113
               .Else()
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))
                    .Then(From_A_To_A_With(Add(2000)))  // 1 -> 2221
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 13, TestName = "Test_1103( 3 -> 13 )")]
        [TestCase(1, ExpectedResult = 21, TestName = "Test_1103( 1 -> 21 )")]
        public int Test_1103(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Aʹ_With(Add(10)))   // 3 -> 13
               .Else()
                    .Then(From_A_To_A_With(Add(20)))    // 1 -> 21
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 13, TestName = "Test_1104( 3 -> 13 )")]
        [TestCase(1, ExpectedResult = 21, TestName = "Test_1104( 1 -> 21 )")]
        public int Test_1104(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(10)))    // 3 -> 13
               .Else()
                    .Then(From_A_To_Aʹ_With(Add(20)))   // 1 -> 21
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 13, TestName = "Test_1105( 3 -> 13 )")]
        [TestCase(1, ExpectedResult = 21, TestName = "Test_1105( 1 -> 21 )")]
        public int Test_1105(int x)
        {
            var f =
                If(B_Is(MoreThen(2)))
                    .Then(From_B_To_Aʹ_With(Add(10)))   // 3 -> 13
               .Else()
                    .Then(From_B_To_A_With(Add(20)))    // 1 -> 21
               .End();

            A result = f(new B(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 13, TestName = "Test_1106( 3 -> 13 )")]
        [TestCase(1, ExpectedResult = 21, TestName = "Test_1106( 1 -> 21 )")]
        public int Test_1106(int x)
        {
            var f =
                If(B_Is(MoreThen(2)))
                    .Then(From_B_To_A_With(Add(10)))    // 3 -> 13
               .Else()
                    .Then(From_B_To_Aʹ_With(Add(20)))   // 1 -> 21
               .End();

            A result = f(new B(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 113, TestName = "Test_1107( 3 -> 113 )")]
        [TestCase(1, ExpectedResult = 221, TestName = "Test_1107( 1 -> 221 )")]
        public int Test_1107(int x)
        {
            var f =
                If(B_Is(MoreThen(2)))
                    .Then(From_B_To_C_With(Add(10)))
                    .Then(From_C_To_D_With(Add(100)))   // 3 -> 113
               .Else()
                    .Then(From_B_To_E_With(Add(20)))
                    .Then(From_E_To_D_With(Add(200)))   // 1 -> 221
               .End();

            D result = f(new B(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 113, TestName = "Test_1108( 3 -> 113 )")]
        [TestCase(1, ExpectedResult = 221, TestName = "Test_1108( 1 -> 221 )")]
        public int Test_1108(int x)
        {
            var f =
                If(B_Is(MoreThen(2)))
                    .Then(From_B_To_D_With(Add(10)))
                    .Then(From_D_To_Cʹ_With(Add(100)))  // 3 -> 113
               .Else()
                    .Then(From_B_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))   // 1 -> 221
               .End();

            C result = f(new B(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 113, TestName = "Test_1109( 3 -> 113 )")]
        [TestCase(1, ExpectedResult = 221, TestName = "Test_1109( 1 -> 221 )")]
        public int Test_1109(int x)
        {
            var f =
                If(B_Is(MoreThen(2)))
                    .Then(From_B_To_D_With(Add(10)))
                    .Then(From_D_To_C_With(Add(100)))   // 3 -> 113
               .Else()
                    .Then(From_B_To_E_With(Add(20)))
                    .Then(From_E_To_Cʹ_With(Add(200)))  // 1 -> 221
               .End();

            C result = f(new B(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 1113, TestName = "Test_1110( 3 -> 1113 )")]
        [TestCase(1, ExpectedResult = 2221, TestName = "Test_1110( 1 -> 2221 )")]
        public int Test_1110(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_D_With(Add(10)))
                    .Then(From_D_To_E_With(Add(100)))
                    .Then(From_E_To_B_With(Add(1000)))  // 3 -> 1113
               .Else()
                    .Then(From_A_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))
                    .Then(From_C_To_B_With(Add(2000)))  // 1 -> 2221
               .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 1113, TestName = "Test_1111( 3 -> 1113 )")]
        [TestCase(1, ExpectedResult = 2221, TestName = "Test_1111( 1 -> 2221 )")]
        public int Test_1111(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_D_With(Add(10)))
                    .Then(From_D_To_E_With(Add(100)))
                    .Then(From_E_To_Bʹ_With(Add(1000))) // 3 -> 1113
               .Else()
                    .Then(From_A_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))
                    .Then(From_C_To_B_With(Add(2000)))  // 1 -> 2221
               .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 1113, TestName = "Test_1112( 3 -> 1113 )")]
        [TestCase(1, ExpectedResult = 2221, TestName = "Test_1112( 1 -> 2221 )")]
        public int Test_1112(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_D_With(Add(10)))
                    .Then(From_D_To_E_With(Add(100)))
                    .Then(From_E_To_B_With(Add(1000)))  // 3 -> 1113
               .Else()
                    .Then(From_A_To_E_With(Add(20)))
                    .Then(From_E_To_C_With(Add(200)))
                    .Then(From_C_To_Bʹ_With(Add(2000))) // 1 -> 2221
               .End();

            B result = f(new A(x));

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 21, TestName = "Test_1113( false, 1 -> 21 )")]
        [TestCase(true,  ExpectedResult = 11, TestName = "Test_1113( true, 1 -> 11 )")]
        public int Test_1113(bool isAʹ)
        {
            var f =
                If(Object<A>.Is<Aʹ>)
                    .Then(From_Aʹ_To_A_With(Add(10)))   // (false, 1) -> 21
               .Else()
                    .Then(From_A_To_A_With(Add(20)))    // (true, 1) -> 11
               .End();

            var arg = isAʹ
                ? new Aʹ(1)
                : new A(1);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 221, TestName = "Test_1114( false, 1 -> 221 )")]
        [TestCase(true,  ExpectedResult = 111, TestName = "Test_1114( true, 1 -> 111 )")]
        public int Test_1114(bool isAʹ)
        {
            var f =
                If(Object<A>.Is<Aʹ>)
                    .Then(From_Aʹ_To_A_With(Add(10)))
                    .Then(From_A_To_A_With(Add(100)))   // (false, 1) -> 221
               .Else()
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_Aʹ_With(Add(200)))  // (true, 1) -> 111
               .End();

            var arg = isAʹ
                ? new Aʹ(1)
                : new A(1);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 2221, TestName = "Test_1115( false, 1 -> 2221 )")]
        [TestCase(true,  ExpectedResult = 1111, TestName = "Test_1115( true, 1 -> 1111 )")]
        public int Test_1115(bool isAʹ)
        {
            var f =
                If(Object<A>.Is<Aʹ>)
                    .Then(From_Aʹ_To_A_With(Add(10)))
                    .Then(From_A_To_A_With(Add(100)))
                    .Then(From_A_To_Aʹ_With(Add(1000))) // (false, 1) -> 2221
               .Else()
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))
                    .Then(From_A_To_A_With(Add(2000)))  // (true, 1) -> 1111
               .End();

            var arg = isAʹ
                ? new Aʹ(1)
                : new A(1);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(3,  ExpectedResult = 13, TestName = "Test_1116( 3 -> 13 )")]
        [TestCase(14, ExpectedResult = 44, TestName = "Test_1116( 14 -> 44 )")]
        [TestCase(1,  ExpectedResult = 31, TestName = "Test_1116( 1 -> 31 )")]
        public int Test_1116(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Aʹ_With(Add(10)))       // 3 -> 13
                    .If(A_Is(MoreThen(20)))
                        .Then(From_A_To_A_With(Add(20)))    // 14 -> 44
                    .End()
               .Else()
                    .Then(From_A_To_A_With(Add(30)))        // 1 -> 31
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 21, TestName = "Test_1117( 11 -> 21 )")]
        [TestCase(3,  ExpectedResult = 23, TestName = "Test_1117( 3 -> 23 )")]
        [TestCase(7,  ExpectedResult = 57, TestName = "Test_1117( 7 -> 57 )")]
        public int Test_1117(int x)
        {
            var f =
                If(A_Is(MoreThen(10)))
                    .Then(From_A_To_A_With(Add(10)))        // 11 -> 21
               .Else()
                    .Then(From_A_To_A_With(Add(20)))        // 3 -> 23
                    .If(A_Is(MoreThen(25)))
                        .Then(From_A_To_Aʹ_With(Add(30)))   // 7 -> 57
                    .End()
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3,  ExpectedResult = 13, TestName = "Test_1118( 3 -> 13 )")]
        [TestCase(13, ExpectedResult = 43, TestName = "Test_1118( 13 -> 43 )")]
        [TestCase(2,  ExpectedResult = 32, TestName = "Test_1118( 2 -> 32 )")]
        [TestCase(12, ExpectedResult = 82, TestName = "Test_1118( 12 -> 82 )")]
        public int Test_1118(int x)
        {
            var f =
                If(B_Is(Odd))
                    .Then(From_B_To_Aʹ_With(Add(10)))       // 3 -> 13
                    .If(Aʹ_Is(MoreThen(20)))
                        .Then(From_Aʹ_To_A_With(Add(20)))   // 13 -> 43
                    .End()
               .Else()
                    .Then(From_B_To_A_With(Add(30)))        // 2 -> 32
                    .If(A_Is(MoreThen(40)))
                        .Then(From_A_To_Aʹ_With(Add(40)))   // 12 -> 82
                    .End()
               .End();

            A result = f(new B(x));

            return result.Value;
        }

        [TestCase(1,   ExpectedResult = 1,   TestName = "Test_1120( 1 -> 1 )")]
        [TestCase(250, ExpectedResult = 280, TestName = "Test_1120( 250 -> 280 )")]
        [TestCase(150, ExpectedResult = 190, TestName = "Test_1120( 150 -> 190 )")]
        [TestCase(60,  ExpectedResult = 150, TestName = "Test_1120( 60 -> 150 )")]
        [TestCase(40,  ExpectedResult = 170, TestName = "Test_1120( 40 -> 170 )")]
        [TestCase(20,  ExpectedResult = 190, TestName = "Test_1120( 20 -> 190 )")]
        public int Test_1120(int x)
        {
            var f =
                If(B_Is(MoreThen(100)))                             // 1 -> 1
                    .Then(From_B_To_C_With(Add(10)))                
                    .If(C_Is(MoreThen(200)))
                        .Then(From_C_To_B_With(Add(20)))            // 250 -> 280
                    .Else()
                        .Then(From_C_To_Bʹ_With(Add(30)))           // 150 -> 190
                    .End()
               .Else()
                    .If(B_Is(MoreThen(50)))
                        .Then(From_B_To_E_With(Add(40)))
                        .Then(From_E_To_Bʹ_With(Add(50)))           // 60 -> 150
                    .Else()
                        .If(B_Is(MoreThen(30)))
                            .Then(From_B_To_D_With(Add(60)))
                            .Then(From_D_To_B_With(Add(70)))        // 40 -> 170
                        .Else()
                            .If(B_Is(MoreThen(10)))
                                .Then(From_B_To_E_With(Add(80)))
                                .Then(From_E_To_Bʹ_With(Add(90)))   // 20 -> 190
                            .End()
                        .End()
                    .End()
                .End();

            B result = f(new B(x));

            return result.Value;
        }

        [TestCase("Aʺʺʺʺʹ", ExpectedResult = 101,       TestName = "Test_1121( 0, Aʺʺʺʺʹ -> 101 )")]
        [TestCase("Aʺʺʺʺ",  ExpectedResult = 110,       TestName = "Test_1121( 0, Aʺʺʺʺ -> 110 )")]
        [TestCase("Aʺʺʺʹ",  ExpectedResult = 100,       TestName = "Test_1121( 0, Aʺʺʺʹ -> 100 )")]
        [TestCase("Aʺʺʺ",   ExpectedResult = 101000,    TestName = "Test_1121( 0, Aʺʺʺ -> 101000 )")]
        [TestCase("Aʺʺʹ",   ExpectedResult = 110000,    TestName = "Test_1121( 0, Aʺʺʹ -> 110000 )")]
        [TestCase("Aʺʺ",    ExpectedResult = 100000,    TestName = "Test_1121( 0, Aʺʺ -> 100000 )")]
        [TestCase("Aʺʹ",    ExpectedResult = 1000000,   TestName = "Test_1121( 0, Aʺʹ -> 1000000 )")]
        [TestCase("Aʺ",     ExpectedResult = 10000000,  TestName = "Test_1121( 0, Aʺ -> 10000000 )")]
        [TestCase("Aʹ",     ExpectedResult = 100000000, TestName = "Test_1121( 0, Aʹ -> 100000000 )")]
        [TestCase("A",      ExpectedResult = 0,         TestName = "Test_1121( 0, A -> 0 )")]
        public int Test_1121(string ofTypeX)
        {
            var f =
                If(Object<A>.Is<Aʺʺʺʹ>)
                    .Then(Identity)
                    .If(Object<Aʺʺʺʹ>.Is<Aʺʺʺʺ>)
                        .Then(Identity)
                        .If(Object<Aʺʺʺʺ>.Is<Aʺʺʺʺʹ>)
                            .Then(From_A_To_A_With(Add(1)))                 // (0, Aʺʺʺʺʹ) -> 101 // +100
                        .Else()
                            .Then(From_A_To_A_With(Add(10)))                // (0, Aʺʺʺʺ) -> 110 // +100
                        .End()
                    .End()
                    .Then(From_A_To_A_With(Add(100)))                       // (0, Aʺʺʺʹ) -> 100
                .Else()
                    .If(Object<A>.Is<Aʺʺ>)
                        .Then(Identity)
                        .If(Object<Aʺʺ>.Is<Aʺʺʺ>)
                            .Then(From_A_To_A_With(Add(1000)))              // (0, Aʺʺʺ) -> 101000 // +100000 
                        .Else()
                            .If(Object<Aʺʺ>.Is<Aʺʺʹ>)
                                .Then(From_A_To_A_With(Add(10000)))         // (0, Aʺʺʹ) -> 110000 // +100000
                            .End()
                        .End()
                        .Then(From_A_To_A_With(Add(100000)))                // (0, Aʺʺ) -> 100000
                    .Else()
                        .If(Object<A>.Is<Aʺʹ>)
                            .Then(From_A_To_A_With(Add(1000000)))           // (0, Aʺʹ) -> 1000000
                        .Else()
                            .If(Object<A>.Is<Aʺ>)
                                .Then(From_A_To_A_With(Add(10000000)))      // (0, Aʺ) -> 10000000
                            .Else()
                                .If(Object<A>.Is<Aʹ>)
                                    .Then(From_A_To_A_With(Add(100000000))) // (0, Aʹ) -> 100000000
                                .End()
                            .End()
                        .End()
                    .End()
                .End();                                                     // (0, A) -> 0

            A arg = From_Int_To_SomeA(ofTypeX)(0);
            A result = f(arg);

            return result.Value;
        }
    }
}
