namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class IfThenTest_12
    {
        [TestCase(3, ExpectedResult = 13, TestName = "Test_1200( 3 -> 13 )")]
        [TestCase(1, ExpectedResult = 21, TestName = "Test_1200( 1 -> 21 )")]
        public int Test_1200(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Λ_With(Add(10)))    // 3 -> 13
               .Else()
                    .Then(From_A_To_Δ_With(Add(20)))    // 1 -> 21
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 113, TestName = "Test_1201( 3 -> 113 )")]
        [TestCase(1, ExpectedResult = 221, TestName = "Test_1201( 1 -> 221 )")]
        public int Test_1201(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_A_With(Add(10)))
                    .Then(From_A_To_Δ_With(Add(100)))   // 3 -> 113
               .Else()
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_Λ_With(Add(200)))   // 1 -> 221
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3, ExpectedResult = 1113, TestName = "Test_1202( 3 -> 1113 )")]
        [TestCase(1, ExpectedResult = 2221, TestName = "Test_1202( 1 -> 2221 )")]
        public int Test_1202(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_D_With(Add(10)))
                    .Then(From_D_To_E_With(Add(100)))
                    .Then(From_E_To_Δ_With(Add(1000)))  // 3 -> 1113
               .Else()
                    .Then(From_A_To_B_With(Add(20)))
                    .Then(From_B_To_C_With(Add(200)))
                    .Then(From_C_To_Λ_With(Add(2000)))  // 1 -> 2221
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3,  ExpectedResult = 13, TestName = "Test_1206( 3 -> 13 )")]
        [TestCase(14, ExpectedResult = 44, TestName = "Test_1206( 14 -> 44 )")]
        [TestCase(1,  ExpectedResult = 31, TestName = "Test_1206( 1 -> 31 )")]
        public int Test_1206(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 3 -> 13
                    .If(ΛΛ_Is(MoreThen(20)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(20)))  // 14 -> 44
                    .End(WithReturn<Λ>)
               .Else()
                    .Then(From_A_To_ΔΔ_With(Add(30)))       // 1 -> 31
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3,  ExpectedResult = 13, TestName = "Test_1207( 3 -> 13 )")]
        [TestCase(14, ExpectedResult = 44, TestName = "Test_1207( 14 -> 44 )")]
        [TestCase(1,  ExpectedResult = 31, TestName = "Test_1207( 1 -> 31 )")]
        public int Test_1207(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 3 -> 13
                    .If(ΛΛ_Is(MoreThen(20)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(20)))  // 14 -> 44
                    .End(WithReturn<Λ>)
               .Else()
                    .Then(From_A_To_A_With(Add(30)))        // 1 -> 31
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(3,  ExpectedResult = 13, TestName = "Test_1208( 3 -> 13 )")]
        [TestCase(14, ExpectedResult = 44, TestName = "Test_1208( 14 -> 44 )")]
        [TestCase(1,  ExpectedResult = 31, TestName = "Test_1208( 1 -> 31 )")]
        public int Test_1208(int x)
        {
            var f =
                If(A_Is(MoreThen(2)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 3 -> 13
                    .If(ΛΛ_Is(MoreThen(20)))
                        .Then(From_ΛΛ_To_ΛΛ_With(Add(20)))  // 14 -> 44
                    .End()
               .Else()
                    .Then(From_A_To_ΔΔ_With(Add(30)))       // 1 -> 31
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 21, TestName = "Test_1217( 11 -> 21 )")]
        [TestCase(3,  ExpectedResult = 23, TestName = "Test_1217( 3 -> 23 )")]
        [TestCase(7,  ExpectedResult = 57, TestName = "Test_1217( 7 -> 57 )")]
        public int Test_1217(int x)
        {
            var f =
                If(A_Is(MoreThen(10)))
                    .Then(From_A_To_ΔΔ_With(Add(10)))       // 11 -> 21
               .Else()
                    .Then(From_A_To_ΛΛ_With(Add(20)))       // 3 -> 23
                    .If(ΛΛ_Is(MoreThen(25)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(30)))  // 7 -> 57
                    .End(WithReturn<Λ>)
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 21, TestName = "Test_1218( 11 -> 21 )")]
        [TestCase(3,  ExpectedResult = 23, TestName = "Test_1218( 3 -> 23 )")]
        [TestCase(7,  ExpectedResult = 57, TestName = "Test_1218( 7 -> 57 )")]
        public int Test_1218(int x)
        {
            var f =
                If(A_Is(MoreThen(10)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 11 -> 21
               .Else()
                    .Then(From_A_To_ΛΛ_With(Add(20)))       // 3 -> 23
                    .If(ΛΛ_Is(MoreThen(25)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(30)))  // 7 -> 57
                    .End(WithReturn<Λ>)
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 21, TestName = "Test_1219( 11 -> 21 )")]
        [TestCase(3,  ExpectedResult = 23, TestName = "Test_1219( 3 -> 23 )")]
        [TestCase(7,  ExpectedResult = 57, TestName = "Test_1219( 7 -> 57 )")]
        public int Test_1219(int x)
        {
            var f =
                If(A_Is(MoreThen(10)))
                    .Then(From_A_To_Λ_With(Add(10)))            // 11 -> 21
               .Else()
                    .Then(From_A_To_ΛΛΛ_With(Add(20)))          // 3 -> 23
                    .If(ΛΛΛ_Is(MoreThen(25)))
                        .Then(From_ΛΛΛ_To_ΛΛΔ_With(Add(30)))    // 7 -> 57
                    .End(WithReturn<ΛΛ>)
               .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(11, ExpectedResult = 21, TestName = "Test_1220( 11 -> 21 )")]
        [TestCase(3,  ExpectedResult = 23, TestName = "Test_1220( 3 -> 23 )")]
        [TestCase(7,  ExpectedResult = 57, TestName = "Test_1220( 7 -> 57 )")]
        public int Test_1220(int x)
        {
            var f =
                If(A_Is(MoreThen(10)))
                    .Then(From_A_To_ΔΔ_With(Add(10)))       // 11 -> 21
               .Else()
                    .Then(From_A_To_ΛΔ_With(Add(20)))       // 3 -> 23
                    .If(ΛΔ_Is(MoreThen(25)))
                        .Then(From_ΛΔ_To_ΛΔ_With(Add(30)))  // 7 -> 57
                    .End()
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2100, ExpectedResult = 2180, TestName = "Test_1221( 2100 -> 2180 )")]
        [TestCase(3100, ExpectedResult = 3200, TestName = "Test_1221( 3100 -> 3200 )")]
        [TestCase(4100, ExpectedResult = 4190, TestName = "Test_1221( 4100 -> 4190 )")]
        [TestCase(1100, ExpectedResult = 1170, TestName = "Test_1221( 1100 -> 1170 )")]
        public int Test_1221(int x)
        {
            var f =
                 If(ΛΔΔ_Is(MoreThen(2000)))
                    .Then(From_A_To_ΔΛΛ_With(Add(20)))              // 2100 -> 2180 // +60
                    .If(Δ_Is(MoreThen(3000)))
                        .Then(From_Δ_To_ΛΛ_With(Add(30)))           // 3100 -> 3200 // +50
                        .If(ΛΛ_Is(MoreThen(4000)))
                            .Then(From_ΛΛ_To_ΛΛΔ_With(Add(40)))     // 4100 -> 4190
                        .Else()
                            .Then(From_ΛΛ_To_ΛΛΛ_With(Add(50)))
                        .End(WithReturn<ΛΛ>)
                    .Else()
                        .Then(From_Δ_To_ΛΔ_With(Add(60)))
                    .End(WithReturn<Λ>)
                .Else()
                    .Then(From_ΛΔΔ_To_Δ_With(Add(70)))              // 1100 -> 1170
                .End(WithReturn<A>);

            A result = f(new ΛΔΔ(x));

            return result.Value;
        }
    }
}
