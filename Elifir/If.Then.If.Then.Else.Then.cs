namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<Tʹ> End<I, T, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Eʹ> End<I, T, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, Tʹ, Eʹ, B>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
