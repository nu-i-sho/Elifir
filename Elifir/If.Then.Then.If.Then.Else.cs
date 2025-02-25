namespace Nuisho
{
    public static partial class Elifir
    {
        public static ˣ.If<I>.Then<Tʹ> End<I, T, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>.Else<Eʹ>> o)
                where Eʹ : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<Eʹ> End<I, T, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>.Else<Eʹ>> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<B> End<I, T, Tʹ, Eʹ, B>(
            this ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>.Else<Eʹ>> o,
            ReturnType<B> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}
