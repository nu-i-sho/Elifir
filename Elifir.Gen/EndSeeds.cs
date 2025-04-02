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
                   _1_3_TypeTemplate: Func(T, X),
                             _2_Type: If(Tʹ).Then(Tʺ),
                              Params: new([T], Tʹ, Tʺ, Tʹ),
                NestedImplementation: false);

            yield return new EndSeed(
                   _1_3_TypeTemplate: Func(T, X),
                             _2_Type: If(Tʹ).Then(Tʺ).Else.Then(Eʺ),
                              Params: new([T], Tʹ, Tʺ, Eʺ),
                NestedImplementation: false);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I),
                             _2_Type: If(I).Then(T),
                              Params: new([], I, T, I),
                             AddThen: true);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I),
                             _2_Type: If(I).Then(T).Else.Then(E),
                              Params: new([], I, T, E),
                             AddThen: true);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Is(X),
                             _2_Type: If(Iʹ).Then(Tʹ),
                              Params: new([I], Iʹ, Tʹ, Iʹ),
                         Constraints: [(Iʹ, I)],
                            RemoveIs: true,
                             AddThen: true);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Is(X),
                             _2_Type: If(Iʹ).Then(Tʹ).Else.Then(Eʹ),
                              Params: new([I], Iʹ, Tʹ, Eʹ),
                         Constraints: [(Iʹ, I)],
                            RemoveIs: true,
                             AddThen: true);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Then(X),
                             _2_Type: If(T).Then(Tʹ),
                              Params: new([I], T, Tʹ, T));

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Then(X),
                             _2_Type: If(T).Then(Tʹ).Else.Then(Eʹ),
                              Params: new([I], T, Tʹ, Eʹ));

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Then(T).Else,
                             _2_Type: If(I).Then(Tʹ),
                              Params: new([T], I, Tʹ, I),
                             AddThen: true);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Then(T).Else,
                             _2_Type: If(I).Then(Tʹ).Else.Then(Eʹ),
                              Params: new([I, T], I, Tʹ, Eʹ),
                             AddThen: true);

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Then(T).Else.Then(X),
                             _2_Type: If(E).Then(Tʹ),
                              Params: new([I, T], E, Tʹ, E));

            yield return new EndSeed(
                   _1_3_TypeTemplate: If(I).Then(T).Else.Then(X),
                             _2_Type: If(E).Then(Tʹ).Else.Then(Eʹ),
                              Params: new([I, T], E, Tʹ, Eʹ));
        }

        public static EndSeeds Default => new(GetDefault());
    }
}
