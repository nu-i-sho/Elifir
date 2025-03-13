namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣIf<I>.Then<T> End<I, T, Tʹ>(
            this ˣ<ˣIf<I>.Then<T>, ˣIf<T>.Then<Tʹ>> o)
                where Tʹ : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣIf<I>.Then<Tʹ> End<I, T, Tʹ>(
            this ˣ<ˣIf<I>.Then<T>, ˣIf<T>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where T : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣIf<I>.Then<B> End<I, T, Tʹ, B>(
            this ˣ<ˣIf<I>.Then<T>, ˣIf<T>.Then<Tʹ>> o,
            Func<ReturnType<B>> withReturnB)
                where T  : B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}
