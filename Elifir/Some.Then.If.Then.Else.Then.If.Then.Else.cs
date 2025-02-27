namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<Tʹ>> End<Some, I, T, E, Tʹ, Eʹ>(
            this ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>>>.Then<ˣ.If<E>.Then<Tʹ>.Else<Eʹ>> o)
                where Eʹ : Tʹ =>
                    new(o.Prev.Prev, o.Prev.Next.Then(o.Next.End()));

        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<Eʹ>> End<Some, I, T, E, Tʹ, Eʹ>(
            this ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>>>.Then<ˣ.If<E>.Then<Tʹ>.Else<Eʹ>> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    new(o.Prev.Prev, o.Prev.Next.Then(o.Next.End()));

        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<B>> End<Some, I, T, E, Tʹ, Eʹ, B>(
            this ˣ<ˣ<Some>.Then<ˣ.If<I>.Then<T>.Else<E>>>.Then<ˣ.If<E>.Then<Tʹ>.Else<Eʹ>> o,
            ReturnType<B> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    new(o.Prev.Prev, o.Prev.Next.Then(o.Next.End(withReturnB)));
    }
}