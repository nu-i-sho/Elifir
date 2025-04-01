namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static class Object<T>
        {
            public static (T, Tʹ) Is<Tʹ>()
                where Tʹ : T => throw new NotSupportedException("It is not for call !!!");
        }
    }
}
