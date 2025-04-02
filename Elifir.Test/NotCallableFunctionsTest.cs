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
            Assert.Throws<NotForCallException>(
                () => WithReturn<int>());
        }

        [Test]
        public void ObjectIs_IsNotCallable_Test()
        {
            Assert.Throws<NotForCallException>(
                () => Object<A>.Is<Aʹ>());
        }

        [Test]
        public void Is_IsNotCallable_Test()
        {
            Assert.Throws<NotForCallException>(
                () => Is<Aʹ>());
        }
    }
}
