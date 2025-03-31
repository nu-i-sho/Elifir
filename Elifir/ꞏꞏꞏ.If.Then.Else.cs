namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) Then<ꞏꞏꞏ, I, T, E>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else) o,
            Func<I, E> map) =>
                (o.Item1, o.Item2.Then(map));

        public static ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>) If<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else) o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Is<E>) If<ꞏꞏꞏ, I, T, E>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else) o,
            IsOfType<E> condition)
                where E : I =>
                    (o, new());
    }
}
