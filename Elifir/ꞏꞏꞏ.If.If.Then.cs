namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<I>) End<ꞏꞏꞏ, I, T>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o)
                where T : I =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, B>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where T : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
