namespace Nuisho.Elifir.Test;

using static Syntax;
using static Utils;

[TestFixture]
public class IfThenTest_06
{
    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_0600( 1 -> 1 )")]
    [TestCase(3,  ExpectedResult = 4,  TestName = "Test_0600( 3 -> 4 )")]
    [TestCase(4,  ExpectedResult = 6,  TestName = "Test_0600( 4 -> 6 )")]
    [TestCase(5,  ExpectedResult = 8,  TestName = "Test_0600( 5 -> 8 )")]
    [TestCase(6,  ExpectedResult = 10, TestName = "Test_0600( 6 -> 10 )")]
    [TestCase(7,  ExpectedResult = 12, TestName = "Test_0600( 7 -> 12 )")]
    [TestCase(8,  ExpectedResult = 14, TestName = "Test_0600( 8 -> 14 )")]
    [TestCase(9,  ExpectedResult = 16, TestName = "Test_0600( 9 -> 16 )")]
    [TestCase(10, ExpectedResult = 18, TestName = "Test_0600( 10 -> 18 )")]
    [TestCase(11, ExpectedResult = 20, TestName = "Test_0600( 11 -> 20 )")]
    [TestCase(12, ExpectedResult = 22, TestName = "Test_0600( 12 -> 22 )")]
    public int Test_0600(int x)
    {
        var f =
             If(A_Is(MoreThen(2)))  // 1 -> 1
                .Then(From_A_To_A_With(Add(1)))  // 3 -> 4
                .If(A_Is(MoreThen(4)))
                    .Then(From_A_To_A_With(Add(1))) // 4 -> 6
                    .If(A_Is(MoreThen(6)))
                        .Then(From_A_To_A_With(Add(1))) // 5 -> 8
                        .If(A_Is(MoreThen(8)))
                            .Then(From_A_To_A_With(Add(1))) // 6 -> 10
                            .If(A_Is(MoreThen(10)))
                                .Then(From_A_To_A_With(Add(1))) // 7 -> 12
                                .If(A_Is(MoreThen(12)))
                                    .Then(From_A_To_A_With(Add(1))) // 8 -> 14
                                    .If(A_Is(MoreThen(14)))
                                        .Then(From_A_To_A_With(Add(1))) // 9 -> 16
                                        .If(A_Is(MoreThen(16)))
                                            .Then(From_A_To_A_With(Add(1))) // 10 -> 18
                                            .If(A_Is(MoreThen(18)))
                                                .Then(From_A_To_A_With(Add(1))) // 11 -> 20
                                                .If(A_Is(MoreThen(20)))
                                                    .Then(From_A_To_A_With(Add(1))) // 12 -> 22
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

    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_0601( 1 -> 1 )")]
    [TestCase(3,  ExpectedResult = 4,  TestName = "Test_0601( 3 -> 4 )")]
    [TestCase(4,  ExpectedResult = 6,  TestName = "Test_0601( 4 -> 6 )")]
    [TestCase(5,  ExpectedResult = 8,  TestName = "Test_0601( 5 -> 8 )")]
    [TestCase(6,  ExpectedResult = 10, TestName = "Test_0601( 6 -> 10 )")]
    [TestCase(7,  ExpectedResult = 12, TestName = "Test_0601( 7 -> 12 )")]
    [TestCase(8,  ExpectedResult = 14, TestName = "Test_0601( 8 -> 14 )")]
    [TestCase(9,  ExpectedResult = 16, TestName = "Test_0601( 9 -> 16 )")]
    [TestCase(10, ExpectedResult = 18, TestName = "Test_0601( 10 -> 18 )")]
    [TestCase(11, ExpectedResult = 20, TestName = "Test_0601( 11 -> 20 )")]
    [TestCase(12, ExpectedResult = 22, TestName = "Test_0601( 12 -> 22 )")]
    public int Test_0601(int x)
    {
        var f =
             If(A_Is(MoreThen(2))) // 1 -> 1
                .Then(From_A_To_Aʹ_With(Add(1)))  // 3 -> 4
                .If(Aʹ_Is(MoreThen(4)))
                    .Then(From_Aʹ_To_Aʺ_With(Add(1))) // 4 -> 6
                    .If(Aʺ_Is(MoreThen(6)))
                        .Then(From_Aʺ_To_Aʺʹ_With(Add(1))) // 5 -> 8
                        .If(Aʺʹ_Is(MoreThen(8)))
                            .Then(From_Aʺʹ_To_Aʺʺ_With(Add(1))) // 6 -> 10
                            .If(Aʺʺ_Is(MoreThen(10)))
                                .Then(From_Aʺʺ_To_Aʺʺʹ_With(Add(1))) // 7 -> 12
                                .If(Aʺʺʹ_Is(MoreThen(12)))
                                    .Then(From_Aʺʺʹ_To_Aʺʺʺ_With(Add(1))) // 8 -> 14
                                    .If(Aʺʺʺ_Is(MoreThen(14)))
                                        .Then(From_Aʺʺʺ_To_Aʺʺʺʹ_With(Add(1))) // 9 -> 16
                                        .If(Aʺʺʺʹ_Is(MoreThen(16)))
                                            .Then(From_Aʺʺʺʹ_To_Aʺʺʺʺ_With(Add(1))) // 10 -> 18
                                            .If(Aʺʺʺʺ_Is(MoreThen(18)))
                                                .Then(From_Aʺʺʺʺ_To_Aʺʺʺʺʹ_With(Add(1))) // 11 -> 20
                                                .If(Aʺʺʺʺʹ_Is(MoreThen(20)))
                                                    .Then(From_Aʺʺʺʺʹ_To_Aʺʺʺʺʺ_With(Add(1))) // 12 -> 22
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

    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_0602( 1 -> 1 )")]
    [TestCase(3,  ExpectedResult = 4,  TestName = "Test_0602( 3 -> 4 )")]
    [TestCase(4,  ExpectedResult = 6,  TestName = "Test_0602( 4 -> 6 )")]
    [TestCase(5,  ExpectedResult = 8,  TestName = "Test_0602( 5 -> 8 )")]
    [TestCase(6,  ExpectedResult = 10, TestName = "Test_0602( 6 -> 10 )")]
    [TestCase(7,  ExpectedResult = 12, TestName = "Test_0602( 7 -> 12 )")]
    [TestCase(8,  ExpectedResult = 14, TestName = "Test_0602( 8 -> 14 )")]
    [TestCase(9,  ExpectedResult = 16, TestName = "Test_0602( 9 -> 16 )")]
    [TestCase(10, ExpectedResult = 18, TestName = "Test_0602( 10 -> 18 )")]
    [TestCase(11, ExpectedResult = 20, TestName = "Test_0602( 11 -> 20 )")]
    [TestCase(12, ExpectedResult = 22, TestName = "Test_0602( 12 -> 22 )")]
    public int Test_0602(int x)
    {
        var f =
             If(Aʺʺʺʺʹ_Is(MoreThen(2))) // 1 -> 1
                .Then(From_Aʺʺʺʺʹ_To_Aʺʺʺʺ_With(Add(1)))  // 2 -> 3
                .If(Aʺʺʺʺ_Is(MoreThen(4)))
                    .Then(From_Aʺʺʺʺ_To_Aʺʺʺʹ_With(Add(1))) // 3 -> 4
                    .If(Aʺʺʺʹ_Is(MoreThen(6)))
                        .Then(From_Aʺʺʺʹ_To_Aʺʺʺ_With(Add(1))) // 4 -> 6
                        .If(Aʺʺʺ_Is(MoreThen(8)))
                            .Then(From_Aʺʺʺ_To_Aʺʺʹ_With(Add(1))) // 5 -> 8
                            .If(Aʺʺʹ_Is(MoreThen(10)))
                                .Then(From_Aʺʺʹ_To_Aʺʺ_With(Add(1))) // 6 -> 10
                                .If(Aʺʺ_Is(MoreThen(12)))
                                    .Then(From_Aʺʺ_To_Aʺʹ_With(Add(1))) // 7 -> 12
                                    .If(Aʺʹ_Is(MoreThen(14)))
                                        .Then(From_Aʺʹ_To_Aʺ_With(Add(1))) // 8 -> 14
                                        .If(Aʺ_Is(MoreThen(16)))
                                            .Then(From_Aʺ_To_Aʹ_With(Add(1))) // 9 -> 16
                                            .If(Aʹ_Is(MoreThen(18)))
                                                .Then(From_Aʹ_To_A_With(Add(1))) // 11 -> 20
                                                .If(A_Is(MoreThen(20)))
                                                    .Then(From_A_To_A_With(Add(1))) // 12 -> 22
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

        A result = f(new Aʺʺʺʺʺ(x));

        return result.Value;
    }
}
