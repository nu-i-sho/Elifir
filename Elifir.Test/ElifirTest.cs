namespace Nuisho
{
    using NUnit.Framework;
    using Nuisho.Elifir;
    using static Nuisho.Elifir.Syntax;

    [TestFixture]
    public class ElifirTest
    {
        [Test]
        public void Then__WithoutTypeChanging__Test()
        {
            var f = FromIntToInt_Plus_10
              .Then(FromIntToInt_Multiply_2)
              .Then(FromIntToInt_Plus_10)
              .Then(FromIntToInt_Multiply_2)
              .Then(FromIntToInt_Plus_10);

            Assert.That(f(5), Is.EqualTo(90));
        }

        [Test]
        public void Then__Test()
        {
            var f = FromIntToInt_Plus_10
              .Then(FromIntToInt_Multiply_2)
              .Then(FromIntToInt_Plus_10)
              .Then(FromIntToDouble_Multiply_3_PlusHalf)
              .Then(FromDoubleToInt_Celling)
              .Then(FromIntToDouble_Multiply_3_PlusHalf);

            Assert.That(f(3), Is.EqualTo(327.5));
        }

        [Test]
        public void IfThen__WithoutTypeChanging__Test1()
        {
            var f =
                If(IsEvenInt)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToInt_Multiply_2))
               .End();

            Assert.That(f(3), Is.EqualTo(3));
            Assert.That(f(2), Is.EqualTo(24));
        }

        [Test]
        public void IfThen__WithoutTypeChanging__Test2()
        {
            var f = 
                If(IsEvenInt)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToInt_Multiply_2
                    .Then(If(IsEvenInt)
                        .Then(FromIntToInt_Plus_10
                        .Then(FromIntToInt_Plus_10
                        .Then(FromIntToInt_Plus_11
                        .Then(If(IsEvenInt)    
                            .Then(FromIntToInt_Multiply_2
                            .Then(FromIntToInt_Multiply_2))
                        .End()))))
                    .End())))
                .End();

            Assert.That(f(5), Is.EqualTo(5));
            Assert.That(f(4), Is.EqualTo(59));
        }

        [Test]
        public void IfThen__Test1()
        {
            var f =
                If(IsOddInt)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToDouble_Multiply_3_PlusHalf)
                    .Then(FromDoubleToInt_Celling))
               .End();

            Assert.That(f(17), Is.EqualTo(82));
        }

        [Test]
        public void IfThen__Test2()
        {
            var f =
                If(IsEvenInt)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToDouble_Multiply_3_PlusHalf
                    .Then(FromDoubleToInt_Celling
                    .Then(FromIntToInt_Multiply_2
                    .Then(If(IsEvenInt)
                        .Then(FromIntToInt_Plus_10
                        .Then(FromIntToDouble_Multiply_3_PlusHalf
                        .Then(FromDoubleToInt_Celling
                        .Then(FromIntToInt_Plus_11
                        .Then(FromIntToDouble_Multiply_3_PlusHalf
                        .Then(FromDoubleToInt_Celling
                        .Then(If(IsEvenInt)
                            .Then(FromIntToInt_Multiply_2
                            .Then(FromIntToDouble_Multiply_3_PlusHalf
                            .Then(FromDoubleToInt_Celling
                            .Then(FromIntToInt_Multiply_2))))
                        .End())))))))
                    .End())))))
                .End();

            Assert.That(f(5), Is.EqualTo(5));
            Assert.That(f(2), Is.EqualTo(793));
        }

        [Test]
        public void IfThenElse__WithoutTypeChanging__Test1()
        {
            var f =
                If(IsOddInt)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToInt_Plus_10)
                    .Then(FromIntToInt_Plus_11))
               .Else(FromIntToInt_Plus_11
                    .Then(FromIntToInt_Plus_11)
                    .Then(FromIntToInt_Plus_10))
            .End();

            Assert.That(f(17), Is.EqualTo(48));
            Assert.That(f(12), Is.EqualTo(44));
        }


        [Test]
        public void IfTypeThen__WithoutTypeChanging__Test1()
        {
            var f =
                If(Obj<A>.Is<B>())
                    .Then(BToA_Multiply(3))
               .End();

            Assert.That(f(new A(5)), Is.EqualTo(new A(5)));
            Assert.That(f(new B(5)), Is.EqualTo(new A(5 * 3)));
        }

        [Test]
        public void IfTypeThen__WithoutTypeChanging__Test2()
        {
            var f =
                If(Obj<A>.Is<B>())
                    .Then(BToA_Multiply(3)
                    .Then(AToA_Multiply(2)
                    .Then(AToA_Multiply(4))))
               .End();

            Assert.That(f(new A(5)), Is.EqualTo(new A(5)));
            Assert.That(f(new B(5)), Is.EqualTo(new A(5 * 3 * 2 * 4)));
        }

        [Test]
        public void IfTypeThenElse__WithoutTypeChanging__Test1()
        {
            var f =
                If(Obj<A>.Is<B>())
                    .Then(BToA_Add(12)
                    .Then(AToA_Add(22)
                    .Then(AToA_Multiply(2))))
               .Else(AToA_Add(1)
                    .Then(AToA_Add(2)
                    .Then(AToA_Add(3))))
               .End();

            Assert.That(f(new A(5)), Is.EqualTo(new A(11)));
            Assert.That(f(new B(5)), Is.EqualTo(new A(78)));
        }

        [Test]
        public void IfTypeThenElse__Test1()
        {
            var f =
                If(Obj<A>.Is<B>())
                    .Then(BToA_Add(12)
                    .Then(AToC_Add(4)))
               .Else(AToA_Add(1)
                    .Then(AToC_Multiply(2)))
               .End();

            Assert.That(f(new A(5)), Is.EqualTo(new C(12)));
            Assert.That(f(new B(5)), Is.EqualTo(new C(21)));
        }


        [Test]
        public void IfTypeThenElse__Test2()
        {
            var f =
                If(Obj<A>.Is<B>())
                    .Then(BToC_Add(12)
                    .Then(CToC_Add(47)
                    .Then(            
                        If(Obj<C>.Is<D>())
                            .Then(DToE_Multiply(2)
                            .Then(EToE_Multiply(3)
                            .Then(EToE_Add(11)
                            .Then(            
                                If(IsEven<E>())
                                     .Then(EToE_Add(3)
                                     .Then(
                                         If(Obj<E>.Is<F>())
                                             .Then(FToF_Multiply(3)
                                             .Then(FToF_Add(4)))
                                        .End()))
                                 .Else(
                                    If(Obj<D>.Is<E>())
                                        .Then(EToE_Multiply(2)
                                        .Then(EToE_Add(4)))
                                   .Else(DToE_Add(1)
                                        .Then(EToE_Add(2)
                                        .Then(EToE_Add(3))))
                                   .End())
                                .End()))))
                          .End())))
                    .End();

            Assert.That(f(new A(5)), Is.EqualTo(new A(5)));
            Assert.That(f(new B(1)), Is.EqualTo(new C(60)));
            Assert.That(f(new C(2)), Is.EqualTo(new C(61)));
            Assert.That(f(new D(2)), Is.EqualTo(new F(1111)));

        }

        public static Func<int, bool> IsOddInt => x => x % 2 != 0;

        public static Func<int, bool> IsEvenInt => x => x % 2 == 0;

        public static Func<int, int> FromIntToInt_Plus_10 => x => x + 10;

        public static Func<int, int> FromIntToInt_Plus_11 => x => x + 11;

        public static Func<int, int> FromIntToInt_Multiply_2 => x => x * 2;

        public static Func<int, double> FromIntToDouble_Multiply_3_PlusHalf => x => x * 3 + 0.5;

        public static Func<double, int> FromDoubleToInt_Celling => x => (int)Math.Ceiling(x);

        public record A(int Value);
        public record B(int Value) : A(Value);
        public record C(int Value) : B(Value);
        public record D(int Value) : C(Value);
        public record E(int Value) : D(Value);
        public record F(int Value) : E(Value);

        public static Func<int, Func<A, A>> AToA_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<A, A>> AToA_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<B, A>> BToA_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<B, A>> BToA_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<B, C>> BToC_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<B, C>> BToC_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<C, A>> CToA_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<C, A>> CToA_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<C, C>> CToC_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<C, C>> CToC_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<A, C>> AToC_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<A, C>> AToC_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<C, D>> CToD_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<C, D>> CToD_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<D, D>> DToD_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<D, D>> DToD_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<D, E>> DToE_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<D, E>> DToE_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<E, E>> EToE_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<E, E>> EToE_Add      => a => x => new(x.Value + a);
        public static Func<int, Func<F, F>> FToF_Multiply => a => x => new(x.Value * a);
        public static Func<int, Func<F, F>> FToF_Add      => a => x => new(x.Value + a);
        
        public static Func<T, bool> IsEven<T>() where T : A => x => x.Value % 2 == 0;
    }
}