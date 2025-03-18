namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenTest_21
    {
        [TestCase(2, false, ExpectedResult = 2, TestName = "Test_2100( 2, false -> 2 )")]
        [TestCase(1, false, ExpectedResult = 1, TestName = "Test_2100( 1, false -> 1 )")]
        [TestCase(2, true,  ExpectedResult = 2, TestName = "Test_2100( 2, true -> 2 )")]
        [TestCase(1, true,  ExpectedResult = 3, TestName = "Test_2100( 1, true -> 3 )")]
        public int Test_2100(int x, bool isΛ)
        {
            var f =
                 If(Object<A>.Is<Λ>)                       // (2, false) -> 2, (1, false) -> 1
                    .If(Λ_Is(Odd))                         // (2, true) -> 2
                        .Then(From_Λ_To_Δ_With(Add(2)))    // (1, true) -> 3
                    .End(WithReturn<A>)
                .End();

            A arg = isΛ
                ? new Λ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(2, false, ExpectedResult = 2, TestName = "Test_2101( 2, false -> 2 )")]
        [TestCase(1, false, ExpectedResult = 1, TestName = "Test_2101( 1, false -> 1 )")]
        [TestCase(2, true,  ExpectedResult = 2, TestName = "Test_2101( 2, true -> 2 )")]
        [TestCase(1, true,  ExpectedResult = 3, TestName = "Test_2101( 1, true -> 3 )")]
        public int Test_2101(int x, bool isΛ)
        {
            var f =
                 If(Object<A>.Is<Λ>)                        // (2, false) -> 2, (1, false) -> 1
                    .If(Λ_Is(Odd))                          // (2, true) -> 2
                        .Then(From_Λ_To_ΛΛ_With(Add(2)))    // (1, true) -> 3
                    .End()
                .End();

            A arg = isΛ
                ? new Λ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        
        [TestCase(2, false, ExpectedResult = 2, TestName = "Test_2102( 2, false -> 2 )")]
        [TestCase(1, false, ExpectedResult = 1, TestName = "Test_2102( 1, false -> 1 )")]
        [TestCase(2, true,  ExpectedResult = 2, TestName = "Test_2102( 2, true -> 2 )")]
        [TestCase(1, true,  ExpectedResult = 3, TestName = "Test_2102( 1, true -> 3 )")]
        public int Test_2102(int x, bool isΛΛ)
        {
            var f =
                 If(Object<A>.Is<ΛΛ>)                       // (2, false) -> 2, (1, false) -> 1
                    .If(ΛΛ_Is(Odd))                         // (2, true) -> 2
                        .Then(From_ΛΛ_To_Λ_With(Add(2)))    // (1, true) -> 3
                    .End()
                .End();

            A arg = isΛΛ
                ? new ΛΛ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(5,  ExpectedResult = 5,  TestName = "Test_2103( 5 -> 5 )")]
        [TestCase(16, ExpectedResult = 16, TestName = "Test_2103( 16 -> 16 )")]
        [TestCase(15, ExpectedResult = 17, TestName = "Test_2103( 15 -> 17 )")]
        public int Test_2103(int x)
        {
            var f =
                 If(Λ_Is(MoreThen(10)))                    // 5 -> 5
                    .If(Λ_Is(Odd))                         // 16 -> 16
                        .Then(From_Λ_To_Δ_With(Add(2)))    // 15 -> 17
                    .End(WithReturn<A>)
                .End();

            A result = f(new Λ(x));

            return result.Value;
        }
        
        [TestCase(5,  ExpectedResult = 5,  TestName = "Test_2104( 5 -> 5 )")]
        [TestCase(16, ExpectedResult = 16, TestName = "Test_2104( 16 -> 16 )")]
        [TestCase(15, ExpectedResult = 17, TestName = "Test_2104( 15 -> 17 )")]
        public int Test_2104(int x)
        {
            var f =
                 If(Λ_Is(MoreThen(10)))                    // 5 -> 5
                    .If(Λ_Is(Odd))                         // 16 -> 16
                        .Then(From_Λ_To_ΛΛ_With(Add(2)))   // 15 -> 17
                    .End()
                .End();

            A result = f(new Λ(x));

            return result.Value;
        }
        
        [TestCase(5,  ExpectedResult = 5,  TestName = "Test_2105( 5 -> 5 )")]
        [TestCase(16, ExpectedResult = 16, TestName = "Test_2105( 16 -> 16 )")]
        [TestCase(15, ExpectedResult = 17, TestName = "Test_2105( 15 -> 17 )")]
        public int Test_2105(int x)
        {
            var f =
                 If(ΛΛ_Is(MoreThen(10)))                   // 5 -> 5
                    .If(ΛΛ_Is(Odd))                        // 16 -> 16
                        .Then(From_ΛΛ_To_Λ_With(Add(2)))   // 15 -> 17
                    .End()
                .End();

            A result = f(new ΛΛ(x));

            return result.Value;
        }
        
        [TestCase(5,   ExpectedResult = 5,   TestName = "Test_2110( 5 -> 5 )")]
        [TestCase(101, ExpectedResult = 101, TestName = "Test_2110( 101 -> 101 )")]
        [TestCase(16,  ExpectedResult = 16,  TestName = "Test_2110( 16 -> 16 )")]
        [TestCase(15,  ExpectedResult = 17,  TestName = "Test_2110( 15 -> 17 )")]
        public int Test_2110(int x)
        {
            var f =
                 If(Λ_Is(MoreThen(10)))                        // 5 -> 5
                    .If(Λ_Is(LessThen(100)))                   // 101 -> 101
                        .If(Λ_Is(Odd))                         // 16 -> 16
                            .Then(From_Λ_To_Δ_With(Add(2)))    // 15 -> 17
                        .End(WithReturn<A>)
                    .End()
                .End();

            A result = f(new Λ(x));

            return result.Value;
        }
        
        [TestCase(5,   ExpectedResult = 5,   TestName = "Test_2111( 5 -> 5 )")]
        [TestCase(101, ExpectedResult = 101, TestName = "Test_2111( 101 -> 101 )")]
        [TestCase(16,  ExpectedResult = 16,  TestName = "Test_2111( 16 -> 16 )")]
        [TestCase(15,  ExpectedResult = 17,  TestName = "Test_2111( 15 -> 17 )")]
        public int Test_2111(int x)
        {
            var f =
                 If(Λ_Is(MoreThen(10)))                        // 5 -> 5
                    .If(Λ_Is(Odd))                             // 16 -> 16
                        .If(Λ_Is(LessThen(100)))               // 101 -> 101
                            .Then(From_Λ_To_ΛΛ_With(Add(2)))   // 15 -> 17
                        .End()
                    .End()
                .End();

            A result = f(new Λ(x));

            return result.Value;
        }
        
        [TestCase(5,   ExpectedResult = 5,   TestName = "Test_2112( 5 -> 5 )")]
        [TestCase(16,  ExpectedResult = 16,  TestName = "Test_2112( 16 -> 16 )")]
        [TestCase(101, ExpectedResult = 101, TestName = "Test_2111( 101 -> 101 )")]
        [TestCase(15,  ExpectedResult = 17,  TestName = "Test_2112( 15 -> 17 )")]
        public int Test_2112(int x)
        {
            var f =
                 If(ΛΛ_Is(MoreThen(10)))                       // 5 -> 5
                    .If(ΛΛ_Is(Odd))                            // 16 -> 16
                        .If(Λ_Is(LessThen(100)))               // 101 -> 101
                            .Then(From_ΛΛ_To_Λ_With(Add(2)))   // 15 -> 17
                        .End()
                    .End()
                .End();

            A result = f(new ΛΛ(x));

            return result.Value;
        }
    }
}
