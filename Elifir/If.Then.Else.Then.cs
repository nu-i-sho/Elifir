namespace Nuisho.Elifir
{
    public partial class ˣIf<I> {
    public partial class Then<T> {
    public partial class Else {
    public partial class Then<E> : IIfAble<Then<E>, E>
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

        public ˣ<Then<E>, ˣIf<E>> If(Func<E, bool> condition) =>
            new(this, Syntax.If(condition));

        public ˣ<Then<E>, ˣIf<E>.Is<Eʹ>> If<Eʹ>(Func<TypeCondition<E, Eʹ>> condition)
            where Eʹ : E =>
                new(this, Syntax.If(condition));
    }}}}
    
    public static partial class Syntax
    {
        public static ˣIf<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this ˣIf<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalMap,
                    o.ElseMap.Then(map));

        public static Func<I, T> End<I, T, E>(
            this ˣIf<I>.Then<T>.Else.Then<E> o)
                where E : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, E> End<I, T, E>(
            this ˣIf<I>.Then<T>.Else.Then<E> o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, B> End<I, T, E, B>(
            this ˣIf<I>.Then<T>.Else.Then<E> o,
            Func<ReturnType<B>> _)
                where T : B
                where E : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : o.ElseMap(i);
    }
}
