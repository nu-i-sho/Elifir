namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o)
                where Tʹ : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Tʹ> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where T : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, Tʹ, B>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where T  : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
