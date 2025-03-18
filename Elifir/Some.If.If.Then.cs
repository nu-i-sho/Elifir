namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<I>> End<Some, I, T>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>> o)
                where T : I =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<T>> End<Some, I, T>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, T, B>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>> o,
            WithReturnType<B> withReturnTypeB)
                where I  : B
                where T : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
