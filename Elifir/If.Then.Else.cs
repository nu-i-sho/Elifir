namespace Nuisho.Elifir
{
    public static partial class ˣ
    {
        public sealed partial class If<I> {
        public sealed partial class Then<T> {
        public sealed partial class Else
        {
            internal Else(ConditionalMap<I, T> conditionalMap) =>
                ConditionalMap = conditionalMap;

            internal ConditionalMap<I, T> ConditionalMap { get; }
        }}}
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this ˣ.If<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new(o.ConditionalMap, elseMap);

        public static ˣ<ˣ.If<I>.Then<T>.Else, ˣ.If<I>> If<I, T>(
            this ˣ.If<I>.Then<T>.Else o,
            Func<I, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>.Then<T>.Else, ˣ.If<I>.Is<Iʹ>> If<I, T, Iʹ>(
            this ˣ.If<I>.Then<T>.Else o,
            IsOfType<Iʹ> _)
                where Iʹ : I =>
                    new(o, new());
    }
}
