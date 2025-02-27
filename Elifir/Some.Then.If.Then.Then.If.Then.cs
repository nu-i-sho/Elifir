namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>> End<Some, I, T, Tʹ>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>>> o)
                where Tʹ : T =>
                    new(o.Prev, o.Next.End());

        public static ˣ<Some>.Then<ˣ.If<I>.Then<Tʹ>> End<Some, I, T, Tʹ>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>>> o,
            AdHocPolyMarker _ = default)
                where T : Tʹ =>
                    new(o.Prev, o.Next.End());

        public static ˣ<Some>.Then<ˣ.If<I>.Then<B>> End<Some, I, T, Tʹ, B>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>>> o,
            ReturnType<B> withReturnB)
                where T  : B
                where Tʹ : B =>
                    new(o.Prev, o.Next.End(withReturnB));
    }
}
