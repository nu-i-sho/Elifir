namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>> End<Some, I, T, E, Tʹ>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>>> o)
                where Tʹ : E =>
                    new(o.Prev, o.Next.End());

        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<Tʹ>> End<Some, I, T, E, Tʹ>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>>> o,
            AdHocPolyMarker _ = default)
                where E : Tʹ =>
                    new(o.Prev, o.Next.End());

        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<B>> End<Some, I, T, E, Tʹ, B>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>>> o,
            ReturnType<B> withReturnB)
                where E  : B
                where Tʹ : B =>
                    new(o.Prev, o.Next.End(withReturnB));
    }
}
