namespace Nuisho.Elifir.Gen
{
    using System.Collections;
    using static Utils;

    internal sealed class IfSeeds(IEnumerable<IfSeed> implementation)
        : IEnumerable<IfSeed>
    {
        public IEnumerator<IfSeed> GetEnumerator() =>
            implementation.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            implementation.GetEnumerator();

        static IEnumerable<IfSeed> GetDefault()
        {
            yield return new IfSeed(
                                Type: Func(T, Tʹ),
                              Params: new ([T], Tʹ, Tʺ),
                NestedImplementation: false);

            yield return new IfSeed(
                                Type: If(I),
                              Params: new ([], I, Iʹ));

            yield return new IfSeed(
                                Type: If(I).Is(Iʹ),
                              Params: new ([I], Iʹ, Iʺ),
                         Constraints: [(Iʹ, I)]);

            yield return new IfSeed(
                                Type: If(I).Then(T),
                              Params: new ([I], T, Tʹ));

            yield return new IfSeed(
                                Type: If(I).Then(T).Else,
                              Params: new ([T], I, Iʹ));

            yield return new IfSeed(
                                Type: If(I).Then(T).Else.Then(E),
                              Params: new ([I, T], E, Eʹ));
        }

        public static IfSeeds Default => new (GetDefault());
    }
}
