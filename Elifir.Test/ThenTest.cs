namespace Nuisho.Elifir.Test
{
    using static Utils;

    [TestFixture]
    public class ThenTest
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
    }
}
