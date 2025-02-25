namespace Nuisho
{
    public static partial class Elifir
    {
        public static ˣ<Some>.Then<ˣ.If<I>.Then<Tʹ>> Then<Some, I, T, Tʹ>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>> o,
            Func<T, Tʹ> map) =>
                new(o.Prev, o.Next.Then(map));

        public static ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>>>.Then<ˣ.If<T>> ThenIf<Some, I, T>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>> o,
            Func<T, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>>>.Then<ˣ.If<T>.Is<Tʹ>> ThenIf<Some, I, T, Tʹ>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>> o,
            ConditionalMap<T, Tʹ> condition)
                where Tʹ : T =>
                    new(o, If(condition));

        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>> Else<Some, I, T, E>(
            this ˣ<Some>.Then<ˣ.If<I>.Then<T>> o,
            Func<I, E> map) =>
                new(o.Prev, o.Next.Else(map));
    }
}
