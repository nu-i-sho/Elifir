namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct IfThenElseStage<T, Tʹ, Eʹ>(
            ConditionalMap<T, Tʹ> ConditionalMap,
            Func<T, Eʹ> ElseMap);

        public static IfThenElseStage<T, Tʹ, Eʺ> Then<T, Tʹ, Eʹ, Eʺ>(
            this IfThenElseStage<T, Tʹ, Eʹ> o,
            Func<Eʹ, Eʺ> map) =>
                new(o.ConditionalMap,
                    o.ElseMap.Then(map));

        public static ThenIfStage<IfStage<Eʹ, Eʹ>, IfThenElseStage<T, Tʹ, Eʹ>> ThenIf<T, Tʹ, Eʹ>(
            this IfThenElseStage<T, Tʹ, Eʹ> o,
            Func<Eʹ, bool> condition) =>
                new(If(condition),
                    o);

        public static ThenIfStage<IfStage<Eʹ, Eʺ>, IfThenElseStage<T, Tʹ, Eʹ>> ThenIf<T, Tʹ, Eʹ, Eʺ>(
            this IfThenElseStage<T, Tʹ, Eʹ> o,
            ConditionalMap<Eʹ, Eʺ> conditionalMap)
                where Eʺ : Eʹ =>
                    new(If(conditionalMap),
                        o);
    }
}
