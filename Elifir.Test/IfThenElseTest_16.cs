namespace Nuisho.Elifir.Test;

using static Syntax;
using static Utils;

[TestFixture]
public class IfThenElseTest_16
{
    [TestCase(2, false, ExpectedResult = 2, TestName = "Test_1600( 2, false -> 2 )")]
    [TestCase(1, false, ExpectedResult = 1, TestName = "Test_1600( 1, false -> 1 )")]
    [TestCase(1, true,  ExpectedResult = 3, TestName = "Test_1600( 1, true -> 3 )")]
    [TestCase(2, true,  ExpectedResult = 5, TestName = "Test_1600( 2, true -> 5 )")]
    public int Test_1600(int x, bool isΛ)
    {
        var f =
             If(Object<A>.Is<Λ>)                        // (2, false) -> 2, (1, false) -> 1
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_ΔΔ_With(Add(2)))    // (1, true) -> 3
                .Else()
                    .Then(From_Λ_To_ΛΛ_With(Add(3)))    // (2, true) -> 5
                .End(WithReturn<A>)
            .End();

        A arg = isΛ
            ? new Λ(x)
            : new A(x);

        A result = f(arg);

        return result.Value;
    }

    [TestCase(2, false, ExpectedResult = 2, TestName = "Test_1601( 2, false -> 2 )")]
    [TestCase(1, false, ExpectedResult = 1, TestName = "Test_1601( 1, false -> 1 )")]
    [TestCase(1, true,  ExpectedResult = 3, TestName = "Test_1601( 1, true -> 3 )")]
    [TestCase(2, true,  ExpectedResult = 5, TestName = "Test_1601( 2, true -> 5 )")]
    public int Test_1601(int x, bool isΛ)
    {
        var f =
             If(Object<A>.Is<Λ>)                        // (2, false) -> 2, (1, false) -> 1
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_Λ_With(Add(2)))     // (1, true) -> 3
                .Else()
                    .Then(From_Λ_To_ΛΛ_With(Add(3)))    // (2, true) -> 5
                .End()
            .End();

        A arg = isΛ
            ? new Λ(x)
            : new A(x);

        A result = f(arg);

        return result.Value;
    }

    [TestCase(2, false, ExpectedResult = 2, TestName = "Test_1602( 2, false -> 2 )")]
    [TestCase(1, false, ExpectedResult = 1, TestName = "Test_1602( 1, false -> 1 )")]
    [TestCase(1, true,  ExpectedResult = 3, TestName = "Test_1602( 1, true -> 3 )")]
    [TestCase(2, true,  ExpectedResult = 5, TestName = "Test_1602( 2, true -> 5 )")]
    public int Test_1602(int x, bool isΛ)
    {
        var f =
             If(Object<A>.Is<Λ>)                        // (2, false) -> 2, (1, false) -> 1
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_ΛΛ_With(Add(2)))    // (1, true) -> 3
                .Else()
                    .Then(From_Λ_To_Λ_With(Add(3)))     // (2, true) -> 5
                .End()
            .End();

        A arg = isΛ
            ? new Λ(x)
            : new A(x);

        A result = f(arg);

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 2,  TestName = "Test_1603( 1 -> 2 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_1603( 2 -> 2 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_1603( 12 -> 14 )")]
    public int Test_1603(int x)
    {
        var f =
             If(Λ_Is(Odd))
                .Then(From_Λ_To_Λ_With(Add(1)))         // 1 -> 2
            .Else()
                .If(Λ_Is(MoreThen(10)))                 // 2 -> 2
                    .Then(From_Λ_To_Δ_With(Add(2)))     // 12 -> 14
                .End(WithReturn<A>)
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 2,  TestName = "Test_1604( 1 -> 2 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_1604( 2 -> 2 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_1604( 12 -> 14 )")]
    public int Test_1604(int x)
    {
        var f =
             If(Λ_Is(Odd))
                .Then(From_Λ_To_Λ_With(Add(1)))         // 1 -> 2
            .Else()
                .If(Λ_Is(MoreThen(10)))                 // 2 -> 2
                    .Then(From_Λ_To_ΛΛ_With(Add(2)))    // 12 -> 14
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 2,  TestName = "Test_1605( 1 -> 2 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_1605( 2 -> 2 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_1605( 12 -> 14 )")]
    public int Test_1605(int x)
    {
        var f =
             If(ΛΛ_Is(Odd))
                .Then(From_Λ_To_Λ_With(Add(1)))          // 1 -> 2
            .Else()
                .If(ΛΛ_Is(MoreThen(10)))                 // 2 -> 2
                    .Then(From_ΛΛ_To_Λ_With(Add(2)))     // 12 -> 14
                .End()
            .End();

        A result = f(new ΛΛ(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_1606( 1 -> 1 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_1606( 2 -> 2 )")]
    [TestCase(11, ExpectedResult = 12, TestName = "Test_1606( 11 -> 12 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_1606( 12 -> 14 )")]
    public int Test_1606(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_Λ_With(Add(1)))
                .Else()
                    .Then(From_Λ_To_Δ_With(Add(2)))
                .End(WithReturn<A>)
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_1607( 1 -> 1 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_1607( 2 -> 2 )")]
    [TestCase(11, ExpectedResult = 12, TestName = "Test_1607( 11 -> 12 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_1607( 12 -> 14 )")]
    public int Test_1607(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_Λ_With(Add(1)))
                .Else()
                    .Then(From_Λ_To_ΛΛ_With(Add(2)))
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(1,  ExpectedResult = 1,  TestName = "Test_1608( 1 -> 1 )")]
    [TestCase(2,  ExpectedResult = 2,  TestName = "Test_1608( 2 -> 2 )")]
    [TestCase(11, ExpectedResult = 12, TestName = "Test_1608( 11 -> 12 )")]
    [TestCase(12, ExpectedResult = 14, TestName = "Test_1608( 12 -> 14 )")]
    public int Test_1608(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))
                .If(Λ_Is(Odd))
                    .Then(From_Λ_To_ΛΛ_With(Add(1)))
                .Else()
                    .Then(From_Λ_To_Λ_With(Add(2)))
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 12, TestName = "Test_1609( 11 -> 12 )")]
    [TestCase(5,  ExpectedResult = 10, TestName = "Test_1609( 5 -> 10 )")]
    [TestCase(2,  ExpectedResult = 8,  TestName = "Test_1609( 2 -> 8 )")]
    public int Test_1609(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))         // 11 -> 12
            .Else()
                .Then(From_A_To_A_With(Add(2)))
                .If(A_Is(Odd))
                    .Then(From_A_To_Λ_With(Add(3)))     // 5 -> 10
                .Else()
                    .Then(From_A_To_Δ_With(Add(4)))     // 2 -> 8
                .End(WithReturn<A>)
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 12, TestName = "Test_1610( 11 -> 12 )")]
    [TestCase(5,  ExpectedResult = 10, TestName = "Test_1610( 5 -> 10 )")]
    [TestCase(2,  ExpectedResult = 8,  TestName = "Test_1610( 2 -> 8 )")]
    public int Test_1610(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))         // 10 -> 11
            .Else()
                .Then(From_A_To_A_With(Add(2)))
                .If(A_Is(Odd))
                    .Then(From_A_To_Λ_With(Add(3)))     // 5 -> 10
                .Else()
                    .Then(From_A_To_ΛΛ_With(Add(4)))    // 2 -> 8
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 12, TestName = "Test_1611( 11 -> 12 )")]
    [TestCase(5,  ExpectedResult = 10, TestName = "Test_1611( 5 -> 10 )")]
    [TestCase(2,  ExpectedResult = 8,  TestName = "Test_1611( 2 -> 8 )")]
    public int Test_1611(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))         // 10 -> 11
            .Else()
                .Then(From_A_To_A_With(Add(2)))
                .If(A_Is(Odd))
                    .Then(From_A_To_ΛΛ_With(Add(3)))    // 5 -> 10
                .Else()
                    .Then(From_A_To_Λ_With(Add(4)))     // 2 -> 8
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 12, TestName = "Test_1612( 11 -> 12 )")]
    [TestCase(5,  ExpectedResult = 8,  TestName = "Test_1612( 5 -> 8 )")]
    [TestCase(2,  ExpectedResult = 6,  TestName = "Test_1612( 2 -> 6 )")]
    public int Test_1612(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))         // 11 -> 12
            .Else()
                .If(A_Is(Odd))
                    .Then(From_A_To_Λ_With(Add(3)))     // 5 -> 8
                .Else()
                    .Then(From_A_To_Δ_With(Add(4)))     // 2 -> 6
                .End(WithReturn<A>)
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 12, TestName = "Test_1613( 11 -> 12 )")]
    [TestCase(5,  ExpectedResult = 8,  TestName = "Test_1613( 5 -> 8 )")]
    [TestCase(2,  ExpectedResult = 6,  TestName = "Test_1613( 2 -> 6 )")]
    public int Test_1613(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))         // 10 -> 11
            .Else()
                .If(A_Is(Odd))
                    .Then(From_A_To_Λ_With(Add(3)))     // 5 -> 8
                .Else()
                    .Then(From_A_To_ΛΛ_With(Add(4)))    // 2 -> 6
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(11, ExpectedResult = 12, TestName = "Test_1614( 11 -> 12 )")]
    [TestCase(5,  ExpectedResult = 8,  TestName = "Test_1614( 5 -> 8 )")]
    [TestCase(2,  ExpectedResult = 6,  TestName = "Test_1614( 2 -> 6 )")]
    public int Test_1614(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))
                .Then(From_A_To_A_With(Add(1)))         // 10 -> 11
            .Else()
                .If(A_Is(Odd))
                    .Then(From_A_To_ΛΛ_With(Add(3)))    // 5 -> 8
                .Else()
                    .Then(From_A_To_Λ_With(Add(4)))     // 2 -> 6
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,  false, ExpectedResult = 2,  TestName = "Test_1615( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,  TestName = "Test_1615( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 4,  TestName = "Test_1615( 3, false -> 4 )")]
    [TestCase(3,  true,  ExpectedResult = 4,  TestName = "Test_1615( 3, true -> 4 )")]
    [TestCase(13, true,  ExpectedResult = 16, TestName = "Test_1615( 13, true -> 16 )")]
    public int Test_1615(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Odd))                                   // (2, false) -> 2, (2, true) -> 2
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))     // (3, false) -> 4
                .If(Is<Aʹ>)                                 // (3, true) -> 4
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_ΔΔ_With(Add(2)))   // (13, true) -> 16
                    .End(WithReturn<A>)
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,  false, ExpectedResult = 2,  TestName = "Test_1616( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,  TestName = "Test_1616( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 4,  TestName = "Test_1616( 3, false -> 4 )")]
    [TestCase(3,  true,  ExpectedResult = 4,  TestName = "Test_1616( 3, true -> 4 )")]
    [TestCase(13, true,  ExpectedResult = 16, TestName = "Test_1616( 13, true -> 16 )")]
    public int Test_1616(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Odd))                                   // (2, false) -> 2, (2, true) -> 2
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))     // (3, false) -> 4
                .If(Is<Aʹ>)                                 // (3, true) -> 4
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_Aʺ_With(Add(2)))   // (13, true) -> 16
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,  false, ExpectedResult = 2,  TestName = "Test_1617( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,  TestName = "Test_1617( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 4,  TestName = "Test_1617( 3, false -> 4 )")]
    [TestCase(3,  true,  ExpectedResult = 4,  TestName = "Test_1617( 3, true -> 4 )")]
    [TestCase(13, true,  ExpectedResult = 16, TestName = "Test_1617( 13, true -> 16 )")]
    public int Test_1617(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Odd))                                   // (2, false) -> 2, (2, true) -> 2
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))     // (3, false) -> 4
                .If(Is<Aʹ>)                                 // (3, true) -> 4
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_A_With(Add(2)))    // (13, true) -> 16
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,  false, ExpectedResult = 2,  TestName = "Test_1618( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,  TestName = "Test_1618( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 4,  TestName = "Test_1618( 3, false -> 4 )")]
    [TestCase(13, true,  ExpectedResult = 16, TestName = "Test_1618( 13, true -> 16 )")]
    [TestCase(3,  true,  ExpectedResult = 7,  TestName = "Test_1618( 3, true -> 7 )")]
    public int Test_1618(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Odd))                                   // (2, false) -> 2, (2, true) -> 2
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))     // (3, false) -> 4
                .If(Is<Aʹ>)
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_Δ_With(Add(2)))    // (13, true) -> 16
                    .Else()
                        .Then(From_Aʹ_To_Λ_With(Add(3)))    // (3, true) -> 7
                    .End(WithReturn<A>)
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,  false, ExpectedResult = 2,  TestName = "Test_1619( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,  TestName = "Test_1619( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 4,  TestName = "Test_1619( 3, false -> 4 )")]
    [TestCase(13, true,  ExpectedResult = 16, TestName = "Test_1619( 13, true -> 16 )")]
    [TestCase(3,  true,  ExpectedResult = 7,  TestName = "Test_1619( 3, false -> 7 )")]
    public int Test_1619(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Odd))                                   // (2, false) -> 2, (2, true) -> 2
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))     // (3, false) -> 4
                .If(Is<Aʹ>)
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_Λ_With(Add(2)))    // (13, true) -> 16
                    .Else()
                        .Then(From_Aʹ_To_ΛΛ_With(Add(3)))   // (3, true) -> 7
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(2,  false, ExpectedResult = 2,  TestName = "Test_1617( 2, false -> 2 )")]
    [TestCase(2,  true,  ExpectedResult = 2,  TestName = "Test_1617( 2, true -> 2 )")]
    [TestCase(3,  false, ExpectedResult = 4,  TestName = "Test_1617( 3, false -> 4 )")]
    [TestCase(13, true,  ExpectedResult = 16, TestName = "Test_1617( 13, true -> 16 )")]
    [TestCase(3,  true,  ExpectedResult = 7,  TestName = "Test_1617( 3, false -> 7 )")]
    public int Test_1620(int x, bool isAʹ)
    {
        var from_A_To_A_OrTo_Aʹ_With =
            From_A_To_A_OrTo_Aʹ(isAʹ);

        var f =
            If(A_Is(Odd))                                   // (2, false) -> 2, (2, true) -> 2
                .Then(from_A_To_A_OrTo_Aʹ_With(Add(1)))     // (3, false) -> 4
                .If(Is<Aʹ>)
                    .If(Aʹ_Is(MoreThen(10)))
                        .Then(From_Aʹ_To_ΛΛ_With(Add(2)))   // (13, true) -> 16
                    .Else()
                        .Then(From_Aʹ_To_Λ_With(Add(3)))    // (3, true) -> 7
                    .End()
                .End()
           .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1621( 5 -> 6 )")]
    [TestCase(101, ExpectedResult = 103, TestName = "Test_1621( 101 -> 103 )")]
    [TestCase(16,  ExpectedResult = 17,  TestName = "Test_1621( 16 -> 17 )")]
    [TestCase(114, ExpectedResult = 114, TestName = "Test_1621( 114 -> 114 )")]
    public int Test_1621(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))        // 5 -> 6, 16 -> 17
                .Else()
                    .If(Λ_Is(Odd))                         // 114 -> 114
                        .Then(From_Λ_To_Δ_With(Add(2)))    // 101 -> 103
                    .End(WithReturn<A>)
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1622( 5 -> 6 )")]
    [TestCase(101, ExpectedResult = 103, TestName = "Test_1622( 101 -> 103 )")]
    [TestCase(16,  ExpectedResult = 17,  TestName = "Test_1622( 16 -> 17 )")]
    [TestCase(114, ExpectedResult = 114, TestName = "Test_1622( 114 -> 114 )")]
    public int Test_1622(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))        // 5 -> 6, 16 -> 17
                .Else()
                    .If(Λ_Is(Odd))                         // 114 -> 114
                        .Then(From_Λ_To_ΛΛ_With(Add(2)))   // 101 -> 103
                    .End()
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1623( 5 -> 6 )")]
    [TestCase(101, ExpectedResult = 103, TestName = "Test_1623( 101 -> 103 )")]
    [TestCase(16,  ExpectedResult = 17,  TestName = "Test_1623( 16 -> 17 )")]
    [TestCase(114, ExpectedResult = 114, TestName = "Test_1623( 114 -> 114 )")]
    public int Test_1623(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))        // 5 -> 6, 16 -> 17
                .Else()
                    .If(Λ_Is(Odd))                         // 114 -> 114
                        .Then(From_Λ_To_A_With(Add(2)))    // 101 -> 103
                    .End()
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1630( 5 -> 5 )")]
    [TestCase(101, ExpectedResult = 101, TestName = "Test_1630( 101 -> 101 )")]
    [TestCase(16,  ExpectedResult = 19,  TestName = "Test_1630( 16 -> 19 )")]
    [TestCase(15,  ExpectedResult = 17,  TestName = "Test_1630( 15 -> 17 )")]
    public int Test_1630(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                        // 5 -> 5
                .If(Λ_Is(LessThen(100)))                   // 101 -> 101
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_ΛΔ_With(Add(2)))   // 15 -> 17
                    .Else()
                        .Then(From_Λ_To_ΛΛ_With(Add(3)))   // 16 -> 19
                    .End(WithReturn<Λ>)
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1631( 5 -> 5 )")]
    [TestCase(101, ExpectedResult = 101, TestName = "Test_1631( 101 -> 101 )")]
    [TestCase(16,  ExpectedResult = 19,  TestName = "Test_1631( 16 -> 19 )")]
    [TestCase(15,  ExpectedResult = 17,  TestName = "Test_1631( 15 -> 17 )")]
    public int Test_1631(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))                        // 5 -> 5
                .If(A_Is(LessThen(100)))                   // 101 -> 101
                    .If(A_Is(Odd))
                        .Then(From_A_To_Λ_With(Add(2)))    // 15 -> 17
                    .Else()
                        .Then(From_A_To_ΛΛ_With(Add(3)))   // 16 -> 19
                    .End()
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1632( 5 -> 5 )")]
    [TestCase(101, ExpectedResult = 101, TestName = "Test_1632( 101 -> 101 )")]
    [TestCase(16,  ExpectedResult = 19,  TestName = "Test_1632( 16 -> 19 )")]
    [TestCase(15,  ExpectedResult = 17,  TestName = "Test_1632( 15 -> 17 )")]
    public int Test_1632(int x)
    {
        var f =
             If(A_Is(MoreThen(10)))                        // 5 -> 5
                .If(A_Is(LessThen(100)))                   // 101 -> 101
                    .If(A_Is(Odd))
                        .Then(From_A_To_ΛΛ_With(Add(2)))   // 15 -> 17
                    .Else()
                        .Then(From_A_To_Λ_With(Add(3)))    // 16 -> 19
                    .End()
                .End()
            .End();

        A result = f(new A(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1640( 5 -> 5 )")]
    [TestCase(15,  ExpectedResult = 16,  TestName = "Test_1640( 15 -> 16 )")]
    [TestCase(101, ExpectedResult = 103, TestName = "Test_1640( 101 -> 103 )")]
    [TestCase(102, ExpectedResult = 105, TestName = "Test_1640( 102 -> 105 )")]
    public int Test_1640(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                         // 5 -> 5
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))         // 15 -> 16
                .Else()
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_ΛΔ_With(Add(2)))    // 101 -> 103
                    .Else()
                        .Then(From_Λ_To_ΛΛ_With(Add(3)))    // 102 -> 105
                    .End(WithReturn<Λ>)
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1641( 5 -> 5 )")]
    [TestCase(15,  ExpectedResult = 16,  TestName = "Test_1641( 15 -> 16 )")]
    [TestCase(101, ExpectedResult = 103, TestName = "Test_1641( 101 -> 103 )")]
    [TestCase(102, ExpectedResult = 105, TestName = "Test_1641( 102 -> 105 )")]
    public int Test_1641(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                         // 5 -> 5
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))         // 15 -> 16
                .Else()
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_Λ_With(Add(2)))     // 101 -> 103
                    .Else()
                        .Then(From_Λ_To_ΛΛ_With(Add(3)))    // 102 -> 105
                    .End(WithReturn<Λ>)
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1642( 5 -> 5 )")]
    [TestCase(15,  ExpectedResult = 16,  TestName = "Test_1642( 15 -> 16 )")]
    [TestCase(101, ExpectedResult = 103, TestName = "Test_1642( 101 -> 103 )")]
    [TestCase(102, ExpectedResult = 105, TestName = "Test_1642( 102 -> 105 )")]
    public int Test_1642(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                         // 5 -> 5
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))         // 15 -> 16
                .Else()
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_ΛΛ_With(Add(2)))    // 101 -> 103
                    .Else()
                        .Then(From_Λ_To_Λ_With(Add(3)))     // 102 -> 105
                    .End(WithReturn<Λ>)
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1643( 5 -> 5 )")]
    [TestCase(12,  ExpectedResult = 13,  TestName = "Test_1643( 12 -> 13 )")]
    [TestCase(101, ExpectedResult = 106, TestName = "Test_1643( 101 -> 106 )")]
    [TestCase(104, ExpectedResult = 110, TestName = "Test_1643( 104 -> 110 )")]
    public int Test_1643(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                         // 5 -> 5
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))         // 12 -> 13
                .Else()
                    .Then(From_Λ_To_Λ_With(Add(2)))
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_ΛΔ_With(Add(3)))    // 101 -> 106
                    .Else()
                        .Then(From_Λ_To_ΛΛ_With(Add(4)))    // 104 -> 110
                    .End(WithReturn<Λ>)
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1644( 5 -> 5 )")]
    [TestCase(12,  ExpectedResult = 13,  TestName = "Test_1644( 12 -> 13 )")]
    [TestCase(101, ExpectedResult = 106, TestName = "Test_1644( 101 -> 106 )")]
    [TestCase(104, ExpectedResult = 110, TestName = "Test_1644( 104 -> 110 )")]
    public int Test_1644(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                         // 5 -> 5
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))         // 12 -> 13
                .Else()
                    .Then(From_Λ_To_Λ_With(Add(2)))
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_Λ_With(Add(3)))     // 101 -> 106
                    .Else()
                        .Then(From_Λ_To_ΛΛ_With(Add(4)))    // 104 -> 110
                    .End()
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   ExpectedResult = 5,   TestName = "Test_1645( 5 -> 5 )")]
    [TestCase(12,  ExpectedResult = 13,  TestName = "Test_1645( 12 -> 13 )")]
    [TestCase(101, ExpectedResult = 106, TestName = "Test_1645( 101 -> 106 )")]
    [TestCase(104, ExpectedResult = 110, TestName = "Test_1645( 104 -> 110 )")]
    public int Test_1645(int x)
    {
        var f =
             If(Λ_Is(MoreThen(10)))                         // 5 -> 5
                .If(Λ_Is(LessThen(100)))
                    .Then(From_Λ_To_Λ_With(Add(1)))         // 12 -> 13
                .Else()
                    .Then(From_Λ_To_Λ_With(Add(2)))
                    .If(Λ_Is(Odd))
                        .Then(From_Λ_To_ΛΛ_With(Add(3)))    // 101 -> 106
                    .Else()
                        .Then(From_Λ_To_Λ_With(Add(4)))     // 104 -> 110
                    .End()
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   true,  ExpectedResult = 5,   TestName = "Test_1646( 5 -> 5 )")]
    [TestCase(12,  true,  ExpectedResult = 13,  TestName = "Test_1646( 12 -> 13 )")]
    [TestCase(101, true,  ExpectedResult = 106, TestName = "Test_1646( 101 -> 106 )")]
    [TestCase(101, false, ExpectedResult = 107, TestName = "Test_1646( 104 -> 107 )")]
    public int Test_1646(int x, bool isΛ)
    {
        var from_A_To_A_OrTo_Λ_With =
            From_A_To_A_OrTo_Λ(isΛ);

        var f =
             If(A_Is(MoreThen(10)))                         // 5 -> 5
                .If(A_Is(LessThen(100)))
                    .Then(From_A_To_A_With(Add(1)))         // 12 -> 13
                .Else()
                    .Then(from_A_To_A_OrTo_Λ_With(Add(2)))
                    .If(Is<Λ>)
                        .Then(From_Λ_To_ΛΛ_With(Add(3)))    // 101 -> 106
                    .Else()
                        .Then(From_A_To_Λ_With(Add(4)))     // 104 -> 107
                    .End()
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }

    [TestCase(5,   true,  ExpectedResult = 6,   TestName = "Test_1647( 5, true -> 6 )")]
    [TestCase(101, true,  ExpectedResult = 106, TestName = "Test_1647( 101, true -> 106 )")]
    [TestCase(101, false, ExpectedResult = 107, TestName = "Test_1647( 101, false -> 107 )")]
    public int Test_1647(int x, bool isΛ)
    {
        var from_A_To_A_OrTo_Λ_With =
            From_A_To_A_OrTo_Λ(isΛ);

        var f =
             If(A_Is(LessThen(100)))
                .Then(From_A_To_A_With(Add(1)))         // (5, true) -> 6
            .Else()
                .Then(from_A_To_A_OrTo_Λ_With(Add(2)))
                .If(Is<Λ>)
                    .Then(From_Λ_To_ΛΛ_With(Add(3)))    // (101, true) -> 106
                .Else()
                    .Then(From_A_To_Λ_With(Add(4)))     // (101, false) -> 107
                .End()
            .End();

        A result = f(new Λ(x));

        return result.Value;
    }
}
