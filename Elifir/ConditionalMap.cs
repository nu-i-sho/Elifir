namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public delegate bool ConditionalMap<in I, Iʹ>(
        I i, [NotNullWhen(true)]
             [MaybeNullWhen(false)] 
             out Iʹ iʹ);

    public static class Object<T>
    {
        public static ConditionalMap<T, Tʹ> Is<Tʹ>()
            where Tʹ : T =>
                (T x, [NotNullWhen(true)]
                      [MaybeNullWhen(false)] 
                      out Tʹ xʹ) =>
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
            Func<ConditionalMap<I, Iʹ>> condition)
                where Iʹ : I =>
                    new(condition());
    }
}
