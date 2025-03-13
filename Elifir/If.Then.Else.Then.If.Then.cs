namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣIf<I>.Then<T>.Else.Then<E> End<I, T, E, Tʹ>(
            this ˣ<ˣIf<I>.Then<T>.Else.Then<E>, ˣIf<E>.Then<Tʹ>> o)
                where Tʹ : E =>
                    o.Prev.Then(o.Next.End());

        public static ˣIf<I>.Then<T>.Else.Then<Tʹ> End<I, T, E, Tʹ>(
            this ˣ<ˣIf<I>.Then<T>.Else.Then<E>, ˣIf<E>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣIf<I>.Then<T>.Else.Then<B> End<I, T, E, Tʹ, B>(
            this ˣ<ˣIf<I>.Then<T>.Else.Then<E>, ˣIf<E>.Then<Tʹ>> o,
            Func<ReturnType<B>> withReturnB)
                where E  : B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}
