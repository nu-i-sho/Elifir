namespace Nuisho
{
    public static partial class ˣ
    {
        public readonly partial record struct If<I>
        {
            public readonly partial record struct Then<T>
            {
                public readonly record struct Else<E>(
                    Elifir.ConditionalMap<I, T> ConditionalThenMap,
                    Func<I, E> ElseMap);
            }
        }
    }

    public static partial class Elifir
    {
        public static ˣ.If<I>.Then<T>.Else<Eʹ> Then<I, T, E, Eʹ>(
            this ˣ.If<I>.Then<T>.Else<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalThenMap,
                    o.ElseMap.Then(map));

        public static ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>> ThenIf<I, T, E>(
            this ˣ.If<I>.Then<T>.Else<E> o,
            Func<E, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Is<Eʹ>> ThenIf<I, T, E, Eʹ>(
            this ˣ.If<I>.Then<T>.Else<E> o,
            ConditionalMap<E, Eʹ> condition)
                where Eʹ : E =>
                    new(o, If(condition));

        public static Func<I, T> End<I, T, E>(
            this ˣ.If<I>.Then<T>.Else<E> o)
                where E : T =>
                    i => o.ConditionalThenMap(i, out T t) ? t : o.ElseMap(i);

        public static Func<I, E> End<I, T, E>(
            this ˣ.If<I>.Then<T>.Else<E> o,
            AdHocPolyMarker _ = default)
                where T : E =>
                    i => o.ConditionalThenMap(i, out T t) ? t : o.ElseMap(i);

        public static Func<I, B> End<I, T, E, B>(
            this ˣ.If<I>.Then<T>.Else<E> o,
            ReturnType<B> _)
                where T : B
                where E : B =>
                    i => o.ConditionalThenMap(i, out T t) ? t : o.ElseMap(i);
    }
}
