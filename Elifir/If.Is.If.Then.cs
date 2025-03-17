namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<Iʹ> End<I, Iʹ, Tʹ>(
            this ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Then<Tʹ>> o)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<Tʹ> End<I, Iʹ, Tʹ>(
            this ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Then<Tʹ>> o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I, Tʹ =>
                    o.Prev.Then(o.Next.End());

        public static ˣ.If<I>.Then<B> End<I, Iʹ, Tʹ, B>(
            this ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Then<Tʹ>> o,
            Func<ReturnType<B>> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
                    o.Prev.Then(o.Next.End(withReturnTypeB));
    }
}
