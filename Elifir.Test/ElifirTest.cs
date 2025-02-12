namespace Nuisho
{
    using static Elifir;

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
                If(IsEven)
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
                If(IsEven)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToInt_Multiply_2
                    .Then(If(IsEven)
                        .Then(FromIntToInt_Plus_10
                        .Then(FromIntToInt_Plus_10
                        .Then(FromIntToInt_Plus_11
                        .Then(If(IsEven)    
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
                If(IsOdd)
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
                If(IsEven)
                    .Then(FromIntToInt_Plus_10
                    .Then(FromIntToDouble_Multiply_3_PlusHalf
                    .Then(FromDoubleToInt_Celling
                    .Then(FromIntToInt_Multiply_2
                    .Then(If(IsEven)
                        .Then(FromIntToInt_Plus_10
                        .Then(FromIntToDouble_Multiply_3_PlusHalf
                        .Then(FromDoubleToInt_Celling
                        .Then(FromIntToInt_Plus_11
                        .Then(FromIntToDouble_Multiply_3_PlusHalf
                        .Then(FromDoubleToInt_Celling
                        .Then(If(IsEven)
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
                If(IsOdd)
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

        public static Func<int, bool> IsOdd => x => x % 2 != 0;

        public static Func<int, bool> IsEven => x => x % 2 == 0;

        public static Func<int, int> FromIntToInt_Plus_10 => x => x + 10;

        public static Func<int, int> FromIntToInt_Plus_11 => x => x + 11;

        public static Func<int, int> FromIntToInt_Multiply_2 => x => x * 2;

        public static Func<int, double> FromIntToDouble_Multiply_3_PlusHalf => x => x * 3 + 0.5;

        public static Func<double, int> FromDoubleToInt_Celling => x => (int)Math.Ceiling(x);
    }
}