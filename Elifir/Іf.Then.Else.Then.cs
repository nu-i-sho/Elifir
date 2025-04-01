namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalMap,
                    o.ElseMap.Then(map));

        public static Func<I, T> End<I, T, E>(
            this Іf<I>.Then<T>.Else.Then<E> o)
                where E : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, E> End<I, T, E>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, B> End<I, T, E, B>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            WithReturnType<B> _)
                where T : B
                where E : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : o.ElseMap(i);
    }
}
