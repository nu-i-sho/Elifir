namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) Then<ꞏꞏꞏ, I, T, Tʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o,
            Func<T, Tʹ> map) =>
                (o.Item1, o.Item2.Then(map));

        public static ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>) If<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o,
            Func<T, bool> condition) =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Is<Tʹ>) If<ꞏꞏꞏ, I, T, Tʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o,
            IsOfType<Tʹ> condition)
                where Tʹ : T =>
                    (o, new());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else) Else<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o) =>
                (o.Item1, o.Item2.Else());
    }
}
