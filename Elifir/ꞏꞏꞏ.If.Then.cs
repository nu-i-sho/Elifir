namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else) Else<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o) =>
                (o.Item1, o.Item2.Else());
    }
}
