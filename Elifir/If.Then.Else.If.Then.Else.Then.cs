namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T>.Else.Then<Tʹ> End<I, T, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Then<T>.Else, ˣ.If<I>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Eʹ : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<T>.Else.Then<Eʹ> End<I, T, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Then<T>.Else, ˣ.If<I>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<T>.Else.Then<B> End<I, T, Tʹ, Eʹ, B>(
            this ˣ<ˣ.If<I>.Then<T>.Else, ˣ.If<I>.Then<Tʹ>.Else.Then<Eʹ>> o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
