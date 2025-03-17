namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> End<Some, I, Iʹ, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Is<Iʹ>>, ˣ.If<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Iʹ : I
                where Eʹ : Tʹ =>
                    new(o.Prev.Prev,
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<Eʹ>> End<Some, I, Iʹ, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Is<Iʹ>>, ˣ.If<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Eʹ =>
                    new(o.Prev.Prev,
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, Iʹ, Tʹ, Eʹ, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Is<Iʹ>>, ˣ.If<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>> o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I
                where Tʹ : B
                where Eʹ : B =>
                    new(o.Prev.Prev,
                        o.Prev.Next.Then(
                             o.Next.End(withReturnTypeB)));
    }
}
