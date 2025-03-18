namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> End<Some, I, T, E, Tʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Then<Tʹ>> o)
                where Tʹ : E =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<Tʹ>> End<Some, I, T, E, Tʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<B>> End<Some, I, T, E, Tʹ, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Then<Tʹ>> o,
            WithReturnType<B> withReturnTypeB)
                where E : B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
