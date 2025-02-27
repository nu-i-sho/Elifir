namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<Eʹ>> Then<Some, I, T, E, Eʹ>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>> o,
            Func<E, Eʹ> map) =>
                new(o.Prev, o.Next.Then(map));

        public static ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>>>.Then<ˣ.If<E>> ThenIf<Some, I, T, E>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>> o,
            Func<E, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>>>.Then<ˣ.If<E>.Is<Eʹ>> ThenIf<Some, I, T, E, Eʹ>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>> o,
            ConditionalMap<E, Eʹ> condition)
                where Eʹ : E =>
                    new(o, If(condition));
    }
}
