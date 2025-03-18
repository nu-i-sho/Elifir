namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>> End<Some, I, T, E>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>.Else.Then<E>> o)
                where E : T =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<E>> End<Some, I, T, E>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, T, E, B>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where E : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}