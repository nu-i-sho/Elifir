namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Eʹ>) Then<ꞏꞏꞏ, I, T, E, Eʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) o,
            Func<E, Eʹ> map) =>
                (o.Item1, o.Item2.Then(map));
    }
}