﻿namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class DeepFuncIfThenTest
    {
        
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
                .If(A_Is(MoreThen(2)))
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test28( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 4,  TestName = "Test28( 2 -> 4 )")]
        [TestCase(3,  ExpectedResult = 6,  TestName = "Test28( 3 -> 6 )")]
        [TestCase(4,  ExpectedResult = 8,  TestName = "Test28( 4 -> 8 )")]
        [TestCase(5,  ExpectedResult = 10, TestName = "Test28( 5 -> 10 )")]
        [TestCase(6,  ExpectedResult = 12, TestName = "Test28( 6 -> 12 )")]
        [TestCase(7,  ExpectedResult = 14, TestName = "Test28( 7 -> 14 )")]
        [TestCase(8,  ExpectedResult = 16, TestName = "Test28( 8 -> 16 )")]
        [TestCase(9,  ExpectedResult = 18, TestName = "Test28( 9 -> 18 )")]
        [TestCase(10, ExpectedResult = 20, TestName = "Test28( 10 -> 20 )")]
        [TestCase(11, ExpectedResult = 22, TestName = "Test28( 11 -> 22 )")]
        public int Test28(int x)
        {
            var f =
                 From_A_To_A_With(Plus(1))  // 1 -> 2     
                .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Aʹ_With(Plus(1)))  // 2 -> 3
                    .If(Aʹ_Is(MoreThen(4)))
                        .Then(From_Aʹ_To_Aʺ_With(Plus(1))) // 3 -> 6
                        .If(Aʺ_Is(MoreThen(6)))
                            .Then(From_Aʺ_To_Aʺʹ_With(Plus(1))) // 4 -> 8
                            .If(Aʺʹ_Is(MoreThen(8)))
                                .Then(From_Aʺʹ_To_Aʺʺ_With(Plus(1))) // 5 -> 10  
                                .If(Aʺʺ_Is(MoreThen(10)))
                                    .Then(From_Aʺʺ_To_Aʺʺʹ_With(Plus(1))) // 6 -> 12
                                    .If(Aʺʺʹ_Is(MoreThen(12)))
                                        .Then(From_Aʺʺʹ_To_Aʺʺʺ_With(Plus(1))) // 7 -> 14
                                        .If(Aʺʺʺ_Is(MoreThen(14)))
                                            .Then(From_Aʺʺʺ_To_Aʺʺʺʹ_With(Plus(1))) // 8 -> 16
                                            .If(Aʺʺʺʹ_Is(MoreThen(16)))
                                                .Then(From_Aʺʺʺʹ_To_Aʺʺʺʺ_With(Plus(1))) // 9 -> 18
                                                .If(Aʺʺʺʺ_Is(MoreThen(18)))
                                                    .Then(From_Aʺʺʺʺ_To_Aʺʺʺʺʹ_With(Plus(1))) // 10 -> 20
                                                    .If(Aʺʺʺʺʹ_Is(MoreThen(20)))
                                                        .Then(From_Aʺʺʺʺʹ_To_Aʺʺʺʺʺ_With(Plus(1))) // 11 -> 22
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

        [TestCase(1,  ExpectedResult = 2,  TestName = "Test29( 1 -> 2 )")]
        [TestCase(2,  ExpectedResult = 4,  TestName = "Test29( 2 -> 4 )")]
        [TestCase(3,  ExpectedResult = 6,  TestName = "Test29( 3 -> 6 )")]
        [TestCase(4,  ExpectedResult = 8,  TestName = "Test29( 4 -> 8 )")]
        [TestCase(5,  ExpectedResult = 10, TestName = "Test29( 5 -> 10 )")]
        [TestCase(6,  ExpectedResult = 12, TestName = "Test29( 6 -> 12 )")]
        [TestCase(7,  ExpectedResult = 14, TestName = "Test29( 7 -> 14 )")]
        [TestCase(8,  ExpectedResult = 16, TestName = "Test29( 8 -> 16 )")]
        [TestCase(9,  ExpectedResult = 18, TestName = "Test29( 9 -> 18 )")]
        [TestCase(10, ExpectedResult = 20, TestName = "Test29( 10 -> 20 )")]
        [TestCase(11, ExpectedResult = 22, TestName = "Test29( 11 -> 22 )")]
        public int Test29(int x)
        {
            var f =
                 From_Aʺʺʺʺʺ_To_Aʺʺʺʺʹ_With(Plus(1))  // 1 -> 2     
                .If(Aʺʺʺʺʹ_Is(MoreThen(2)))
                    .Then(From_Aʺʺʺʺʹ_To_Aʺʺʺʺ_With(Plus(1)))  // 2 -> 3
                    .If(Aʺʺʺʺ_Is(MoreThen(4)))
                        .Then(From_Aʺʺʺʺ_To_Aʺʺʺʹ_With(Plus(1))) // 3 -> 6
                        .If(Aʺʺʺʹ_Is(MoreThen(6)))
                            .Then(From_Aʺʺʺʹ_To_Aʺʺʺ_With(Plus(1))) // 4 -> 8
                            .If(Aʺʺʺ_Is(MoreThen(8)))
                                .Then(From_Aʺʺʺ_To_Aʺʺʹ_With(Plus(1))) // 5 -> 10  
                                .If(Aʺʺʹ_Is(MoreThen(10)))
                                    .Then(From_Aʺʺʹ_To_Aʺʺ_With(Plus(1))) // 6 -> 12
                                    .If(Aʺʺ_Is(MoreThen(12)))
                                        .Then(From_Aʺʺ_To_Aʺʹ_With(Plus(1))) // 7 -> 14
                                        .If(Aʺʹ_Is(MoreThen(14)))
                                            .Then(From_Aʺʹ_To_Aʺ_With(Plus(1))) // 8 -> 16
                                            .If(Aʺ_Is(MoreThen(16)))
                                                .Then(From_Aʺ_To_Aʹ_With(Plus(1))) // 9 -> 18
                                                .If(Aʹ_Is(MoreThen(18)))
                                                    .Then(From_Aʹ_To_A_With(Plus(1))) // 10 -> 20
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

            A result = f(new Aʺʺʺʺʺ(x));

            return result.Value;
        }
    }
}
