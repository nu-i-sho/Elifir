namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public class NotForCallException()
            : NotSupportedException("It is not for call !!!");

        public static Iʹ Is<Iʹ>() =>
            throw new NotForCallException();

        public static class Object<T>
        {
            public static (T, Tʹ) Is<Tʹ>()
                where Tʹ : T => throw new NotForCallException();
        }

        public static T WithReturn<T>() =>
            throw new NotForCallException();
    }
}
