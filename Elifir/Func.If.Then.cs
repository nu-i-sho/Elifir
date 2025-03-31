namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʹ> End<T, Tʹ, Tʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>) o)
                where Tʺ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, Tʺ> End<T, Tʹ, Tʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Tʺ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, B> End<T, Tʹ, Tʺ, B>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Tʺ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
