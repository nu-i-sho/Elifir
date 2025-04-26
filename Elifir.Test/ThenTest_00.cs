namespace Nuisho.Elifir.Test;

using static Utils;

[TestFixture]
public class ThenTest_00
{
    [Test]
    public void Test_0001()
    {
        var f =
            From_A_To_A_With(Add(1)).Then(
            From_A_To_A_With(Add(2)));

        A result = f(new A(39));

        Assert.That(result.Value, Is.EqualTo(42));
    }

    [Test]
    public void Test_0002()
    {
        var f =
            From_A_To_A_With(Add(1)).Then(
            From_A_To_A_With(Add(2)).Then(
            From_A_To_A_With(Add(3)).Then(
            From_A_To_A_With(Add(4)).Then(
            From_A_To_A_With(Add(5)).Then(
            From_A_To_A_With(Add(6)).Then(
            From_A_To_A_With(Add(7))))))));

        A result = f(new A(14));

        Assert.That(result.Value, Is.EqualTo(42));
    }

    [Test]
    public void Test_0003()
    {
        var f =
            From_A_To_B_With(Add(1)).Then(
            From_B_To_C_With(Add(2)));

        C result = f(new A(39));

        Assert.That(result.Value, Is.EqualTo(42));
    }

    [Test]
    public void Test_0004()
    {
        var f =
            From_A_To_B_With(Add(1)).Then(
            From_B_To_C_With(Add(2)).Then(
            From_C_To_D_With(Add(3)).Then(
            From_D_To_E_With(Add(4)).Then(
            From_E_To_D_With(Add(5)).Then(
            From_D_To_C_With(Add(6)).Then(
            From_C_To_B_With(Add(7))))))));

        B result = f(new A(14));

        Assert.That(result.Value, Is.EqualTo(42));
    }
}
