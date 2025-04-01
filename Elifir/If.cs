namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I> If<I>(
            Func<I, bool> condition) =>
                new(condition);

        public static Іf<I>.Is<Iʹ> If<I, Iʹ>(
            ObjectOfType<I>.IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    new();
    }
}
