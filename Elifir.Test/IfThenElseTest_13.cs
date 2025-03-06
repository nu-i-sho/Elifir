namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class IfThenElseTest_13
    {
        [TestCase(2,  ExpectedResult = 12,  TestName = "Test_1322( 2 -> 12 )")]
        [TestCase(3,  ExpectedResult = 23,  TestName = "Test_1322( 3 -> 23 )")]
        [TestCase(4,  ExpectedResult = 34,  TestName = "Test_1322( 4 -> 34 )")]
        [TestCase(5,  ExpectedResult = 45,  TestName = "Test_1322( 5 -> 45 )")]
        [TestCase(6,  ExpectedResult = 56,  TestName = "Test_1322( 6 -> 56 )")]
        [TestCase(7,  ExpectedResult = 67,  TestName = "Test_1322( 7 -> 67 )")]
        [TestCase(8,  ExpectedResult = 78,  TestName = "Test_1322( 8 -> 78 )")]
        [TestCase(9,  ExpectedResult = 89,  TestName = "Test_1322( 9 -> 89 )")]
        [TestCase(10, ExpectedResult = 100, TestName = "Test_1322( 10 -> 100 )")]
        [TestCase(1,  ExpectedResult = 2,   TestName = "Test_1322( 1 -> 2 )")]
        public int Test_1322(int x)
        {
            var f =
                If(B_Is(MoreThen(1))).AndIf(B_Is(LessThen(3)))
                    .Then(From_B_To_A_With(Add(10)))            // 2 -> 12
                    .Else()

               .If(B_Is(MoreThen(2))).AndIf(B_Is(LessThen(4)))
                    .Then(From_B_To_A_With(Add(20)))
                    .Else()                                     // 3 -> 23

               .If(B_Is(MoreThen(3))).AndIf(B_Is(LessThen(5)))
                    .Then(From_B_To_A_With(Add(30)))
                    .Else()                                     // 4 -> 34

               .If(B_Is(MoreThen(4))).AndIf(B_Is(LessThen(6)))
                    .Then(From_B_To_A_With(Add(40)))
                    .Else()                                     // 5 -> 45

               .If(B_Is(MoreThen(5))).AndIf(B_Is(LessThen(7)))
                    .Then(From_B_To_A_With(Add(50)))
                    .Else()                                     // 6 -> 56

               .If(B_Is(MoreThen(6))).AndIf(B_Is(LessThen(8)))
                    .Then(From_B_To_A_With(Add(60)))
                    .Else()                                     // 7 -> 67

               .If(B_Is(MoreThen(7))).AndIf(B_Is(LessThen(9)))
                    .Then(From_B_To_A_With(Add(70)))
                    .Else()                                     // 8 -> 78
               
               .If(B_Is(MoreThen(8))).AndIf(B_Is(LessThen(10)))
                    .Then(From_B_To_A_With(Add(80)))
                    .Else()                                     // 9 -> 89

               .If(B_Is(MoreThen(9))).AndIf(B_Is(LessThen(11)))
                    .Then(From_B_To_A_With(Add(90)))
                    .Else()                                     // 10 -> 100

               .Then(From_B_To_A_With(Add(1)))                  // 1 -> 2
               
               .End().End().End()
               .End().End().End()
               .End().End().End();

            A result = f(new B(x));

            return result.Value;
        }
    }
}
