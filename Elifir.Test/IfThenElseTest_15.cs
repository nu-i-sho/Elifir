namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class IfThenTest_15
    {
        [TestCase(2, ExpectedResult = 13, TestName = "Test_1500( 2 -> 13 )")]
        [TestCase(0, ExpectedResult = 21, TestName = "Test_1500( 0 -> 21 )")]
        public int Test_1500(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_Λ_With(Add(10)))    // 2 -> 13
               .Else()
                    .Then(From_A_To_Δ_With(Add(20)))    // 0 -> 21
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 114, TestName = "Test_1501( 2 -> 114 )")]
        [TestCase(0, ExpectedResult = 222, TestName = "Test_1501( 0 -> 222 )")]
        public int Test_1501(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .Then(From_A_To_A_With(Add(1)))
               .If(A_Is(MoreThen(3)))
                    .Then(From_A_To_A_With(Add(10)))
                    .Then(From_A_To_Δ_With(Add(100)))   // 3 -> 114
               .Else()
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_Λ_With(Add(200)))   // 1 -> 222
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 3332, TestName = "Test_1502( 2 -> 3332 )")]
        [TestCase(1, ExpectedResult = 4441, TestName = "Test_1502( 1 -> 4441 )")]
        public int Test_1502(int x)
        {
            var f =
                From_A_To_A_With(Add(10))
               .Then(From_A_To_A_With(Add(100)))
               .Then(From_A_To_A_With(Add(1000))) 
               .If(A_Is(Even))
                    .Then(From_A_To_D_With(Add(20)))
                    .Then(From_D_To_E_With(Add(200)))
                    .Then(From_E_To_Δ_With(Add(2000)))  // 2 -> 3332
               .Else()
                    .Then(From_A_To_B_With(Add(30)))
                    .Then(From_B_To_C_With(Add(300)))
                    .Then(From_C_To_Λ_With(Add(3000)))  // 1 -> 4441
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 13, TestName = "Test_1506( 2 -> 13 )")]
        [TestCase(13, ExpectedResult = 44, TestName = "Test_1506( 13 -> 44 )")]
        [TestCase(0,  ExpectedResult = 31, TestName = "Test_1506( 0 -> 31 )")]
        public int Test_1506(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 2 -> 13
                    .If(ΛΛ_Is(MoreThen(20)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(20)))  // 13 -> 44
                    .End(WithReturn<Λ>)
               .Else()
                    .Then(From_A_To_ΔΔ_With(Add(30)))       // 0 -> 31
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 13, TestName = "Test_1507( 2 -> 13 )")]
        [TestCase(13, ExpectedResult = 44, TestName = "Test_1507( 13 -> 44 )")]
        [TestCase(0,  ExpectedResult = 31, TestName = "Test_1507( 0 -> 31 )")]
        public int Test_1507(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 2 -> 13
                    .If(ΛΛ_Is(MoreThen(20)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(20)))  // 13 -> 44
                    .End(WithReturn<Λ>)
               .Else()
                    .Then(From_A_To_A_With(Add(30)))        // 0 -> 31
               .End();

            A result = f(new A(x));

            return result.Value;
        }
        
        [TestCase(2,  ExpectedResult = 13, TestName = "Test_1508( 2 -> 13 )")]
        [TestCase(13, ExpectedResult = 44, TestName = "Test_1508( 13 -> 44 )")]
        [TestCase(0,  ExpectedResult = 31, TestName = "Test_1508( 0 -> 31 )")]
        public int Test_1508(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(2)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 2 -> 13
                    .If(ΛΛ_Is(MoreThen(20)))
                        .Then(From_ΛΛ_To_ΛΛ_With(Add(20)))  // 13 -> 44
                    .End()
               .Else()
                    .Then(From_A_To_ΔΔ_With(Add(30)))       // 0 -> 31
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(10, ExpectedResult = 21, TestName = "Test_1517( 10 -> 21 )")]
        [TestCase(2,  ExpectedResult = 23, TestName = "Test_1517( 2 -> 23 )")]
        [TestCase(6,  ExpectedResult = 57, TestName = "Test_1517( 6 -> 57 )")]
        public int Test_1517(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_ΔΔ_With(Add(10)))       // 10 -> 21
               .Else()
                    .Then(From_A_To_ΛΛ_With(Add(20)))       // 2 -> 23
                    .If(ΛΛ_Is(MoreThen(25)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(30)))  // 6 -> 57
                    .End(WithReturn<Λ>)
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }
        
        [TestCase(10, ExpectedResult = 21, TestName = "Test_1518( 10 -> 21 )")]
        [TestCase(2,  ExpectedResult = 23, TestName = "Test_1518( 2 -> 23 )")]
        [TestCase(6,  ExpectedResult = 57, TestName = "Test_1518( 6 -> 57 )")]
        public int Test_1518(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_ΛΛ_With(Add(10)))       // 10 -> 21
               .Else()
                    .Then(From_A_To_ΛΛ_With(Add(20)))       // 2 -> 23
                    .If(ΛΛ_Is(MoreThen(25)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Add(30)))  // 6 -> 57
                    .End(WithReturn<Λ>)
               .End();

            A result = f(new A(x));

            return result.Value;
        }
        
        [TestCase(10, ExpectedResult = 21, TestName = "Test_1519( 10 -> 21 )")]
        [TestCase(2,  ExpectedResult = 23, TestName = "Test_1519( 2 -> 23 )")]
        [TestCase(6,  ExpectedResult = 57, TestName = "Test_1519( 6 -> 57 )")]
        public int Test_1519(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_Λ_With(Add(10)))            // 10 -> 21
               .Else()
                    .Then(From_A_To_ΛΛΛ_With(Add(20)))          // 2 -> 23
                    .If(ΛΛΛ_Is(MoreThen(25)))
                        .Then(From_ΛΛΛ_To_ΛΛΔ_With(Add(30)))    // 6 -> 57
                    .End(WithReturn<ΛΛ>)
               .End();

            A result = f(new A(x));

            return result.Value;
        }
        
        [TestCase(10, ExpectedResult = 21, TestName = "Test_1520( 10 -> 21 )")]
        [TestCase(2,  ExpectedResult = 23, TestName = "Test_1520( 2 -> 23 )")]
        [TestCase(6,  ExpectedResult = 57, TestName = "Test_1520( 6 -> 57 )")]
        public int Test_1520(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(MoreThen(10)))
                    .Then(From_A_To_ΔΔ_With(Add(10)))       // 10 -> 21
               .Else()
                    .Then(From_A_To_ΛΔ_With(Add(20)))       // 2 -> 23
                    .If(ΛΔ_Is(MoreThen(25)))
                        .Then(From_ΛΔ_To_ΛΔ_With(Add(30)))  // 6 -> 57
                    .End()
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2099, ExpectedResult = 2180, TestName = "Test_1521( 2099 -> 2180 )")]
        [TestCase(3099, ExpectedResult = 3200, TestName = "Test_1521( 3099 -> 3200 )")]
        [TestCase(4099, ExpectedResult = 4190, TestName = "Test_1521( 4099 -> 4190 )")]
        [TestCase(1099, ExpectedResult = 1170, TestName = "Test_1521( 1099 -> 1170 )")]
        public int Test_1521(int x)
        {
            var f =
                 From_A_To_ΛΔΔ_With(Add(1))
                .If(ΛΔΔ_Is(MoreThen(2000)))
                    .Then(From_A_To_ΔΛΛ_With(Add(20)))              // 2099 -> 2180 // +60
                    .If(Δ_Is(MoreThen(3000)))
                        .Then(From_Δ_To_ΛΛ_With(Add(30)))           // 3099 -> 3200 // +50
                        .If(ΛΛ_Is(MoreThen(4000)))
                            .Then(From_ΛΛ_To_ΛΛΔ_With(Add(40)))     // 4099 -> 4190
                        .Else()
                            .Then(From_ΛΛ_To_ΛΛΛ_With(Add(50)))
                        .End(WithReturn<ΛΛ>)
                    .Else()
                        .Then(From_Δ_To_ΛΔ_With(Add(60)))
                    .End(WithReturn<Λ>)
                .Else()
                    .Then(From_ΛΔΔ_To_Δ_With(Add(70)))              // 1099 -> 1170
                .End(WithReturn<A>);

            A result = f(new ΛΔΔ(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 4,  TestName = "Test_1522( 1 -> 4 )")]
        [TestCase(4, ExpectedResult = 8,  TestName = "Test_1522( 4 -> 8 )")]
        [TestCase(2, ExpectedResult = 11, TestName = "Test_1522( 2 -> 11 )")]
        public int Test_1522(int x)
        {
            var f =
                From_A_To_A_With(Add(1))                    
               .If(A_Is(Even))
                    .Then(From_A_To_Δ_With(Add(2)))         // 1 -> 4
               .Else()
                    .Then(From_A_To_Δ_With(Add(3)))         
                    .If(A_Is(EndingWith("4")))              // 4 -> 8
                        .Then(From_Δ_To_Λ_With(Add(4)))
                    .Else()
                        .Then(From_Δ_To_Λ_With(Add(5)))     // 2 -> 11
                    .End()
               .End(WithReturn<A>);

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1, ExpectedResult = 4,  TestName = "Test_1523( 1 -> 4 )")]
        [TestCase(4, ExpectedResult = 8,  TestName = "Test_1523( 4 -> 8 )")]
        [TestCase(2, ExpectedResult = 11, TestName = "Test_1523( 2 -> 11 )")]
        public int Test_1523(int x)
        {
            var f =
                From_A_To_A_With(Add(1))
               .If(A_Is(Even))
                    .Then(From_A_To_A_With(Add(2)))         
               .Else()
                    .Then(From_A_To_A_With(Add(3)))
                    .If(A_Is(EndingWith("4")))
                        .Then(From_A_To_Δ_With(Add(4)))
                    .Else()
                        .Then(From_A_To_Λ_With(Add(5)))
                    .End(WithReturn<A>)
               .End();

            A result = f(new A(x));

            return result.Value;

        }

        //[TestCase(2, ExpectedResult = 3, TestName = "Test_1522( 2 -> 3 )")]
        //[TestCase(1, ExpectedResult = 3, TestName = "Test_1522( 2 -> 3 )")]
        //public int Test_1522(int x)
        //{
        //    var f =
        //        From_A_To_A_With(Add(1))                    // 2 -> 3
        //       .If(A_Is(Even))
        //            .Then(From_A_To_Δ_With(Add(2)))
        //       .Else()
        //            .Then(From_A_To_Δ_With(Add(3)))
        //            .If(A_Is(EndingWith("5")))
        //                .Then(From_Δ_To_Λ_With(Add(4)))
        //            .Else()
        //                .Then(From_Δ_To_Λ_With(Add(5)))
        //            .End()
        //       .End(WithReturn<A>);

        //    A result = f(new A(x));

        //    return result.Value;
        //}
    }
}
