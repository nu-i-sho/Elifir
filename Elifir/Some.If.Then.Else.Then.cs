namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<Eʹ>> Then<Some, I, T, E, Eʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            Func<E, Eʹ> map) =>
                new(o.Prev,
                    o.Next.Then(map));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>> If<Some, I, T, E>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            Func<E, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Is<Eʹ>> If<Some, I, T, E, Eʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            ConditionalMap<E, Eʹ> condition)
                where Eʹ : E =>
                    new(o, If(condition));
    }
}