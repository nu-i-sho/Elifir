namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣIf<I>.Then<T>.Else.Then<E>> End<Some, I, T, E, Tʹ>(
            this ˣ<ˣ<Some, ˣIf<I>.Then<T>.Else.Then<E>>, ˣIf<E>.Then<Tʹ>> o)
                where Tʹ : E =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣIf<I>.Then<T>.Else.Then<Tʹ>> End<Some, I, T, E, Tʹ>(
            this ˣ<ˣ<Some, ˣIf<I>.Then<T>.Else.Then<E>>, ˣIf<E>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣIf<I>.Then<T>.Else.Then<B>> End<Some, I, T, E, Tʹ, B>(
            this ˣ<ˣ<Some, ˣIf<I>.Then<T>.Else.Then<E>>, ˣIf<E>.Then<Tʹ>> o,
            Func<ReturnType<B>> withReturnB)
                where E : B
                where Tʹ : B =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End(withReturnB)));
    }
}
