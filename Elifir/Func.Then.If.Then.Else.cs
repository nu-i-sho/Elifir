namespace Nuisho
{
    public static partial class Elifir
    {
        public static Func<T, Tʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this ˣ<Func<T, Tʹ>>.Then<ˣ.If<Tʹ>.Then<Tʺ>.Else<Eʺ>> o)
                where Eʺ : Tʺ =>
                    o.Prev.Then(o.Next.End());

        public static Func<T, Eʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this ˣ<Func<T, Tʹ>>.Then<ˣ.If<Tʹ>.Then<Tʺ>.Else<Eʺ>> o,
            AdHocPolyMarker _ = default)
                where Tʺ : Eʺ =>
                    o.Prev.Then(o.Next.End());

        public static Func<T, B> End<T, Tʹ, Tʺ, Eʺ, B>(
            this ˣ<Func<T, Tʹ>>.Then<ˣ.If<Tʹ>.Then<Tʺ>.Else<Eʺ>> o,
            ReturnType<B> withReturnB)
                where Tʺ : B
                where Eʺ : B =>
                    o.Prev.Then(o.Next.End(withReturnB));
    }
}
