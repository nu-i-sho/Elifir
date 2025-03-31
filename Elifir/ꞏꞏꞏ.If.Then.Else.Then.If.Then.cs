namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) End<ꞏꞏꞏ, I, T, E, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o)
                where Tʹ : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where E : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
