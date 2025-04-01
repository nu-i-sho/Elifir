namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) AndIf<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            Func<Iʹ, bool> condition) 
                where Iʹ : I =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Is<Iʺ>) AndIf<ꞏꞏꞏ, I, Iʹ, Iʺ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            IsOfType<Iʺ> condition)
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) Then<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            Func<Iʹ, Tʹ> map)
                where Iʹ : I =>
                    (o.Item1, o.Item2.Then(map));
    }
}
