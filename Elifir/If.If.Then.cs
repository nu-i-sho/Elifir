namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<I> End<I, T>(
            this (Іf<I>, Іf<I>.Then<T>) o)
                where T : I =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T> End<I, T>(
            this (Іf<I>, Іf<I>.Then<T>) o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, B>(
            this (Іf<I>, Іf<I>.Then<T>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where I : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
