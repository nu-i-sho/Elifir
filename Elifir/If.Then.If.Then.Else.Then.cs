namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣIf<I>.Then<Tʹ> End<I, T, Tʹ, Eʹ>(
            this ˣ<ˣIf<I>.Then<T>, ˣIf<T>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Eʹ : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣIf<I>.Then<Eʹ> End<I, T, Tʹ, Eʹ>(
            this ˣ<ˣIf<I>.Then<T>, ˣIf<T>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣIf<I>.Then<B> End<I, T, Tʹ, Eʹ, B>(
            this ˣ<ˣIf<I>.Then<T>, ˣIf<T>.Then<Tʹ>.Else.Then<Eʹ>> o,
            Func<ReturnType<B>> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}
