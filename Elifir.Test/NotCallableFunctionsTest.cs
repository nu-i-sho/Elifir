namespace Nuisho.Elifir.Test
{
    using static Utils;
    using static Syntax;

    [TestFixture]
    public class NotCallableFunctionsTest    
    {
        [Test]
        public void WithReturn_IsNotCallable_Test()
        {
            Assert.Throws<NotSupportedException>(
                () => WithReturn<int>());
        }

        [Test]
        public void ObjectIs_IsNotCallable_Test()
        {
            Assert.Throws<NotSupportedException>(
                () => Object<A>.Is<Aʹ>());
        }
    }
}
