namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T>.Else<Tʹ> End<I, T, E, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>.Else<Eʹ>> o)
                where Eʹ : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<T>.Else<Eʹ> End<I, T, E, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>.Else<Eʹ>> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<T>.Else<B> End<I, T, E, Tʹ, Eʹ, B>(
            this ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>.Else<Eʹ>> o,
            ReturnType<B> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}