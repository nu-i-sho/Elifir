namespace Nuisho.Elifir
{
    
    public delegate bool ConditionalMap<in T, Tʹ>(T x, out Tʹ xʹ);

    public static class Obj<T>
    {
        public static ConditionalMap<T, Tʹ> Is<Tʹ>()
            where Tʹ : T =>
                (T x, out Tʹ xʹ) =>
                {
                    if (x is Tʹ sub)
                    {
                        xʹ = sub;
                        return true;
                    }

                    xʹ = default;
                    return false;
                };
    }

    public static partial class Syntax
    {
        public static ˣ.If<I> If<I>(
            Func<I, bool> condition) =>
                new(condition);

        public static ˣ.If<I>.Is<Iʹ> If<I, Iʹ>(
            ConditionalMap<I, Iʹ> condition)
                where Iʹ : I =>
                    new(condition);
    }
}
