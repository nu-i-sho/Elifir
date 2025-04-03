namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static İf<I>.Then<T>.Else Else<I, T>(
            this İf<I>.Then<T> o) =>
                new (o.ConditionalMap);

        public static (ꞏꞏꞏ, İf<I>.Then<T>.Else) Else<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, İf<I>.Then<T>) o) =>
                (o.Item1, o.Item2.Else());
    }
}
