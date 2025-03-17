namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<I> End<I, T>(
            this ˣ<ˣ.If<I>, ˣ.If<I>.Then<T>> o)
                where T : I =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<T> End<I, T>(
            this ˣ<ˣ.If<I>, ˣ.If<I>.Then<T>> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<B> End<I, T, B>(
            this ˣ<ˣ.If<I>, ˣ.If<I>.Then<T>> o,
            Func<ReturnType<B>> withReturnTypeB)
                where T : B
                where I : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
