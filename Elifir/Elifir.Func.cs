namespace Nuisho
{
    public static partial class Elifir
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                x => map(o(x));

        public static ThenIfStage<IfStage<Tʹ, Tʹ>, Func<T, Tʹ>> ThenIf<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new(If(condition),
                    o);

        public static ThenIfStage<IfStage<Tʹ, Tʺ>, Func<T, Tʹ>> ThenIf<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            ConditionalMap<Tʹ, Tʺ> condition)
                where Tʺ : Tʹ =>
                    new(If(condition),
                        o);
    }
}
