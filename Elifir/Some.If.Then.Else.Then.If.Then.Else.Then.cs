namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<Tʹ>> End<Some, I, T, E, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Eʹ : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<Eʹ>> End<Some, I, T, E, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<B>> End<Some, I, T, E, Tʹ, Eʹ, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Then<Tʹ>.Else.Then<Eʹ>> o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}