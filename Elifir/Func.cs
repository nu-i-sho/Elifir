namespace Nuisho
{
    public static partial class Elifir
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                x => map(o(x));

        public static ˣ<Func<T, Tʹ>>.Then<ˣ.If<Tʹ>> ThenIf<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new(o, If(condition));

        public static ˣ<Func<T, Tʹ>>.Then<ˣ.If<Tʹ>.Is<Tʺ>> ThenIf<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            ConditionalMap<Tʹ, Tʺ> condition)
                where Tʺ : Tʹ =>
                    new(o, If(condition));
    }
}
