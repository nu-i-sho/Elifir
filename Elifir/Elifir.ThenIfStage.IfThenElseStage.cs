namespace Nuisho
{
    public static partial class Elifir
    {
        public static ThenIfStage<IfThenElseStage<T, Tʹ, Eʺ>, TParent> Then<T, Tʹ, Eʹ, Eʺ, TParent>(
            this ThenIfStage<IfThenElseStage<T, Tʹ, Eʹ>, TParent> o,
            Func<Eʹ, Eʺ> map) =>
                new(o.Child.Then(map),
                    o.Parent);

        public static ThenIfStage<IfStage<Eʹ, Eʹ>, ThenIfStage<IfThenElseStage<T, Tʹ, Eʹ>, TParent>> ThenIf<T, Tʹ, Eʹ, TParent>(
            this ThenIfStage<IfThenElseStage<T, Tʹ, Eʹ>, TParent> o,
            Func<Eʹ, bool> condition) =>
                new(If(condition),
                    o);

        public static ThenIfStage<IfStage<Eʹ, Eʺ>, ThenIfStage<IfThenElseStage<T, Tʹ, Eʹ>, TParent>> ThenIf<T, Tʹ, Eʹ, Eʺ, TParent>(
            this ThenIfStage<IfThenElseStage<T, Tʹ, Eʹ>, TParent> o,
            ConditionalMap<Eʹ, Eʺ> conditionalMap)
                where Eʺ : Eʹ =>
                    new(If(conditionalMap),
                        o);
    }
}
