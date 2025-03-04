namespace Nuisho.Elifir.Test
{
    using static Syntax;
    using static Utils;

    [TestFixture]
    public class IfThenManualEndTest
    {
        [TestCase(1, ExpectedResult = 1, TestName = "Test_0200( 1 -> 1 )")]
        [TestCase(2, ExpectedResult = 4, TestName = "Test_0200( 2 -> 4 )")]
        public int Test_0200(int x)
        {
            var f =
                 If(Λ_Is(Even))                         // 1 -> 1
                    .Then(From_Λ_To_Δ_With(Plus(2)))    // 2 -> 4
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(5, ExpectedResult = 5,  TestName = "Test_0201( 5 -> 5 )")]
        [TestCase(2, ExpectedResult = 24, TestName = "Test_0201( 2 -> 24 )")]
        public int Test_0201(int x)
        {
            var f =
                 If(Λ_Is(Even))                         // 5 -> 5
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_Δ_With(Plus(20)))   // 1 -> 24
                .End(WithReturn<A>);


            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(8, ExpectedResult = 8,   TestName = "Test_0202( 8 -> 8 )")]
        [TestCase(7, ExpectedResult = 229, TestName = "Test_0202( 7 -> 229 )")]
        public int Test_0202(int x)
        {
            var f =
                 If(Λ_Is(Odd))                          // 8 -> 8
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_E_With(Plus(20)))
                    .Then(From_E_To_Δ_With(Plus(200)))  // 7 -> 229
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(5,    ExpectedResult = 5,    TestName = "Test_0203( 5 -> 5 )")]
        [TestCase(8,    ExpectedResult = 10,   TestName = "Test_0203( 8 -> 10 )")]
        [TestCase(1000, ExpectedResult = 1005, TestName = "Test_0203( 1000 -> 1005 )")]
        public int Test_0203(int x)
        {
            var f =
                 If(Λ_Is(Even))                             // 5 -> 5
                    .Then(From_Λ_To_ΛΛ_With(Plus(2)))       // 8 -> 10
                    .If(ΛΛ_Is(MoreThen(1000)))
                        .Then(From_ΛΛ_To_ΛΔ_With(Plus(3)))  // 1000 -> 1005
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2,  ExpectedResult = 2,   TestName = "Test_0204( 2 -> 2 )")]
        [TestCase(3,  ExpectedResult = 25,  TestName = "Test_0204( 3 -> 25 )")]
        [TestCase(79, ExpectedResult = 142, TestName = "Test_0204( 79 -> 142 )")]
        public int Test_0204(int x)
        {
            var f =
                 If(Λ_Is(Odd))                                  // 2 -> 2
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_ΛΛ_With(Plus(20)))          // 3 -> 25
                    .If(ΛΛ_Is(MoreThen(100)))
                        .Then(From_ΛΛ_To_D_With(Plus(20)))
                        .Then(From_D_To_ΛΔ_With(Plus(21)))      // 79 -> 142
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(3,   ExpectedResult = 3,    TestName = "Test_0205( 1 -> 3 )")]
        [TestCase(4,   ExpectedResult = 226,  TestName = "Test_0205( 4 -> 226 )")]
        [TestCase(800, ExpectedResult = 1355, TestName = "Test_0205( 800 -> 1355 )")]
        public int Test_0205(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 3 -> 3
                    .Then(From_Δ_To_C_With(Plus(2)))
                    .Then(From_C_To_E_With(Plus(20)))
                    .Then(From_E_To_ΔΔ_With(Plus(200)))         // 4 -> 226
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300)))     // 800 -> 1355
                    .End(WithReturn<Δ>)
                .End(WithReturn<A>);

            A result = f(new Δ(x));

            return result.Value;
        }


        [TestCase(8,  ExpectedResult = 8,   TestName = "Test_0206( 8 -> 8 )")]
        [TestCase(1,  ExpectedResult = 23,  TestName = "Test_0206( 1 -> 23 )")]
        [TestCase(97, ExpectedResult = 160, TestName = "Test_0206( 97 -> 160 )")]
        public int Test_0206(int x)
        {
            var f =
                 If(ΔΛ_Is(Odd))                             // 8 -> 8
                    .Then(From_ΔΛ_To_D_With(Plus(2)))
                    .Then(From_D_To_ΔΔ_With(Plus(20)))      // 2 -> 35
                    .If(ΔΔ_Is(MoreThen(100)))
                        .Then(From_ΔΔ_To_A_With(Plus(20)))
                        .Then(From_A_To_ΔΔ_With(Plus(21)))  // 97 -> 160
                    .End()
                .End(WithReturn<Δ>);

            Δ result = f(new ΔΛ(x));

            return result.Value;
        }

        [TestCase(1,   ExpectedResult = 1,    TestName = "Test_0207( 1 -> 1 )")]
        [TestCase(4,   ExpectedResult = 226,  TestName = "Test_0207( 4 -> 226 )")]
        [TestCase(804, ExpectedResult = 1359, TestName = "Test_0207( 804 -> 1359 )")]
        public int Test_0207(int x)
        {
            var f =
                 If(A_Is(Even))                                 // 1 -> 1
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 4 -> 226
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // 804 -> 1359
                    .End(WithReturn<Δ>)
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1000, ExpectedResult = 1000, TestName = "Test_0208( 1000 -> 1000 )")]
        [TestCase(3,    ExpectedResult = 5,    TestName = "Test_0208( 3 -> 5 )")]
        [TestCase(11,   ExpectedResult = 16,   TestName = "Test_0208( 11 -> 16 )")]
        public int Test_0208(int x)
        {
            var f =
                 If(Λ_Is(Odd))                              // 1000 -> 1000
                    .Then(From_Λ_To_ΔΔ_With(Plus(2)))       // 3 -> 5
                    .If(ΔΔ_Is(MoreThen(10)))
                        .Then(From_ΔΔ_To_Δ_With(Plus(3)))   // 11 -> 16
                    .End()
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(2, ExpectedResult = 2,  TestName = "Test_0209( 2 -> 2 )")]
        [TestCase(5, ExpectedResult = 7,  TestName = "Test_0209( 5 -> 7 )")]
        [TestCase(9, ExpectedResult = 14, TestName = "Test_0209( 9 -> 14 )")]
        public int Test_0209(int x)
        {
            var f =
                 If(Λ_Is(Odd))                              // 2 -> 2
                    .Then(From_Λ_To_Δ_With(Plus(2)))        // 5 -> 7
                    .If(Δ_Is(MoreThen(10)))
                        .Then(From_Δ_To_ΔΔ_With(Plus(3)))   // 9 -> 14
                    .End()
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }

        [TestCase(999,  ExpectedResult = 999,  TestName = "Test_0210( 999 -> 999 )")]
        [TestCase(2,    ExpectedResult = 4,    TestName = "Test_0210( 2 -> 4 )")]
        [TestCase(1600, ExpectedResult = 1605, TestName = "Test_0210( 1600 -> 1605 )")]
        public int Test_0210(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 999 -> 999
                    .Then(From_Δ_To_ΔΔ_With(Plus(2)))           // 2 -> 4
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_ΔΛ_With(Plus(3)))      // 1600 -> 1605
                    .End(WithReturn<A>)
                .End();

            A result = f(new Δ(x));

            return result.Value;
        }

        [TestCase(3,    ExpectedResult = 3,    TestName = "Test_0211( 3 -> 3 )")]
        [TestCase(8,    ExpectedResult = 230,  TestName = "Test_0211( 8 -> 230 )")]
        [TestCase(1008, ExpectedResult = 1563, TestName = "Test_0211( 1008 -> 1563 )")]
        public int Test_0211(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 3 -> 3
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 8 -> 230
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // 1008 -> 1563
                    .End(WithReturn<A>)
                .End();

            A result = f(new Δ(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 1,    TestName = "Test_0212( 1 -> 1 )")]
        [TestCase(20,   ExpectedResult = 242,  TestName = "Test_0212( 20 -> 242 )")]
        [TestCase(2000, ExpectedResult = 2555, TestName = "Test_0212( 2000 -> 2555 )")]
        public int Test_0212(int x)
        {
            var f =
                 If(Δ_Is(Even))                                 // 1 -> 1
                    .Then(From_Δ_To_E_With(Plus(2)))
                    .Then(From_E_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // 20 -> 242
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΔΛ_With(Plus(300)))     // 2000 -> 2555
                    .End(WithReturn<Δ>)
                .End();

            Δ result = f(new Δ(x));

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 3, TestName = "Test_0220( false, 3 -> 3 )")]
        [TestCase(true,  ExpectedResult = 5, TestName = "Test_0220( true, 2 -> 5 )")]
        public int Test_0220(bool isΛΛ)
        {
            var f =
                 If(Object<Λ>.Is<ΛΛ>)                   // (false, 3) -> 3
                    .Then(From_ΛΛ_To_Δ_With(Plus(2)))   // (true, 3) -> 5
                .End(WithReturn<A>);

            Λ arg = isΛΛ
                ? new ΛΛ(3)
                : new Λ(3);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 5,  TestName = "Test_0221( false, 5 -> 5 )")]
        [TestCase(true,  ExpectedResult = 27, TestName = "Test_0221( true, 5 -> 27 )")]
        public int Test_0221(bool isΛΛ)
        {
            var f =
                 If(Object<Λ>.Is<ΛΛ>)                   // (false, 5) -> 5
                    .Then(From_ΛΛ_To_B_With(Plus(2)))
                    .Then(From_B_To_Δ_With(Plus(20)))   // (true, 5) -> 27
                .End(WithReturn<A>);

            Λ arg = isΛΛ
                ? new ΛΛ(5)
                : new Λ(5);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, ExpectedResult = 5,   TestName = "Test_0222( false, 5 -> 5 )")]
        [TestCase(true,  ExpectedResult = 227, TestName = "Test_0222( true, 5 -> 227 )")]
        public int Test_0222(bool isΛΛ)
        {
            var f =
                 If(Object<Λ>.Is<ΛΛ>)                   // (false, 5) -> 5
                    .Then(From_Λ_To_B_With(Plus(2)))
                    .Then(From_B_To_E_With(Plus(20)))
                    .Then(From_E_To_Δ_With(Plus(200)))  // (true, 5) -> 227
                .End(WithReturn<A>);

            Λ arg = isΛΛ
                ? new ΛΛ(5)
                : new Λ(5);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, 3,    ExpectedResult = 3,    TestName = "Test_0223( false, 3 -> 3 )")]
        [TestCase(true,  3,    ExpectedResult = 5,    TestName = "Test_0223( true, 3 -> 5 )")]
        [TestCase(false, 3000, ExpectedResult = 3000, TestName = "Test_0223( false, 3000 -> 3000 )")]
        [TestCase(true,  3000, ExpectedResult = 3005, TestName = "Test_0223( true, 3000 -> 3005 )")]
        public int Test_0223(bool isΔΔ, int x)
        {
            var f =                                         // (false, 3) -> 3
                 If(Object<Δ>.Is<ΔΔ>)                       // (true, 3) -> 3
                    .Then(From_ΔΔ_To_ΛΔ_With(Plus(2)))      // (false, 3000) -> 3000
                    .If(ΛΔ_Is(MoreThen(1000)))
                        .Then(From_ΛΔ_To_ΛΛ_With(Plus(3)))  // (true, 3000) -> 3005
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            Δ arg = isΔΔ
                ? new ΔΔ(x)
                : new Δ(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(2, false, ExpectedResult = 2,  TestName = "Test_0224( 2, false -> 2 )")]
        [TestCase(2, true,  ExpectedResult = 2,  TestName = "Test_0224( 2, true -> 2 )")]
        [TestCase(3, false, ExpectedResult = 25, TestName = "Test_0224( 3, false -> 25 )")]
        [TestCase(3, true,  ExpectedResult = 66, TestName = "Test_0224( 3, false -> 66 )")]
        public int Test_0224(int x, bool secondIsΛΛΛ)
        {
            var from_B_To_ΛΛ_OrTo_ΛΛΛ_With =
                From_B_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

            var f =                                                 // (2, false) -> 2 
                 If(Δ_Is(Odd))                                      // (2, true) -> 2
                    .Then(From_Δ_To_B_With(Plus(2)))
                    .Then(from_B_To_ΛΛ_OrTo_ΛΛΛ_With(Plus(20)))     // (3, false) -> 25
                    .If(Object<ΛΛ>.Is<ΛΛΛ>)
                        .Then(From_ΛΛΛ_To_D_With(Plus(20)))
                        .Then(From_D_To_ΛΔ_With(Plus(21)))          // (3, false) -> 66
                    .End(WithReturn<Λ>) 
                .End(WithReturn<A>);

            A result = f(new Δ(x));

            return result.Value;
        }

        [TestCase(false, false, ExpectedResult = 25,  TestName = "Test_0225( false, false, 25 -> 25 )")]
        [TestCase(false, true,  ExpectedResult = 25,  TestName = "Test_0225( false, true, 25 -> 25 )")]
        [TestCase(true,  false, ExpectedResult = 247, TestName = "Test_0225( true, false, 25 -> 247 )")]
        [TestCase(true,  true,  ExpectedResult = 580, TestName = "Test_0225( true, true, 25 -> 580 )")]
        public int Test_0225(bool firstIsΔΔ, bool secondIsΛΛΛ)
        {
            var from_E_To_ΛΛ_OrTo_ΛΛΛ_With =
                From_E_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

            var f =                                                 // (false, false, 25) -> 25
                 If(Object<Δ>.Is<ΔΔ>)                               // (false, true, 25) -> 25
                    .Then(From_ΔΔ_To_C_With(Plus(2)))
                    .Then(From_C_To_E_With(Plus(20)))
                    .Then(from_E_To_ΛΛ_OrTo_ΛΛΛ_With(Plus(200)))    // (true, false, 25) -> 247
                    .If(Object<ΛΛ>.Is<ΛΛΛ>)
                        .Then(From_ΛΛΛ_To_E_With(Plus(3)))
                        .Then(From_E_To_B_With(Plus(30)))
                        .Then(From_B_To_ΛΔ_With(Plus(300)))         // (true, false, 25) -> 580
                    .End(WithReturn<Λ>)
                .End(WithReturn<A>);

            Δ arg = firstIsΔΔ
                ? new ΔΔ(25)
                : new Δ(25);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, false, ExpectedResult = 3,  TestName = "Test_0226( false, false, 3 -> 3 )")]
        [TestCase(false, true,  ExpectedResult = 3,  TestName = "Test_0226( false, true, 3 -> 3 )")]
        [TestCase(true,  false, ExpectedResult = 25, TestName = "Test_0226( true, false, 3 -> 25 )")]
        [TestCase(true,  true,  ExpectedResult = 66, TestName = "Test_0226( true, true, 3 -> 66 )")]
        public int Test_0226(bool firstIsΔΔ, bool secondIsΛΛΛ)
        {
            var from_D_To_ΛΛ_OrTo_ΛΛΛ_With =
                From_D_To_ΛΛ_OrTo_ΛΛΛ(secondIsΛΛΛ);

            var f =                                             // (false, false, 3) -> 3
                 If(Object<Δ>.Is<ΔΔ>)                           // (false, true, 3) -> 3
                    .Then(From_ΔΔ_To_D_With(Plus(2)))
                    .Then(from_D_To_ΛΛ_OrTo_ΛΛΛ_With(Plus(20))) // (true, false, 3) -> 25
                    .If(Object<ΛΛ>.Is<ΛΛΛ>)
                        .Then(From_ΛΛΛ_To_A_With(Plus(20)))
                        .Then(From_A_To_ΛΛΔ_With(Plus(21)))     // (true, true, 3) -> 66
                    .End()
                .End(WithReturn<A>);

            Δ arg = firstIsΔΔ
                ? new ΔΔ(3)
                : new Δ(3);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, 2,   ExpectedResult = 2,    TestName = "Test_0227( false, 2 -> 2 )")]
        [TestCase(true,  300, ExpectedResult = 522,  TestName = "Test_0227( true, 300 -> 522 )")]
        [TestCase(true,  800, ExpectedResult = 1355, TestName = "Test_0227( true, 800 -> 1355 )")]
        public int Test_0227(bool isAʹ, int x)
        {
            var f =
                 If(Object<A>.Is<Aʹ>)                           // (false, 2) -> 2
                    .Then(From_Aʹ_To_D_With(Plus(2)))
                    .Then(From_D_To_B_With(Plus(20)))
                    .Then(From_B_To_ΔΔ_With(Plus(200)))         // (true, 300) -> 522
                    .If(ΔΔ_Is(MoreThen(1000)))
                        .Then(From_ΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))     // (true, 800) -> 1355
                    .End(WithReturn<Δ>)
                .End();

            A arg = isAʹ
                ? new Aʹ(x)
                : new A(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(false, 2, ExpectedResult = 2,  TestName = "Test_0228( false, 2 -> 2 )")]
        [TestCase(true,  3, ExpectedResult = 5,  TestName = "Test_0228( true, 3 -> 5 )")]
        [TestCase(true,  9, ExpectedResult = 14, TestName = "Test_0228( true, 9 -> 14 )")]
        public int Test_0228(bool isΛΛ, int x)
        {
            var f =
                 If(Object<Λ>.Is<ΛΛ>)                       // (false, 2) -> 2
                    .Then(From_ΛΛ_To_ΔΔ_With(Plus(2)))      // (true, 3) -> 5
                    .If(ΔΔ_Is(MoreThen(10)))
                        .Then(From_ΔΔ_To_Δ_With(Plus(3)))   // (true, 9) -> 14
                    .End()
                .End(WithReturn<A>);

            Λ arg = isΛΛ
                ? new ΛΛ(x)
                : new Λ(x);

            A result = f(arg);

            return result.Value;
        }

        [TestCase(2, false, ExpectedResult = 2, TestName = "Test_0229( 2, false -> 2 )")]
        [TestCase(2, true,  ExpectedResult = 2, TestName = "Test_0229( 2, true -> 2 )")]
        [TestCase(3, false, ExpectedResult = 5, TestName = "Test_0229( 3, false -> 5 )")]
        [TestCase(3, true,  ExpectedResult = 8, TestName = "Test_0229( 3, true -> 8 )")]
        public int Test_0229(int x, bool isΔΔ)
        {
            var from_Λ_To_Δ_OrTo_ΔΔ_With =
                From_Λ_To_Δ_OrTo_ΔΔ(isΔΔ);

            var f =                                             // (2, false) -> 2
                 If(Λ_Is(Odd))                                  // (2, true) -> 2
                    .Then(from_Λ_To_Δ_OrTo_ΔΔ_With(Plus(2)))    // (3, false) -> 5
                    .If(Object<Δ>.Is<ΔΔ>)
                        .Then(From_ΔΔ_To_ΔΔΔ_With(Plus(3)))     // (3, true) -> 8
                    .End()
                .End(WithReturn<A>);

            A result = f(new Λ(x));

            return result.Value;
        }
        
        [TestCase(3, false, ExpectedResult = 3,   TestName = "Test_0230( 3, false -> 3 )")]
        [TestCase(3, true,  ExpectedResult = 3,   TestName = "Test_0230( 3, true -> 3 )")]
        [TestCase(2, false, ExpectedResult = 224, TestName = "Test_0230( 2, false -> 224 )")]
        [TestCase(2, true,  ExpectedResult = 557, TestName = "Test_0230( 2, true -> 557 )")]
        public int Test_0230(int x, bool isΔΔ)
        {
            var from_Λ_To_ΔΔ_OrTo_ΔΔ_With =
                From_Λ_To_ΔΔ_OrTo_ΔΔΔ(isΔΔ);

            var f =                                                 // (3, false) -> 3
                 If(Δ_Is(Even))                                     // (3, true) -> 3
                    .Then(From_A_To_D_With(Plus(2)))
                    .Then(From_D_To_Λ_With(Plus(20)))
                    .Then(from_Λ_To_ΔΔ_OrTo_ΔΔ_With(Plus(200)))     // (2, false) -> 224
                    .If(Object<ΔΔ>.Is<ΔΔΔ>)
                        .Then(From_ΔΔΔ_To_B_With(Plus(3)))
                        .Then(From_B_To_D_With(Plus(30)))
                        .Then(From_D_To_ΔΛ_With(Plus(300)))         // (2, true) -> 557
                    .End(WithReturn<A>)
                .End();

            A result = f(new Δ(x));

            return result.Value;
        }
    }
}
