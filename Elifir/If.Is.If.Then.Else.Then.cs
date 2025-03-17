namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<Tʹ> End<I, Iʹ, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Iʹ : I
                where Eʹ : Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<Eʹ> End<I, Iʹ, Tʹ, Eʹ>(
            this ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Eʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<B> End<I, Iʹ, Tʹ, Eʹ, B>(
            this ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>> o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I
                where Tʹ : B
                where Eʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
