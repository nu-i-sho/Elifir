namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, T, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>) o)
                where T : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where T  : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
