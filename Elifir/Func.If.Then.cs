namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʹ> End<T, Tʹ, Tʺ>(
            this ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Then<Tʺ>> o)
                where Tʺ : Tʹ =>
                    o.Prev.Then(tʹ => o.Next.ConditionalMap(tʹ, out Tʺ? tʺ) ? tʺ : tʹ);

        public static Func<T, Tʺ> End<T, Tʹ, Tʺ>(
            this ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Then<Tʺ>> o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Tʺ =>
                    o.Prev.Then(tʹ => o.Next.ConditionalMap(tʹ, out Tʺ? tʺ) ? tʺ : tʹ);

        public static Func<T, B> End<T, Tʹ, Tʺ, B>(
            this ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Then<Tʺ>> o,
            Func<ReturnType<B>> _)
                where Tʹ : B
                where Tʺ : B =>
                    o.Prev.Then(tʹ => o.Next.ConditionalMap(tʹ, out Tʺ? tʺ) ? (B)tʺ : tʹ);
    }
}
