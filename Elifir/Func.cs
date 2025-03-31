namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                x => map(o(x));

        public static (Func<T, Tʹ>, Іf<Tʹ>) If<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                (o, If(condition));

        public static (Func<T, Tʹ>, Іf<Tʹ>.Is<Tʺ>) If<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            IsOfType<Tʺ> condition)
                where Tʺ : Tʹ =>
                    (o, new());
    }
}
