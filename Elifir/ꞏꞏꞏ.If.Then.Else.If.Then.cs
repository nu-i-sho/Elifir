namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<I>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<E>) o)
                where E : I =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where I : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}