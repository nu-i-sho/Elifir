namespace Nuisho.Elifir.Gen
{
    using System.Collections;
    using static Utils;

    public class EndSeeds(IEnumerable<EndSeed> implementation)
        : IEnumerable<EndSeed>
    {
        public IEnumerator<EndSeed> GetEnumerator() =>
            implementation.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            implementation.GetEnumerator();

        static IEnumerable<EndSeed> GetDefault()
        {
            yield return new EndSeed(
            FirstAndThirdTypeTemplate: Func(T, X),
                           SecondType: If(Tʹ).Then(Tʺ),
                               Params: new ([T], Tʹ, Tʺ, Tʹ),
                 NestedImplementation: false);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: Func(T, X),
                           SecondType: If(Tʹ).Then(Tʺ).Else.Then(Eʺ),
                               Params: new ([T], Tʹ, Tʺ, Eʺ),
                 NestedImplementation: false);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I),
                           SecondType: If(I).Then(T),
                               Params: new ([], I, T, I),
                              AddThen: true);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I),
                           SecondType: If(I).Then(T).Else.Then(E),
                               Params: new ([], I, T, E),
                              AddThen: true);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Is(X),
                           SecondType: If(Iʹ).Then(Tʹ),
                               Params: new ([I], Iʹ, Tʹ, Iʹ),
                          Constraints: [(Iʹ, I)],
                             RemoveIs: true,
                              AddThen: true);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Is(X),
                           SecondType: If(Iʹ).Then(Tʹ).Else.Then(Eʹ),
                               Params: new ([I], Iʹ, Tʹ, Eʹ),
                          Constraints: [(Iʹ, I)],
                             RemoveIs: true,
                              AddThen: true);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Then(X),
                           SecondType: If(T).Then(Tʹ),
                               Params: new ([I], T, Tʹ, T));

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Then(X),
                           SecondType: If(T).Then(Tʹ).Else.Then(Eʹ),
                               Params: new ([I], T, Tʹ, Eʹ));

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Then(T).Else,
                           SecondType: If(I).Then(Tʹ),
                               Params: new ([T], I, Tʹ, I),
                              AddThen: true);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Then(T).Else,
                           SecondType: If(I).Then(Tʹ).Else.Then(Eʹ),
                               Params: new ([I, T], I, Tʹ, Eʹ),
                              AddThen: true);

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Then(T).Else.Then(X),
                           SecondType: If(E).Then(Tʹ),
                               Params: new ([I, T], E, Tʹ, E));

            yield return new EndSeed(
            FirstAndThirdTypeTemplate: If(I).Then(T).Else.Then(X),
                           SecondType: If(E).Then(Tʹ).Else.Then(Eʹ),
                               Params: new ([I, T], E, Tʹ, Eʹ));
        }

        public static EndSeeds Default => new (GetDefault());
    }
}
