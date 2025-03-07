namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                x => map(o(x));

        public static ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>> If<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new(o, If(condition));

        public static ˣ<Func<T, Tʹ>, ˣ.If<Tʹ>.Is<Tʺ>> If<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<TypeCondition<Tʹ, Tʺ>> condition)
                where Tʺ : Tʹ =>
                    new(o, If(condition));
    }
}
