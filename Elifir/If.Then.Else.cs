namespace Nuisho.Elifir
{
    public static partial class ˣ
    {
        public readonly partial struct If<I> {
        public readonly partial struct Then<T> {
        public readonly partial struct Else(
            ConditionalMap<I, T> conditionalMap)
        {
            internal ConditionalMap<I, T> ConditionalMap => conditionalMap;
        }}}
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this ˣ.If<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new(o.ConditionalMap, elseMap);

        public static ˣ<ˣ.If<I>.Then<T>.Else.Then<I>, ˣ.If<I>> If<I, T>(
            this ˣ.If<I>.Then<T>.Else o,
            Func<I, bool> condition) =>
                o.Then(Identity).If(condition);

        public static ˣ<ˣ.If<I>.Then<T>.Else.Then<I>, ˣ.If<I>.Is<Iʹ>> If<I, T, Iʹ>(
            this ˣ.If<I>.Then<T>.Else o,
            Func<ConditionalMap<I, Iʹ>> condition)
                where Iʹ : I =>
                    o.Then(Identity).If(condition);

        static T Identity<T>(T x) => x;
    }
}
