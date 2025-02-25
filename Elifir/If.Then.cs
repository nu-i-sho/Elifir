namespace Nuisho
{
    public static partial class ˣ
    {
        public readonly partial record struct If<I>
        {
            public readonly partial record struct Then<T>(
                Elifir.ConditionalMap<I, T> ConditionalThenMap);
        }
    }

    public static partial class Elifir
    {
        public static ˣ.If<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this ˣ.If<I>.Then<T> o,
            Func<T, Tʹ> thenMap) =>
                new((I i, out Tʹ tʹ) =>
                {
                    if (o.ConditionalThenMap(i, out T t))
                    {
                        tʹ = thenMap(t);
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
            Func<I, E> elseMap) =>
                new(o.ConditionalThenMap, elseMap);

        public static Func<I, I> End<I, T>(
            this ˣ.If<I>.Then<T> o)
                where T : I =>
                    i => o.ConditionalThenMap(i, out T t) ? t : i;

        public static Func<I, T> End<I, T>(
            this ˣ.If<I>.Then<T> o,
            AdHocPolyMarker _ = default)
                where I : T =>
                    i => o.ConditionalThenMap(i, out T t) ? t : i;

        public static Func<I, B> End<I, T, B>(
            this ˣ.If<I>.Then<T> o,
            ReturnType<B> _)
                where T : B
                where I : B =>
                    i => o.ConditionalThenMap(i, out T t) ? t : i;
    }
}
