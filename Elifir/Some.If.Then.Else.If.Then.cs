namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<I>> End<Some, I, T, E>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else>, ˣ.If<I>.Then<E>> o)
                where E : I =>
                    new(o.Prev.Prev,
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> End<Some, I, T, E>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else>, ˣ.If<I>.Then<E>> o,
            AdHocPolyMarker? _ = null)
                where I : E =>
                    new(o.Prev.Prev,
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<B>> End<Some, I, T, E, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else>, ˣ.If<I>.Then<E>> o,
            Func<ReturnType<B>> withReturnTypeB)
                where I : B
                where E : B =>
                    new(o.Prev.Prev,
                        o.Prev.Next.Then(
                             o.Next.End(withReturnTypeB)));
    }
}