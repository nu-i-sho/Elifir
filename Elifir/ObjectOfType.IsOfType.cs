namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static class Object<T>
        {
            public static (T, Tʹ) Is<Tʹ>()
                where Tʹ : T => throw new NotSupportedException("It is not for call !!!");
        }

        public static Іf<I>.Is<Iʹ> If<I, Iʹ>(
            ObjectOfType<I>.IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    new();
    }
}
