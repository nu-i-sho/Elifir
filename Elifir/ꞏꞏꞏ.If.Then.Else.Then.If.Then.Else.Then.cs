namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Eʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, Tʹ, Eʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}