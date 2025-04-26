namespace Nuisho.Elifir.Test;

using static Syntax;
using static Utils;

[TestFixture]
public class IfThenElseTest_11
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

    [TestCase(true, ExpectedResult = 11, TestName = "Test_1113( true, 1 -> 11 )")]
    [TestCase(false, ExpectedResult = 21, TestName = "Test_1113( false, 1 -> 21 )")]
    public int Test_1113(bool isAʹ)
    {
        var f =
            If(Object<A>.Is<Aʹ>)
                .Then(From_Aʹ_To_A_With(Add(10)))   // (true, 1) -> 11
           .Else()
                .Then(From_A_To_A_With(Add(20)))    // (false, 1) -> 21
           .End();

        var arg = isAʹ
            ? new Aʹ(1)
            : new A(1);

        A result = f(arg);

        return result.Value;
    }

    [TestCase(true, ExpectedResult = 111, TestName = "Test_1114( true, 1 -> 111 )")]
    [TestCase(false, ExpectedResult = 221, TestName = "Test_1114( false, 1 -> 221 )")]
    public int Test_1114(bool isAʹ)
    {
        var f =
            If(Object<A>.Is<Aʹ>)
                .Then(From_Aʹ_To_A_With(Add(10)))
                .Then(From_A_To_A_With(Add(100)))   // (true, 1) -> 111
           .Else()
                .Then(From_A_To_A_With(Add(20)))
                .Then(From_A_To_Aʹ_With(Add(200)))  // (false, 1) -> 221
           .End();

        var arg = isAʹ
            ? new Aʹ(1)
            : new A(1);

        A result = f(arg);

        return result.Value;
    }

    [TestCase(true, ExpectedResult = 1111, TestName = "Test_1115( true, 1 -> 1111 )")]
    [TestCase(false, ExpectedResult = 2221, TestName = "Test_1115( false, 1 -> 2221 )")]
    public int Test_1115(bool isAʹ)
    {
        var f =
            If(Object<A>.Is<Aʹ>)
                .Then(From_Aʹ_To_A_With(Add(10)))
                .Then(From_A_To_A_With(Add(100)))
                .Then(From_A_To_Aʹ_With(Add(1000))) // (true, 1) -> 1111
           .Else()
                .Then(From_A_To_A_With(Add(20)))
                .Then(From_A_To_A_With(Add(200)))
                .Then(From_A_To_A_With(Add(2000)))  // (false, 1) -> 2221
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
                .If(Is<Aʺʺʺʺ>)
                    .If(Is<Aʺʺʺʺʹ>)
                        .Then(From_A_To_A_With(Add(1)))                 // (0, Aʺʺʺʺʹ) -> 101 // +100
                    .Else()
                        .Then(From_A_To_A_With(Add(10)))                // (0, Aʺʺʺʺ) -> 110 // +100
                    .End()
                .End()
                .Then(From_A_To_A_With(Add(100)))                       // (0, Aʺʺʺʹ) -> 100
            .Else()
                .If(Is<Aʺʺ>)
                    .If(Is<Aʺʺʺ>)
                        .Then(From_A_To_A_With(Add(1000)))              // (0, Aʺʺʺ) -> 101000 // +100000
                    .Else()
                        .If(Is<Aʺʺʹ>)
                            .Then(From_A_To_A_With(Add(10000)))         // (0, Aʺʺʹ) -> 110000 // +100000
                        .End()
                    .End()
                    .Then(From_A_To_A_With(Add(100000)))                // (0, Aʺʺ) -> 100000
                .Else()
                    .If(Is<Aʺʹ>)
                        .Then(From_A_To_A_With(Add(1000000)))           // (0, Aʺʹ) -> 1000000
                    .Else()
                        .If(Is<Aʺ>)
                            .Then(From_A_To_A_With(Add(10000000)))      // (0, Aʺ) -> 10000000
                        .Else()
                            .If(Is<Aʹ>)
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

    [TestCase(49, ExpectedResult = 149, TestName = "Test_1130( 49 -> 149 )")]
    [TestCase(39, ExpectedResult = 239, TestName = "Test_1130( 39 -> 239 )")]
    [TestCase(29, ExpectedResult = 329, TestName = "Test_1130( 29 -> 329 )")]
    [TestCase(19, ExpectedResult = 419, TestName = "Test_1130( 19 -> 419 )")]
    [TestCase(9,  ExpectedResult = 509, TestName = "Test_1130( 9 -> 509 )")]
    public int Test_1130(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .If(A_Is(MoreThen(20)))
                    .If(A_Is(MoreThen(30)))
                        .If(A_Is(MoreThen(40)))
                            .Then(From_A_To_A_With(Add(100)))   // 49 -> 149
                        .Else()
                            .Then(From_A_To_A_With(Add(200)))   // 39 -> 239
                        .End()
                    .Else()
                        .Then(From_A_To_A_With(Add(300)))       // 29 -> 329
                    .End()
                .Else()
                    .Then(From_A_To_A_With(Add(400)))           // 19 -> 419
                .End()
            .Else()
                .Then(From_A_To_A_With(Add(500)))               // 9 -> 509
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(3,  ExpectedResult = 14, TestName = "Test_1131( 3 -> 14 )")]
    [TestCase(14, ExpectedResult = 47, TestName = "Test_1131( 14 -> 47 )")]
    [TestCase(1,  ExpectedResult = 34, TestName = "Test_1131( 1 -> 34 )")]
    public int Test_1131(int x)
    {
        var f =
            If(A_Is(MoreThen(2)))
                .Then(From_A_To_B_With(Add(1)))
                .Then(From_B_To_Aʹ_With(Add(10)))       // 3 -> 14
                .If(A_Is(MoreThen(20)))
                    .Then(From_A_To_C_With(Add(2)))
                    .Then(From_C_To_A_With(Add(20)))    // 14 -> 47
                .End()
           .Else()
                .Then(From_A_To_A_With(Add(3)))
                .Then(From_A_To_A_With(Add(30)))        // 1 -> 34
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 22, TestName = "Test_1132( 11 -> 22 )")]
    [TestCase(3,  ExpectedResult = 25, TestName = "Test_1132( 3 -> 25 )")]
    [TestCase(7,  ExpectedResult = 62, TestName = "Test_1132( 7 -> 62 )")]
    public int Test_1132(int x)
    {
        var f =
            If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))
                .Then(From_A_To_A_With(Add(10)))        // 11 -> 22
           .Else()
                .Then(From_A_To_A_With(Add(2)))
                .Then(From_A_To_A_With(Add(20)))        // 3 -> 25
                .If(A_Is(MoreThen(25)))
                    .Then(From_A_To_A_With(Add(3)))
                    .Then(From_A_To_Aʹ_With(Add(30)))   // 7 -> 62
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(3,  ExpectedResult = 14, TestName = "Test_1133( 3 -> 14 )")]
    [TestCase(13, ExpectedResult = 46, TestName = "Test_1133( 13 -> 46 )")]
    [TestCase(2,  ExpectedResult = 35, TestName = "Test_1133( 2 -> 35 )")]
    [TestCase(12, ExpectedResult = 89, TestName = "Test_1133( 12 -> 89 )")]
    public int Test_1133(int x)
    {
        var f =
            If(B_Is(Odd))
                .Then(From_B_To_C_With(Add(1)))
                .Then(From_C_To_Aʹ_With(Add(10)))       // 3 -> 14
                .If(Aʹ_Is(MoreThen(20)))
                    .Then(From_Aʹ_To_E_With(Add(2)))
                    .Then(From_E_To_A_With(Add(20)))    // 13 -> 46
                .End()
           .Else()
                .Then(From_B_To_D_With(Add(3)))
                .Then(From_D_To_A_With(Add(30)))        // 2 -> 35
                .If(A_Is(MoreThen(40)))
                    .Then(From_A_To_E_With(Add(4)))
                    .Then(From_E_To_Aʹ_With(Add(40)))   // 12 -> 89
                .End()
           .End();

        A result = f(new B(x));

        return result.Value;
    }

    [TestCase(1,   ExpectedResult = 1,   TestName = "Test_1134( 1 -> 1 )")]
    [TestCase(250, ExpectedResult = 283, TestName = "Test_1134( 250 -> 283 )")]
    [TestCase(150, ExpectedResult = 194, TestName = "Test_1134( 150 -> 194 )")]
    [TestCase(60,  ExpectedResult = 154, TestName = "Test_1134( 60 -> 154 )")]
    [TestCase(40,  ExpectedResult = 176, TestName = "Test_1134( 40 -> 176 )")]
    [TestCase(20,  ExpectedResult = 198, TestName = "Test_1134( 20 -> 198 )")]
    public int Test_1134(int x)
    {
        var f =
            If(B_Is(MoreThen(100)))                             // 1 -> 1
                .Then(From_B_To_E_With(Add(1)))
                .Then(From_E_To_C_With(Add(10)))
                .If(C_Is(MoreThen(200)))
                    .Then(From_C_To_D_With(Add(2)))
                    .Then(From_D_To_B_With(Add(20)))            // 250 -> 283
                .Else()
                    .Then(From_C_To_E_With(Add(3)))
                    .Then(From_E_To_Bʹ_With(Add(30)))           // 150 -> 194
                .End()
           .Else()
                .If(B_Is(MoreThen(50)))
                    .Then(From_B_To_E_With(Add(4)))
                    .Then(From_E_To_D_With(Add(40)))
                    .Then(From_D_To_Bʹ_With(Add(50)))           // 60 -> 154
                .Else()
                    .If(B_Is(MoreThen(30)))
                        .Then(From_B_To_E_With(Add(6)))
                        .Then(From_E_To_D_With(Add(60)))
                        .Then(From_D_To_B_With(Add(70)))        // 40 -> 176
                    .Else()
                        .If(B_Is(MoreThen(10)))
                            .Then(From_B_To_E_With(Add(8)))
                            .Then(From_E_To_C_With(Add(80)))
                            .Then(From_C_To_Bʹ_With(Add(90)))   // 20 -> 198
                        .End()
                    .End()
                .End()
            .End();

        B result = f(new B(x));

        return result.Value;
    }

    [TestCase(1, ExpectedResult = 4,  TestName = "Test_1135( 1 -> 4 )")]
    [TestCase(2, ExpectedResult = 4,  TestName = "Test_1135( 2 -> 4 )")]
    [TestCase(9, ExpectedResult = 16, TestName = "Test_1135( 9 -> 16 )")]
    public int Test_1135(int x)
    {
        var f =
            If(A_Is(Even))
                .Then(From_A_To_Aʹ_With(Add(2)))        // 2 -> 4
           .Else()
                .Then(From_A_To_Aʹ_With(Add(3)))        // 1 -> 4
                .If(Aʹ_Is(MoreThen(10)))
                    .Then(From_Aʹ_To_A_With(Add(4)))    // 9 -> 16
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2, ExpectedResult = 4,  TestName = "Test_1136( 2 -> 4 )")]
    [TestCase(3, ExpectedResult = 6,  TestName = "Test_1136( 3 -> 6 )")]
    [TestCase(9, ExpectedResult = 16, TestName = "Test_1136( 9 -> 16 )")]
    public int Test_1136(int x)
    {
        var f =
            If(A_Is(Even))
                .Then(From_A_To_A_With(Add(2)))         // 2 -> 4
           .Else()
                .Then(From_A_To_A_With(Add(3)))         // 3 -> 6
                .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_Aʹ_With(Add(4)))    // 9 -> 16
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(3,  ExpectedResult = 3,  TestName = "Test_1137( 3 -> 3 )")]
    [TestCase(10, ExpectedResult = 13, TestName = "Test_1137( 10 -> 13 )")]
    [TestCase(2,  ExpectedResult = 6,  TestName = "Test_1137( 2 -> 6 )")]
    public int Test_1137(int x)
    {
        var f =
            If(A_Is(Even))                              // 3 -> 3
                .Then(From_A_To_A_With(Add(1)))
                .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_Aʹ_With(Add(2)))    // 10 -> 13
                .Else()
                    .Then(From_A_To_A_With(Add(3)))     // 2 -> 6
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(3,  ExpectedResult = 3,  TestName = "Test_1138( 3 -> 3 )")]
    [TestCase(10, ExpectedResult = 13, TestName = "Test_1138( 10 -> 13 )")]
    [TestCase(2,  ExpectedResult = 6,  TestName = "Test_1138( 2 -> 6 )")]
    public int Test_1138(int x)
    {
        var f =
            If(A_Is(Even))                              // 3 -> 3
                .Then(From_A_To_A_With(Add(1)))
                .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_A_With(Add(2)))     // 10 -> 13
                .Else()
                    .Then(From_A_To_Aʹ_With(Add(3)))    // 2 -> 6
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(3, ExpectedResult = 3,  TestName = "Test_1139( 3 -> 3 )")]
    [TestCase(8, ExpectedResult = 14, TestName = "Test_1139( 8 -> 14 )")]
    [TestCase(6, ExpectedResult = 13, TestName = "Test_1139( 6 -> 13 )")]
    public int Test_1139(int x)
    {
        var f =
            If(A_Is(Even))                                  // 3 -> 3
                .Then(From_A_To_A_With(Add(1)))
                .If(A_Is(MoreThen(5)))
                    .Then(From_A_To_A_With(Add(2)))
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_Aʹ_With(Add(3)))    // 8 -> 14
                    .Else()
                        .Then(From_A_To_A_With(Add(4)))     // 6 -> 13
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(3, ExpectedResult = 3,  TestName = "Test_1140( 3 -> 3 )")]
    [TestCase(8, ExpectedResult = 14, TestName = "Test_1140( 8 -> 14 )")]
    [TestCase(6, ExpectedResult = 13, TestName = "Test_1140( 6 -> 13 )")]
    public int Test_1140(int x)
    {
        var f =
            If(A_Is(Even))                                  // 3 -> 3
                .Then(From_A_To_A_With(Add(1)))
                .If(A_Is(MoreThen(5)))
                    .Then(From_A_To_A_With(Add(2)))
                    .If(A_Is(MoreThen(10)))
                        .Then(From_A_To_A_With(Add(3)))    // 8 -> 14
                    .Else()
                        .Then(From_A_To_Aʹ_With(Add(4)))     // 6 -> 13
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,  false, ExpectedResult = 1,  TestName = "Test_1150( 1, false -> 1 )")]
    [TestCase(1,  true,  ExpectedResult = 1,  TestName = "Test_1150( 1, true -> 1 )")]
    [TestCase(12, true,  ExpectedResult = 15, TestName = "Test_1150( 12, true -> 15 )")]
    [TestCase(12, false, ExpectedResult = 13, TestName = "Test_1150( 12, false -> 13 )")]
    [TestCase(2,  false, ExpectedResult = 6,  TestName = "Test_1150( 2, false -> 6 )")]
    [TestCase(2,  true,  ExpectedResult = 6,  TestName = "Test_1150( 2, true -> 6 )")]
    public int Test_1150(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Even))                                  // (false, 1) -> 1, (1, true) -> 1
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))
                .If(A_Is(MoreThen(10)))
                    .If(Is<Aʹ>)
                        .Then(From_Aʹ_To_A_With(Add(2)))    // (12, true) -> 15
                    .End()                                  // (12, false) -> 13
                .Else()
                    .Then(From_A_To_A_With(Add(3)))         // (2, false) -> 3, (2, true) -> 3
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,  false, ExpectedResult = 1,  TestName = "Test_1151( 1, false -> 1 )")]
    [TestCase(1,  true,  ExpectedResult = 1,  TestName = "Test_1151( 1, true -> 1 )")]
    [TestCase(12, true,  ExpectedResult = 15, TestName = "Test_1151( 12, true -> 15 )")]
    [TestCase(2,  true,  ExpectedResult = 3,  TestName = "Test_1151( 2, true -> 3 )")]
    [TestCase(12, false, ExpectedResult = 16, TestName = "Test_1151( 12, false -> 16 )")]
    public int Test_1151(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Even))                                  // (false, 1) -> 1, (1, true) -> 1
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))
                .If(Is<Aʹ>)
                    .If(A_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_A_With(Add(2)))    // (12, true) -> 15
                    .End()                                  // (2, true) -> 3
                .Else()
                    .Then(From_A_To_A_With(Add(3)))         // (12, false) -> 16
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,   false, ExpectedResult = 1,   TestName = "Test_1152( 1, false -> 1 )")]
    [TestCase(12,  false, ExpectedResult = 13,  TestName = "Test_1152( 12, false -> 13 )")]
    [TestCase(111, true,  ExpectedResult = 117, TestName = "Test_1152( 111, true -> 117 )")]
    [TestCase(11,  true,  ExpectedResult = 14,  TestName = "Test_1152( 11, true -> 14 )")]
    [TestCase(11,  false, ExpectedResult = 18,  TestName = "Test_1152( 11, false -> 18 )")]
    public int Test_1152(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(MoreThen(10)))                              // (1, false) -> 1
                .Then(From_A_To_A_With(Add(1)))                 // (12, false) -> 13
                .If(A_Is(Even))
                    .Then(from_A_To_A_OrTo_Aʹ_With(Add(2)))
                    .If(Is<Aʹ>)
                        .If(A_Is(MoreThen(100)))
                            .Then(From_Aʹ_To_A_With(Add(3)))    // (111, true) -> 117
                        .End()                                  // (11, true) -> 14
                    .Else()
                        .Then(From_A_To_A_With(Add(4)))         // (11, false) -> 18
                    .End()
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,   false, ExpectedResult = 1,   TestName = "Test_1153( 1, false -> 1 )")]
    [TestCase(12,  false, ExpectedResult = 13,  TestName = "Test_1153( 12, false -> 13 )")]
    [TestCase(313, false, ExpectedResult = 316, TestName = "Test_1153( 313, false -> 316 )")]
    [TestCase(113, false, ExpectedResult = 119, TestName = "Test_1153( 113, false -> 119 )")]
    [TestCase(11,  false, ExpectedResult = 14,  TestName = "Test_1153( 11, false -> 14 )")]
    [TestCase(13,  true,  ExpectedResult = 16,  TestName = "Test_1153( 13, true -> 16 )")]
    [TestCase(11,  true,  ExpectedResult = 18,  TestName = "Test_1153( 11, true -> 18 )")]
    public int Test_1153(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
             If(A_Is(MoreThen(10)))                                 // (1, false) -> 1
                .Then(From_A_To_A_With(Add(1)))                     // (12, false) -> 13
                .If(A_Is(Even))
                    .Then(from_A_To_A_OrTo_Aʹ_With(Add(2)))
                    .If(A_Is(MoreThen(50)))
                        .If(A_Is(LessThen(200)))                    // (313, false) -> 316
                            .Then(From_A_To_A_With(Add(3)))         // (113, false) -> 119
                        .End()
                    .Else()
                        .If(Is<Aʹ>)                                 // (11, false) -> 14
                            .If(A_Is(EndingWith("4")))              // (13, true) -> 16
                                .Then(From_Aʹ_To_A_With(Add(4)))    // (11, true) -> 18
                            .End()
                        .End()
                    .End()
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(1,  false, ExpectedResult = 1,  TestName = "Test_1154( 1, false -> 1 )")]
    [TestCase(10, false, ExpectedResult = 13, TestName = "Test_1154( 10, false -> 13 )")]
    [TestCase(2,  false, ExpectedResult = 6,  TestName = "Test_1154( 2, false -> 6 )")]
    [TestCase(2,  true,  ExpectedResult = 10, TestName = "Test_1154( 2, true -> 10 )")]
    public int Test_1554(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Even))                                      // (1, false) -> 1
                .Then(From_A_To_A_With(Add(1)))
                .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_A_With(Add(2)))             // (10, false) -> 13
                .Else()
                    .Then(from_A_To_A_OrTo_Aʹ_With(Add(3)))     // (2, false) -> 6
                    .If(Is<Aʹ>)
                        .Then(From_Aʹ_To_A_With(Add(4)))        // (2, true) -> 10
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }
}
