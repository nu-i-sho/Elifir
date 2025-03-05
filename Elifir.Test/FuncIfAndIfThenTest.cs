﻿namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class FuncIfAndIfThenTest
    {
        [TestCase(2,   ExpectedResult = 3,   TestName = "Test_0500( 2 -> 3 )")]
        [TestCase(8,   ExpectedResult = 9,   TestName = "Test_0500( 8 -> 9 )")]
        [TestCase(100, ExpectedResult = 101, TestName = "Test_0500( 100 -> 101 )")]
        [TestCase(11,  ExpectedResult = 14,  TestName = "Test_0500( 11 -> 14 )")]
        public int Test_0500(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))                  // 2 -> 3, 8 -> 9, 100 -> 101
                .If(A_Is(Even)).AndIf(A_Is(MoreThen(10)))
                    .Then(From_A_To_A_With(Add(2)))        // 11 -> 14
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(0,   ExpectedResult = 11,  TestName = "Test_0501( 0 -> 11 )")]
        [TestCase(1,   ExpectedResult = 12,  TestName = "Test_0501( 1 -> 12 )")]
        [TestCase(110, ExpectedResult = 121, TestName = "Test_0501( 110 -> 121 )")]
        [TestCase(111, ExpectedResult = 144, TestName = "Test_0501( 111 -> 144 )")]
        public int Test_0501(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))           // 0 -> 11, 1 -> 12, 110 -> 121
                .If(A_Is(Even)).AndIf(A_Is(MoreThen(50)))
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))       // 111 -> 144
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(53,  ExpectedResult = 56,  TestName = "Test_0502( 53 -> 56 )")]
        [TestCase(1,   ExpectedResult = 4,   TestName = "Test_0502( 1 -> 4 )")]
        [TestCase(110, ExpectedResult = 113, TestName = "Test_0502( 110 -> 113 )")]
        [TestCase(70,  ExpectedResult = 295, TestName = "Test_0502( 70 -> 295 )")]
        public int Test_0502(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(1)))
                .Then(From_A_To_A_With(Add(1)))      
                .If(A_Is(Odd))                          // 53 -> 56
                .AndIf(A_Is(MoreThen(50)))              // 1 -> 4
                .AndIf(A_Is(LessThen(100)))             // 110 -> 113
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(From_A_To_A_With(Add(200)))   // 70 -> 295
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(false, 2, ExpectedResult = 113, TestName = "Test_0503( false, 2 -> 113 )")]
        [TestCase(true,  2, ExpectedResult = 113, TestName = "Test_0503( true, 2 -> 113 )")]
        [TestCase(false, 1, ExpectedResult = 112, TestName = "Test_0503( false, 1 -> 112 )")]
        [TestCase(true,  1, ExpectedResult = 334, TestName = "Test_0503( true, 1 -> 334 )")]
        
        public int Test_0503(bool isCʹ, int x)
        {
            var from_D_To_C_OrTo_Cʹ_With =
                From_D_To_C_OrTo_Cʹ(isCʹ);

            var f =
                 From_A_To_B_With(Add(1))
                .Then(From_B_To_D_With(Add(10)))
                .Then(from_D_To_C_OrTo_Cʹ_With(Add(100)))
                .If(C_Is(Even))                             // (false, 2) -> 113, (true, 2) -> 113
                .AndIf(Object<C>.Is<Cʹ>)                    // (false, 1) -> 112
                    .Then(From_Cʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_C_With(Add(200)))       // (true, 1) -> 334
                .End();

            C result = f(new A(x));

            return result.Value;
        }

        [TestCase(10,  false, ExpectedResult = 21,  TestName = "Test_0504( 10, false -> 21 )")]
        [TestCase(10,  true,  ExpectedResult = 21,  TestName = "Test_0504( 10, true -> 21 )")]
        [TestCase(100, false, ExpectedResult = 111, TestName = "Test_0504( 100, true -> 111 )")]
        [TestCase(100, true,  ExpectedResult = 133, TestName = "Test_0504( 100, true -> 133 )")]
        public int Test_0504(int x, bool isAʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(isAʹ);

            var f =
                 From_A_To_A_With(Add(1))
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(10)))    
                .If(Object<A>.Is<Aʹ>)                       // (10, false) -> 21
                .AndIf(Aʹ_Is(MoreThen(100)))                // (10, true) -> 21, (100, true) -> 111
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_Aʹ_With(Add(20)))       // (100, true) -> 133
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(To.A,      ExpectedResult = 111, TestName = "Test_0505( 0, To.A -> 111 )")]
        [TestCase(To.Aʹ,     ExpectedResult = 111, TestName = "Test_0505( 0, To.Aʹ -> 111 )")]
        [TestCase(To.Aʺ,     ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺ -> 333 )")]
        [TestCase(To.Aʺʹ,    ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʹ -> 333 )")]
        [TestCase(To.Aʺʺ,    ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺ -> 333 )")]
        [TestCase(To.Aʺʺʹ,   ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺʹ -> 333 )")]
        [TestCase(To.Aʺʺʺ,   ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺʺ -> 333 )")]
        [TestCase(To.Aʺʺʺʹ,  ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺʺʹ -> 333 )")]
        [TestCase(To.Aʺʺʺʺ,  ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺʺʺ -> 333 )")]
        [TestCase(To.Aʺʺʺʺʹ, ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺʺʺʹ -> 333 )")]
        [TestCase(To.Aʺʺʺʺʺ, ExpectedResult = 333, TestName = "Test_0505( 0, To.Aʺʺʺʺʺ -> 333 )")]
        public int Test_0505(To to)
        {
            var from_D_To_SomeA_With =
                From_D_To_SomeA(to);

            var f =
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_D_With(Add(10)))
                .Then(from_D_To_SomeA_With(Add(100))) 
                .If(Object<A>.Is<Aʹ>)                   // (0, To.A) -> 111
                .AndIf(Object<Aʹ>.Is<Aʺ>)               // (0, To.Aʹ) -> 111
                    .Then(From_Aʺ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Aʹ_With(Add(200)))  // (0, To.Aʺ) -> 333, (0, To.Aʺʹ) -> 333
                .End();                                 // (0, To.Aʺʺ) -> 333, (0, To.Aʺʺʹ) -> 333
                                                        // (0, To.Aʺʺʺ) -> 333, (0, To.Aʺʺʺʹ) -> 333
                                                        // (0, To.Aʺʺʺʺ) -> 333, (0, To.Aʺʺʺʺʹ) -> 333
                                                        // (0, To.Aʺʺʺʺʺ) -> 333
            A result = f(new A(0));

            return result.Value;
        }

        [TestCase(To.A,      ExpectedResult = 111, TestName = "Test_0506( 0, To.A -> 111 )")]
        [TestCase(To.Aʹ,     ExpectedResult = 111, TestName = "Test_0506( 0, To.Aʹ -> 111 )")]
        [TestCase(To.Aʺ,     ExpectedResult = 111, TestName = "Test_0506( 0, To.Aʺ -> 111 )")]
        [TestCase(To.Aʺʹ,    ExpectedResult = 111, TestName = "Test_0506( 0, To.Aʺʹ -> 111 )")]
        [TestCase(To.Aʺʺ,    ExpectedResult = 111, TestName = "Test_0506( 0, To.Aʺʺ -> 111 )")]
        [TestCase(To.Aʺʺʹ,   ExpectedResult = 111, TestName = "Test_0506( 0, To.Aʺʺʹ -> 111 )")]
        [TestCase(To.Aʺʺʺ,   ExpectedResult = 111, TestName = "Test_0506( 0, To.Aʺʺʺ -> 111 )")]
        [TestCase(To.Aʺʺʺʹ,  ExpectedResult = 333, TestName = "Test_0506( 0, To.Aʺʺʺʹ -> 333 )")]
        [TestCase(To.Aʺʺʺʺ,  ExpectedResult = 333, TestName = "Test_0506( 0, To.Aʺʺʺʺ -> 333 )")]
        [TestCase(To.Aʺʺʺʺʹ, ExpectedResult = 333, TestName = "Test_0506( 0, To.Aʺʺʺʺʹ -> 333 )")]
        [TestCase(To.Aʺʺʺʺʺ, ExpectedResult = 333, TestName = "Test_0506( 0, To.Aʺʺʺʺʺ -> 333 )")]
        public int Test_0506(To to)
        {
            var from_D_To_SomeA_With =
                From_D_To_SomeA(to);

            var f =
                 From_A_To_E_With(Add(1))
                .Then(From_E_To_D_With(Add(10)))
                .Then(from_D_To_SomeA_With(Add(100))) 
                .If(Object<A>.Is<Aʹ>)                   // (0, To.A) -> 111
                .AndIf(Object<Aʹ>.Is<Aʺ>)               // (0, To.Aʹ) -> 111
                .AndIf(Object<Aʺ>.Is<Aʺʹ>)              // (0, To.Aʺ) -> 111
                .AndIf(Object<Aʺʹ>.Is<Aʺʺ>)             // (0, To.Aʺʹ) -> 111
                .AndIf(Object<Aʺʺ>.Is<Aʺʺʹ>)            // (0, To.Aʺʺ) -> 111
                .AndIf(Object<Aʺʺʹ>.Is<Aʺʺʺ>)           // (0, To.Aʺʺʹ) -> 111
                .AndIf(Object<Aʺʺʺ>.Is<Aʺʺʺʹ>)          // (0, To.Aʺʺʺ) -> 111
                    .Then(From_Aʺʺʺʹ_To_E_With(Add(2)))
                    .Then(From_E_To_B_With(Add(20)))
                    .Then(From_B_To_Aʹ_With(Add(200)))  // (0, To.Aʺʺʺʹ) -> 333, (0, To.Aʺʺʺʺ) -> 333
                .End();                                 // (0, To.Aʺʺʺʺʹ) -> 333, (0, To.Aʺʺʺʺʺ) -> 333

            A result = f(new A(0));

            return result.Value;
        }

        [TestCase(1,   false, ExpectedResult = 2,   TestName = "Test_0507( 1, false -> 2 )")]
        [TestCase(2,   false, ExpectedResult = 3,   TestName = "Test_0507( 2, false -> 3 )")]
        [TestCase(101, false, ExpectedResult = 102, TestName = "Test_0507( 101, false -> 102 )")]
        [TestCase(1,   true,  ExpectedResult = 2,   TestName = "Test_0507( 1, true -> 2 )")]
        [TestCase(2,   true,  ExpectedResult = 3,   TestName = "Test_0507( 2, true -> 3 )")]
        [TestCase(200, true,  ExpectedResult = 201, TestName = "Test_0507( 200, false -> 201 )")]
        [TestCase(101, true,  ExpectedResult = 104, TestName = "Test_0507( 101, false -> 104 )")]
        public int Test_0507(int x, bool isAʺ)
        {
            var from_A_To_Aʹ_OrTo_Aʺ_With =
                From_A_To_Aʹ_OrTo_Aʺ(isAʺ);

            var f =
                 from_A_To_Aʹ_OrTo_Aʺ_With(Add(1))              
                .If(Aʹ_Is(Even))                        // (1, false) -> 2, (2, false) -> 3
                .AndIf(Object<Aʹ>.Is<Aʺ>)               // (101, false) -> 102, (1, true) -> 2
                .AndIf(Aʺ_Is(MoreThen(100)))            // (2, true) -> 3, (200, false) -> 201
                    .Then(From_Aʺ_To_A_With(Add(2)))    // (101, false) -> 104
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,   To.Aʹ,   ExpectedResult = 12,  TestName = "Test_0508( 1, To.Aʹ -> 12 )")]
        [TestCase(2,   To.Aʹ,   ExpectedResult = 13,  TestName = "Test_0508( 2, To.Aʹ -> 13 )")]
        [TestCase(101, To.Aʺ,   ExpectedResult = 112, TestName = "Test_0508( 101, To.Aʺ -> 112 )")]
        [TestCase(1,   To.Aʺʹ,  ExpectedResult = 12,  TestName = "Test_0508( 1, To.Aʺʹ -> 12 )")]
        [TestCase(2,   To.Aʺʹ,  ExpectedResult = 35,  TestName = "Test_0508( 2, To.Aʺʹ -> 35 )")]
        [TestCase(2,   To.Aʺʺ,  ExpectedResult = 35,  TestName = "Test_0508( 2, To.Aʺʺ -> 35 )")]
        [TestCase(2,   To.Aʺʺʺ, ExpectedResult = 35,  TestName = "Test_0508( 2, To.Aʺʺʺ -> 35 )")]
        public int Test_0508(int x, To to)
        {
            var from_D_To_SomeAʹ_With =
                From_D_To_SomeAʹ(to);

            var f =
                 From_A_To_D_With(Add(1))
                .Then(from_D_To_SomeAʹ_With(Add(10)))      
                .If(Object<Aʹ>.Is<Aʺ>)                  // (1, To.Aʹ) -> 12, (2, To.Aʹ) -> 13
                .AndIf(Aʺ_Is(Odd))                      // (101, To.Aʺ) -> 112, (1, To.Aʺʹ) -> 12
                .AndIf(Object<Aʺ>.Is<Aʺʹ>)
                    .Then(From_Aʺʹ_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))    // (2, To.Aʺʹ) -> 35, (2, To.Aʺʺ) -> 35
                .End();                                 // (2, To.Aʺʺʺ) -> 35

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    ExpectedResult = 3,    TestName = "Test_0509( 2 -> 3 )")]
        [TestCase(1,    ExpectedResult = 2,    TestName = "Test_0509( 1 -> 2 )")]
        [TestCase(12,   ExpectedResult = 13,   TestName = "Test_0509( 12 -> 13 )")]
        [TestCase(11,   ExpectedResult = 14,   TestName = "Test_0509( 11 -> 14 )")]
        [TestCase(2999, ExpectedResult = 3002, TestName = "Test_0509( 2999 -> 3002 )")]
        [TestCase(1989, ExpectedResult = 1995, TestName = "Test_0509( 1989 -> 1995 )")]
        public int Test_0509(int x)
        {
            var f =
                 From_A_To_A_With(Add(1))                  
                .If(A_Is(Even))                             // 2 -> 3, 1 -> 2
                .AndIf(A_Is(MoreThen(10)))                  // 12 -> 13
                    .Then(From_A_To_A_With(Add(2)))         // 11 -> 14
                    .If(A_Is(MoreThen(1000)))               // 2999 -> 3002
                    .AndIf(A_Is(LessThen(2000)))            
                        .Then(From_A_To_A_With(Add(3)))     // 1989 -> 2194
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,   false, false, ExpectedResult = 12,  TestName = "Test_0510( 1, false, false -> 12 )")]
        [TestCase(2,   false, false, ExpectedResult = 13,  TestName = "Test_0510( 2, false, false -> 13 )")]
        [TestCase(2,   true,  false, ExpectedResult = 49,  TestName = "Test_0510( 2, true, false -> 49 )")]
        [TestCase(2,   true,  true,  ExpectedResult = 49,  TestName = "Test_0510( 2, true, true -> 49 )")]
        [TestCase(102, true,  false, ExpectedResult = 149, TestName = "Test_0510( 102, true, false -> 149 )")]
        [TestCase(102, true,  true,  ExpectedResult = 190, TestName = "Test_0510( 102, true, true -> 190 )")]
        public int Test_0510(int x, bool firstIsAʹ, bool secondIsBʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(firstIsAʹ);

            var from_B_To_B_OrTo_Bʹ_With =
                From_B_To_B_OrTo_Bʹ(secondIsBʹ);

            var f =
                 From_A_To_A_With(Add(1))
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(10)))           
                .If(A_Is(Odd))                                  // (1, false, false) -> 12, (2, false, false) -> 13
                .AndIf(Object<A>.Is<Aʹ>)                        // (1, true, false) -> 12
                    .Then(From_Aʹ_To_B_With(Add(2)))
                    .Then(from_B_To_B_OrTo_Bʹ_With(Add(20)))    // (2, true, false) -> 49    // +7, +7
                    .If(B_Is(MoreThen(100)))                    // (2, true, true) -> 49     // +7, +7
                    .AndIf(Object<B>.Is<Bʹ>)                    // (102, true, false) -> 149 // +7, +7
                        .Then(From_Bʹ_To_A_With(Add(20)))
                        .Then(From_A_To_B_With(Add(21)))        // (102, true, true) -> 190  // +7, +7
                    .End()
                    .Then(From_B_To_C_With(Add(7)))
                    .Then(From_C_To_A_With(Add(7)))
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(2,    false, ExpectedResult = 113,  TestName = "Test_0511( 2, false -> 113 )")]
        [TestCase(2,    true,  ExpectedResult = 113,  TestName = "Test_0511( 2, true -> 113 )")]
        [TestCase(3,    false, ExpectedResult = 336,  TestName = "Test_0511( 3, false -> 336 )")]
        [TestCase(3,    true,  ExpectedResult = 336,  TestName = "Test_0511( 3, true -> 336 )")]
        [TestCase(1003, false, ExpectedResult = 1336, TestName = "Test_0511( 1003, false -> 1336 )")]
        [TestCase(1003, true,  ExpectedResult = 1336, TestName = "Test_0511( 1003, true -> 1336 )")]
        [TestCase(601,  false, ExpectedResult = 934,  TestName = "Test_0511( 601, false -> 934 )")]
        [TestCase(601,  true,  ExpectedResult = 934,  TestName = "Test_0511( 601, true -> 934 )")]
        [TestCase(603,  false, ExpectedResult = 936,  TestName = "Test_0511( 603, false -> 936 )")]
        [TestCase(603,  true,  ExpectedResult = 1269, TestName = "Test_0511( 603, true -> 1269 )")]
        public int Test_0511(int x, bool isAʹ)
        {
            var from_A_To_A_OrTo_Aʹ_With =
                From_A_To_A_OrTo_Aʹ(isAʹ);

            var f =
                 From_A_To_A_With(Add(1))
                .Then(From_A_To_A_With(Add(10)))
                .Then(From_A_To_A_With(Add(100)))
                .If(A_Is(Even))                                 // (2, false) -> 113, (2, true) -> 113
                    .Then(From_A_To_A_With(Add(2)))
                    .Then(From_A_To_A_With(Add(20)))
                    .Then(from_A_To_A_OrTo_Aʹ_With(Add(200)))   // (3, false) -> 336, (3, true) -> 336
                    .If(A_Is(MoreThen(900)))                    // (1003, false) -> 1336, (1003, true) -> 1336
                    .AndIf(A_Is(LessThen(1000)))                // (601, false) -> 934
                    .AndIf(Object<A>.Is<Aʹ>)                    // (601, true) -> 934
                    .AndIf(Aʹ_Is(EndingWith("6")))              // (603, false) -> 936
                        .Then(From_Aʹ_To_A_With(Add(3)))
                        .Then(From_A_To_A_With(Add(30)))
                        .Then(From_A_To_A_With(Add(300)))       // (603, true) -> 1269
                    .End()
                .End();

            A result = f(new A(x));

            return result.Value;
        }

        [TestCase(1,    ExpectedResult = 2,    TestName = "Test_0512( 1 -> 2 )")]
        [TestCase(2,    ExpectedResult = 3,    TestName = "Test_0512( 2 -> 3 )")]
        [TestCase(13,   ExpectedResult = 16,   TestName = "Test_0512( 13 -> 16 )")]
        [TestCase(3,    ExpectedResult = 6,    TestName = "Test_0512( 3 -> 6 )")]
        [TestCase(1003, ExpectedResult = 1009, TestName = "Test_0512( 1003 -> 1009 )")]
        public int Test_0512(int x)
        {
            var f =
                 From_A_To_B_With(Add(1))                   
                .If(B_Is(Even))                            // 1 -> 2, 2 -> 3 
                .AndIf(B_Is(EndingWith("4"))) 
                    .Then(From_B_To_Bʹ_With(Add(2)))       // 3 -> 6, 13 -> 16
                    .If(Bʹ_Is(MoreThen(1000)))
                        .Then(From_B_To_Bʹ_With(Add(3)))   // 1003 -> 1009
                    .End()
                .End();

            B result = f(new A(x));

            return result.Value;
        }
    }
}
