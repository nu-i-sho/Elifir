namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Iʹ : I
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<Eʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, Eʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
