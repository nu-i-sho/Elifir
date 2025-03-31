namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<Iʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I, Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
