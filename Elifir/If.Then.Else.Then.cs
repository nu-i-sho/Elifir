namespace Nuisho.Elifir
{
    public static partial class ˣ
    {
        public sealed partial class If<I> {
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
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalMap,
                    o.ElseMap.Then(map));

        public static ˣ<ˣ.If<I>.Then<T>.Else.Then<E>, ˣ.If<E>> If<I, T, E>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            Func<E, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>.Then<T>.Else.Then<E>, ˣ.If<E>.Is<Eʹ>> If<I, T, E, Eʹ>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            Func<TypeCondition<E, Eʹ>> condition)
                where Eʹ : E =>
                    new(o, If(condition));

        public static Func<I, T> End<I, T, E>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o)
                where E : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, E> End<I, T, E>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, B> End<I, T, E, B>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            Func<ReturnType<B>> _)
                where T : B
                where E : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : o.ElseMap(i);
    }
}
