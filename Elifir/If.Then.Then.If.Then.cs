namespace Nuisho
{
    public static partial class Elifir
    {
        public static ˣ.If<I>.Then<T> End<I, T, Tʹ>(
            this ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>> o)
                where Tʹ : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<Tʹ> End<I, T, Tʹ>(
            this ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>> o,
            AdHocPolyMarker _ = default)
                where T : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<B> End<I, T, Tʹ, B>(
            this ˣ<ˣ.If<I>.Then<T>>.Then<ˣ.If<T>.Then<Tʹ>> o,
            ReturnType<B> withReturnB)
                where T  : B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}
