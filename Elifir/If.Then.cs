namespace Nuisho.Elifir
{
    public static partial class ˣ
    {
        public readonly partial struct If<I>
        {
            public readonly partial struct Then<T>(
                ConditionalMap<I, T> conditionalMap)
            {
                internal ConditionalMap<I, T> ConditionalMap => conditionalMap;
            }
        }
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this ˣ.If<I>.Then<T> o,
            Func<T, Tʹ> map) =>
                new((I i, out Tʹ tʹ) =>
                {
                    if (o.ConditionalMap(i, out T t))
                    {
                        tʹ = map(t);
                        return true;
                    }

                    tʹ = default;
                    return false;
                });

        public static ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>> ThenIf<I, T>(
            this ˣ.If<I>.Then<T> o,
            Func<T, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Is<Tʹ>> ThenIf<I, T, Tʹ>(
            this ˣ.If<I>.Then<T> o,
            ConditionalMap<T, Tʹ> condition)
                where Tʹ : T =>
                    new(o, If(condition));

        public static ˣ.If<I>.Then<T>.Else<E> Else<I, T, E>(
            this ˣ.If<I>.Then<T> o,
            Func<I, E> map) =>
                new(o.ConditionalMap, map);

        public static Func<I, I> End<I, T>(
            this ˣ.If<I>.Then<T> o)
                where T : I =>
                    i => o.ConditionalMap(i, out T t) ? t : i;

        public static Func<I, T> End<I, T>(
            this ˣ.If<I>.Then<T> o,
            AdHocPolyMarker _ = default)
                where I : T =>
                    i => o.ConditionalMap(i, out T t) ? t : i;

        public static Func<I, B> End<I, T, B>(
            this ˣ.If<I>.Then<T> o,
            ReturnType<B> _)
                where T : B
                where I : B =>
                    i => o.ConditionalMap(i, out T t) ? t : i;
    }
}
