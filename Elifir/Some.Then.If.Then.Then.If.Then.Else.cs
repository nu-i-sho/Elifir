namespace Nuisho
{
    public static partial class Elifir
    {
        public static ˣ<Some>.Then<ˣ.If<I>.Then<Tʹ>> End<Some, I, T, Tʹ, Eʹ>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>.Else<Eʹ>>> o)
                where Eʹ : Tʹ =>
                    new(o.Prev, o.Next.End());

        public static ˣ<Some>.Then<ˣ.If<I>.Then<Eʹ>> End<Some, I, T, Tʹ, Eʹ>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>.Else<Eʹ>>> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    new(o.Prev, o.Next.End());

        public static ˣ<Some>.Then<ˣ.If<I>.Then<B>> End<Some, I, T, Tʹ, Eʹ, B>(
            this ˣ<Some>.Then<ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>.Else<Eʹ>>> o,
            ReturnType<B> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    new(o.Prev, o.Next.End(withReturnB));
    }
}