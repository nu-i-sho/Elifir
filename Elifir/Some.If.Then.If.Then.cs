namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> End<Some, I, T, Tʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>> o)
                where T : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<T>> End<Some, I, T, Tʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where Tʹ : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, T, Tʹ, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>> o,
            WithReturnType<B> withReturnTypeB)
                where T  : B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
