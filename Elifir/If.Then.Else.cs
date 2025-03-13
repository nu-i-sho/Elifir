namespace Nuisho.Elifir
{
    using static Syntax;

    public partial class ˣIf<I> {
    public partial class Then<T> {
    public partial class Else : IIfAble<Else.Then<I>, I>
    {
        internal Else(ConditionalMap<I, T> conditionalMap) =>
            ConditionalMap = conditionalMap;

        internal ConditionalMap<I, T> ConditionalMap { get; }

        public ˣ<Else.Then<I>, ˣIf<I>> If(Func<I, bool> condition) =>
            this.Then(Identity).If(condition);

        public ˣ<Else.Then<I>, Is<Iʹ>> If<Iʹ>(Func<TypeCondition<I, Iʹ>> condition)
            where Iʹ : I =>
                this.Then(Identity).If(condition);
    }}}

    public static partial class Syntax
    {
        public static ˣIf<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this ˣIf<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new(o.ConditionalMap, elseMap);
    }
}
