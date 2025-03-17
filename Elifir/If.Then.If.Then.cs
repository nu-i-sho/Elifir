namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T> End<I, T, Tʹ>(
            this ˣ<ˣ.If<I>.Then<T>, ˣ.If<T>.Then<Tʹ>> o)
                where Tʹ : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<Tʹ> End<I, T, Tʹ>(
            this ˣ<ˣ.If<I>.Then<T>, ˣ.If<T>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where T : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<B> End<I, T, Tʹ, B>(
            this ˣ<ˣ.If<I>.Then<T>, ˣ.If<T>.Then<Tʹ>> o,
            Func<ReturnType<B>> withReturnTypeB)
                where T  : B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
