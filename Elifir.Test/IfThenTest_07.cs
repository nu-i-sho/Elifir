namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class IfThenTest_07
    {
        
        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0700( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 4,  TestName = "Test_0700( 2 -> 4 )")]
        [TestCase(3,  ExpectedResult = 6,  TestName = "Test_0700( 3 -> 6 )")]
        [TestCase(4,  ExpectedResult = 8,  TestName = "Test_0700( 4 -> 8 )")]
        [TestCase(5,  ExpectedResult = 10, TestName = "Test_0700( 5 -> 10 )")]
        [TestCase(6,  ExpectedResult = 12, TestName = "Test_0700( 6 -> 12 )")]
        [TestCase(7,  ExpectedResult = 14, TestName = "Test_0700( 7 -> 14 )")]
        [TestCase(8,  ExpectedResult = 16, TestName = "Test_0700( 8 -> 16 )")]
        [TestCase(9,  ExpectedResult = 18, TestName = "Test_0700( 9 -> 18 )")]
        [TestCase(10, ExpectedResult = 20, TestName = "Test_0700( 10 -> 20 )")]
        [TestCase(11, ExpectedResult = 22, TestName = "Test_0700( 11 -> 22 )")]
        public int Test_0700(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))  // 1 -> 2     
                .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(1)))  // 2 -> 4
                    .If(A_Is(MoreThen(4)))
                        .Then(From_A_To_A_With(Add(1))) // 3 -> 6
                        .If(A_Is(MoreThen(6)))
                            .Then(From_A_To_A_With(Add(1))) // 4 -> 8
                            .If(A_Is(MoreThen(8)))
                                .Then(From_A_To_A_With(Add(1))) // 5 -> 10  
                                .If(A_Is(MoreThen(10)))
                                    .Then(From_A_To_A_With(Add(1))) // 6 -> 12
                                    .If(A_Is(MoreThen(12)))
                                        .Then(From_A_To_A_With(Add(1))) // 7 -> 14
                                        .If(A_Is(MoreThen(14)))
                                            .Then(From_A_To_A_With(Add(1))) // 8 -> 16
                                            .If(A_Is(MoreThen(16)))
                                                .Then(From_A_To_A_With(Add(1))) // 9 -> 18
                                                .If(A_Is(MoreThen(18)))
                                                    .Then(From_A_To_A_With(Add(1))) // 10 -> 20
                                                    .If(A_Is(MoreThen(20)))
                                                        .Then(From_A_To_A_With(Add(1))) // 11 -> 22
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0701( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 4,  TestName = "Test_0701( 2 -> 4 )")]
        [TestCase(3,  ExpectedResult = 6,  TestName = "Test_0701( 3 -> 6 )")]
        [TestCase(4,  ExpectedResult = 8,  TestName = "Test_0701( 4 -> 8 )")]
        [TestCase(5,  ExpectedResult = 10, TestName = "Test_0701( 5 -> 10 )")]
        [TestCase(6,  ExpectedResult = 12, TestName = "Test_0701( 6 -> 12 )")]
        [TestCase(7,  ExpectedResult = 14, TestName = "Test_0701( 7 -> 14 )")]
        [TestCase(8,  ExpectedResult = 16, TestName = "Test_0701( 8 -> 16 )")]
        [TestCase(9,  ExpectedResult = 18, TestName = "Test_0701( 9 -> 18 )")]
        [TestCase(10, ExpectedResult = 20, TestName = "Test_0701( 10 -> 20 )")]
        [TestCase(11, ExpectedResult = 22, TestName = "Test_0701( 11 -> 22 )")]
        public int Test_0701(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))  // 1 -> 2     
                .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Aʹ_With(Add(1)))  // 2 -> 4
                    .If(Aʹ_Is(MoreThen(4)))
                        .Then(From_Aʹ_To_Aʺ_With(Add(1))) // 3 -> 6
                        .If(Aʺ_Is(MoreThen(6)))
                            .Then(From_Aʺ_To_Aʺʹ_With(Add(1))) // 4 -> 8
                            .If(Aʺʹ_Is(MoreThen(8)))
                                .Then(From_Aʺʹ_To_Aʺʺ_With(Add(1))) // 5 -> 10  
                                .If(Aʺʺ_Is(MoreThen(10)))
                                    .Then(From_Aʺʺ_To_Aʺʺʹ_With(Add(1))) // 6 -> 12
                                    .If(Aʺʺʹ_Is(MoreThen(12)))
                                        .Then(From_Aʺʺʹ_To_Aʺʺʺ_With(Add(1))) // 7 -> 14
                                        .If(Aʺʺʺ_Is(MoreThen(14)))
                                            .Then(From_Aʺʺʺ_To_Aʺʺʺʹ_With(Add(1))) // 8 -> 16
                                            .If(Aʺʺʺʹ_Is(MoreThen(16)))
                                                .Then(From_Aʺʺʺʹ_To_Aʺʺʺʺ_With(Add(1))) // 9 -> 18
                                                .If(Aʺʺʺʺ_Is(MoreThen(18)))
                                                    .Then(From_Aʺʺʺʺ_To_Aʺʺʺʺʹ_With(Add(1))) // 10 -> 20
                                                    .If(Aʺʺʺʺʹ_Is(MoreThen(20)))
                                                        .Then(From_Aʺʺʺʺʹ_To_Aʺʺʺʺʺ_With(Add(1))) // 11 -> 22
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test_0702( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 4,  TestName = "Test_0702( 2 -> 4 )")]
        [TestCase(3,  ExpectedResult = 6,  TestName = "Test_0702( 3 -> 6 )")]
        [TestCase(4,  ExpectedResult = 8,  TestName = "Test_0702( 4 -> 8 )")]
        [TestCase(5,  ExpectedResult = 10, TestName = "Test_0702( 5 -> 10 )")]
        [TestCase(6,  ExpectedResult = 12, TestName = "Test_0702( 6 -> 12 )")]
        [TestCase(7,  ExpectedResult = 14, TestName = "Test_0702( 7 -> 14 )")]
        [TestCase(8,  ExpectedResult = 16, TestName = "Test_0702( 8 -> 16 )")]
        [TestCase(9,  ExpectedResult = 18, TestName = "Test_0702( 9 -> 18 )")]
        [TestCase(10, ExpectedResult = 20, TestName = "Test_0702( 10 -> 20 )")]
        [TestCase(11, ExpectedResult = 22, TestName = "Test_0702( 11 -> 22 )")]
        public int Test_0702(int x)
        {
            var f =
                 From_Aʺʺʺʺʺ_To_Aʺʺʺʺʹ_With(Add(1))  // 1 -> 2     
                .If(Aʺʺʺʺʹ_Is(MoreThen(2)))
                    .Then(From_Aʺʺʺʺʹ_To_Aʺʺʺʺ_With(Add(1)))  // 2 -> 4
                    .If(Aʺʺʺʺ_Is(MoreThen(4)))
                        .Then(From_Aʺʺʺʺ_To_Aʺʺʺʹ_With(Add(1))) // 3 -> 6
                        .If(Aʺʺʺʹ_Is(MoreThen(6)))
                            .Then(From_Aʺʺʺʹ_To_Aʺʺʺ_With(Add(1))) // 4 -> 8
                            .If(Aʺʺʺ_Is(MoreThen(8)))
                                .Then(From_Aʺʺʺ_To_Aʺʺʹ_With(Add(1))) // 5 -> 10  
                                .If(Aʺʺʹ_Is(MoreThen(10)))
                                    .Then(From_Aʺʺʹ_To_Aʺʺ_With(Add(1))) // 6 -> 12
                                    .If(Aʺʺ_Is(MoreThen(12)))
                                        .Then(From_Aʺʺ_To_Aʺʹ_With(Add(1))) // 7 -> 14
                                        .If(Aʺʹ_Is(MoreThen(14)))
                                            .Then(From_Aʺʹ_To_Aʺ_With(Add(1))) // 8 -> 16
                                            .If(Aʺ_Is(MoreThen(16)))
                                                .Then(From_Aʺ_To_Aʹ_With(Add(1))) // 9 -> 18
                                                .If(Aʹ_Is(MoreThen(18)))
                                                    .Then(From_Aʹ_To_A_With(Add(1))) // 10 -> 20
                                                    .If(A_Is(MoreThen(20)))
                                                        .Then(From_A_To_A_With(Add(1))) // 11 -> 22
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
}
