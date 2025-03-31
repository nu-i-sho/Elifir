namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T>.Else.Then<E> End<I, T, E, Tʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o)
                where Tʹ : E =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<Tʹ> End<I, T, E, Tʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, E, Tʹ, B>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where E  : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
