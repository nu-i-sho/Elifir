namespace Nuisho.Elifir
{
    public sealed partial class Іf<I> {
    public sealed partial class Then<T> {
    public sealed partial class Else {
    public sealed partial class Then<E>
    {
        internal Then(
            ConditionalMap<I, T> conditionalMap,
            Func<I, E> elseMap)
        {
            ConditionalMap = conditionalMap;
            ElseMap = elseMap;
        }

        internal ConditionalMap<I, T> ConditionalMap { get; }
        internal Func<I, E> ElseMap { get; }
    }}}}

    public static partial class Syntax
    {
        public static Іf<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalMap,
                    o.ElseMap.Then(map));

        public static (Іf<I>.Then<T>.Else.Then<E>, Іf<E>) If<I, T, E>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            Func<E, bool> condition) =>
                (o, If(condition));

        public static (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Is<Eʹ>) If<I, T, E, Eʹ>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            IsOfType<Eʹ> condition)
                where Eʹ : E =>
                    (o, new());

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
