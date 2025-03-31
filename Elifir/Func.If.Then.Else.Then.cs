namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>) o)
                where Eʺ : Tʺ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, Eʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>) o,
            AdHocPolyMarker? _ = null)
                where Tʺ : Eʺ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, B> End<T, Tʹ, Tʺ, Eʺ, B>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʺ : B
                where Eʺ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
