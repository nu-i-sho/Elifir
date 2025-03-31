namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>.Else.Then<E>) o)
                where E : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<E>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>.Else.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, E, B>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>.Else.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}