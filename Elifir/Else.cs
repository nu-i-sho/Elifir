namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T>.Else Else<I, T>(
            this Іf<I>.Then<T> o) =>
                new (o.ConditionalMap);

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else) Else<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o) =>
                (o.Item1, o.Item2.Else());
    }
}
