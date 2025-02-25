namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct IfThenStage<T, Tʹ>(
            ConditionalMap<T, Tʹ> ConditionalMap);

        public static IfThenStage<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this IfThenStage<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                new((T x, out Tʺ xʺ) =>
                {
                    if (o.ConditionalMap(x, out Tʹ xʹ))
                    {
                        xʺ = map(xʹ);
                        return true;
                    }

                    xʺ = default;
                    return false;
                });

        public static ThenIfStage<IfStage<Tʹ, Tʹ>, IfThenStage<T, Tʹ>> ThenIf<T, Tʹ>(
            this IfThenStage<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new(If(condition),
                    o);

        public static ThenIfStage<IfStage<Tʹ, Tʺ>, IfThenStage<T, Tʹ>> ThenIf<T, Tʹ, Tʺ>(
            this IfThenStage<T, Tʹ> o,
            ConditionalMap<Tʹ, Tʺ> conditionalMap)
                where Tʺ : Tʹ =>
                    new(If(conditionalMap),
                        o);

        public static IfThenElseStage<T, Tʹ, Eʹ> Else<T, Tʹ, Eʹ>(
            this IfThenStage<T, Tʹ> o,
            Func<T, Eʹ> map) =>
                new(o.ConditionalMap, 
                    map);
    }
}
