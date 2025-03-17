namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>> o)
                where Eʺ : Tʺ =>
                    o.Prev.Then(tʹ => o.Next.ConditionalMap(tʹ, out Tʺ? tʺ) ? tʺ : o.Next.ElseMap(tʹ));

        public static Func<T, Eʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>> o,
            AdHocPolyMarker? _ = null)
                where Tʺ : Eʺ =>
                    o.Prev.Then(tʹ => o.Next.ConditionalMap(tʹ, out Tʺ? tʺ) ? tʺ : o.Next.ElseMap(tʹ));

        public static Func<T, B> End<T, Tʹ, Tʺ, Eʺ, B>(
            this ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>> o,
            Func<ReturnType<B>> withReturnB)
                where Tʺ : B
                where Eʺ : B =>
                    o.Prev.Then(tʹ => o.Next.ConditionalMap(tʹ, out Tʺ? tʺ) ? (B)tʺ : o.Next.ElseMap(tʹ));
    }
}
