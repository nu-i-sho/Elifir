namespace Nuisho.Elifir.Test
{
    using static Syntax;

    [TestFixture]
    public class WithReturnIsNotCallable
    {
        [Test]
        public void Test()
        {
            Assert.Throws<NotSupportedException>(
                () => WithReturn<int>());
        }
    }
}
