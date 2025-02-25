namespace Nuisho
{
    public static partial class Elifir
    {
        public static ThenIfStage<IfThenStage<T, Tʺ>, TParent> Then<T, Tʹ, Tʺ, TParent>(
            this ThenIfStage<IfThenStage<T, Tʹ>, TParent> o,
            Func<Tʹ, Tʺ> map) =>
                new(o.Child.Then(map),
                    o.Parent);

        public static ThenIfStage<IfThenElseStage<T, Tʹ, Eʹ>, TParent> Else<T, Tʹ, Eʹ, TParent>(
            this ThenIfStage<IfThenStage<T, Tʹ>, TParent> o,
            Func<T, Eʹ> map) =>
                new(o.Child.Else(map),
                    o.Parent);

        public static ThenIfStage<IfStage<Tʹ, Tʹ>, ThenIfStage<IfThenStage<T, Tʹ>, TParent>> ThenIf<T, Tʹ, TParent>(
            this ThenIfStage<IfThenStage<T, Tʹ>, TParent> o,
            Func<Tʹ, bool> condition) =>
                new(If(condition),
                    o);

        public static ThenIfStage<IfStage<Tʹ, Tʺ>, ThenIfStage<IfThenStage<T, Tʹ>, TParent>> ThenIf<T, Tʹ, Tʺ, TParent>(
            this ThenIfStage<IfThenStage<T, Tʹ>, TParent> o,
            ConditionalMap<Tʹ, Tʺ> conditionalMap)
                where Tʺ : Tʹ =>
                    new(If(conditionalMap),
                        o);
    }
}
