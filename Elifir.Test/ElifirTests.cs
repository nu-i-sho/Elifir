namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class ElifirTests
    {

        [Test]
        public void Test1()
        {
            var f =
                From_A_To_A_With(Plus(1)).Then(
                From_A_To_A_With(Plus(2)));

            A result = f(new A(39));

            Assert.That(result.Value, Is.EqualTo(42));
        }

        [Test]
        public void Test2()
        {
            var f =
                From_A_To_A_With(Plus(1)).Then(
                From_A_To_A_With(Plus(2)).Then(
                From_A_To_A_With(Plus(3)).Then(
                From_A_To_A_With(Plus(4)).Then(
                From_A_To_A_With(Plus(5)).Then(
                From_A_To_A_With(Plus(6)).Then(
                From_A_To_A_With(Plus(7))))))));

            A result = f(new A(14));

            Assert.That(result.Value, Is.EqualTo(42));
        }


        [Test]
        public void Test3()
        {
            var f =
                From_A_To_B_With(Plus(1)).Then(
                From_B_To_C_With(Plus(2)));

            C result = f(new A(39));

            Assert.That(result.Value, Is.EqualTo(42));
        }

        [Test]
        public void Test4()
        {
            var f =
                From_A_To_B_With(Plus(1)).Then(
                From_B_To_C_With(Plus(2)).Then(
                From_C_To_D_With(Plus(3)).Then(
                From_D_To_E_With(Plus(4)).Then(
                From_E_To_D_With(Plus(5)).Then(
                From_D_To_C_With(Plus(6)).Then(
                From_C_To_B_With(Plus(7))))))));

            B result = f(new A(14));

            Assert.That(result.Value, Is.EqualTo(42));
        }

        [Test]
        public void Test5()
        {
            var f =
                 From_A_To_A_With(Plus(1))
                .ThenIf(A_Is(Even)).Then(
                    From_A_To_A_With(Plus(2)))
                .End();

            A result1 = f(new A(1));
            A result2 = f(new A(2));

            Assert.Multiple(() =>
            {
                Assert.That(result1.Value, Is.EqualTo(4));
                Assert.That(result2.Value, Is.EqualTo(3));
            });
        }

        [Test]
        public void Test6()
        {
            var f =
                 From_A_To_A_With(Plus(1)).Then(
                 From_A_To_A_With(Plus(10)))
                .ThenIf(A_Is(Even)).Then(
                    From_A_To_A_With(Plus(2))).Then(
                    From_A_To_A_With(Plus(20)))
                .End();

            A result1 = f(new A(1));
            A result2 = f(new A(2));

            Assert.Multiple(() =>
            {
                Assert.That(result1.Value, Is.EqualTo(34));
                Assert.That(result2.Value, Is.EqualTo(13));
            });
        }

        [Test]
        public void Test7()
        {
            var f =
                 From_A_To_A_With(Plus(1)).Then(
                 From_A_To_A_With(Plus(10))).Then(
                 From_A_To_A_With(Plus(100)))
                .ThenIf(A_Is(Even)).Then(
                    From_A_To_A_With(Plus(2))).Then(
                    From_A_To_A_With(Plus(20))).Then(
                    From_A_To_A_With(Plus(200)))
                .End();

            A result1 = f(new A(1));
            A result2 = f(new A(2));

            Assert.Multiple(() =>
            {
                Assert.That(result1.Value, Is.EqualTo(334));
                Assert.That(result2.Value, Is.EqualTo(113));
            });
        }

        [Test]
        public void Test8()
        {
            var f =
                 From_A_To_B_With(Plus(1)).Then(
                 From_B_To_C_With(Plus(10))).Then(
                 From_C_To_D_With(Plus(100)))
                .ThenIf(D_Is(Even)).Then(
                    From_D_To_E_With(Plus(2))).Then(
                    From_E_To_B_With(Plus(20))).Then(
                    From_B_To_D_With(Plus(200)))
                .End();

            D result1 = f(new A(1));
            D result2 = f(new A(2));

            Assert.Multiple(() =>
            {
                Assert.That(result1.Value, Is.EqualTo(334));
                Assert.That(result2.Value, Is.EqualTo(113));
            });
        }
    }
}
