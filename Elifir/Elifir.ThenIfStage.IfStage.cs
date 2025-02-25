namespace Nuisho
{
    public static partial class Elifir
    {
        public static ThenIfStage<IfStage<T, Tʹ>, TParent> And<T, Tʹ, TParent>(
            this ThenIfStage<IfStage<T, Tʹ>, TParent> o,
            Func<Tʹ, bool> condition) =>
                new(o.Child.And(condition),
                    o.Parent);

        public static ThenIfStage<IfStage<T, Tʺ>, TParent> And<T, Tʹ, Tʺ, TParent>(
            this ThenIfStage<IfStage<T, Tʹ>, TParent> o,
            ConditionalMap<Tʹ, Tʺ> conditionalMap) 
                where Tʺ : Tʹ =>
                    new(o.Child.And(conditionalMap),
                        o.Parent);

        public static ThenIfStage<IfThenStage<T, Tʺ>, TParent> Then<T, Tʹ, Tʺ, TParent>(
            this ThenIfStage<IfStage<T, Tʹ>, TParent> o,
            Func<Tʹ, Tʺ> map) =>
                new(o.Child.Then(map),
                    o.Parent);
    }
}
