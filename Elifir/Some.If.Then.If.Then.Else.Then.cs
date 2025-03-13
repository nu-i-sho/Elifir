namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣIf<I>.Then<Tʹ>> End<Some, I, T, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣIf<I>.Then<T>>, ˣIf<T>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Eʹ : Tʹ =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣIf<I>.Then<Eʹ>> End<Some, I, T, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣIf<I>.Then<T>>, ˣIf<T>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣIf<I>.Then<B>> End<Some, I, T, Tʹ, Eʹ, B>(
            this ˣ<ˣ<Some, ˣIf<I>.Then<T>>, ˣIf<T>.Then<Tʹ>.Else.Then<Eʹ>> o,
            Func<ReturnType<B>> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End(withReturnB)));
    }
}