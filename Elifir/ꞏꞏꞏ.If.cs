namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>) AndIf<ꞏꞏꞏ, I>(
            this (ꞏꞏꞏ, Іf<I>) o,
            Func<I, bool> condition) =>
                (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) AndIf<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) Then<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ , Іf<I>) o,
            Func<I, T> map) =>
                (o.Item1, o.Item2.Then(map));
    }
}
