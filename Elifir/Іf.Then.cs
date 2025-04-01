namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static Іf<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this Іf<I>.Then<T> o,
            Func<T, Tʹ> map) =>
                new((I i, [MaybeNullWhen(false)] out Tʹ tʹ) =>
                {
                    if (o.ConditionalMap(i, out T? t))
                    {
                        tʹ = map(t);
                        return true;
                    }

                    tʹ = default;
                    return false;
                });

        public static Іf<I>.Then<T>.Else Else<I, T>(
            this Іf<I>.Then<T> o) =>
                new(o.ConditionalMap);

        public static Func<I, I> End<I, T>(
            this Іf<I>.Then<T> o)
                where T : I =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, T> End<I, T>(
            this Іf<I>.Then<T> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, B> End<I, T, B>(
            this Іf<I>.Then<T> o,
            WithReturnType<B> _)
                where T : B
                where I : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : i;
    }
}
