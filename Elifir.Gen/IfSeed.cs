namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using static Nuisho.Elifir.Gen.Utils;

    public record IfSeed(
        string Type,
        IfSeed.GenericParams Params,
        IImmutableList<(string, string)>? Constraints = null,
        bool NestedImplementation = true)
    {
        public record GenericParams(
            IImmutableQueue<string> Free, string If, string Next)
        {
            public string ShortLine => string.Join(", ",
                Free.Concat([If])
                    .Distinct());

            public string LongLine => string.Join(", ",
                Free.Concat([If, Next])
                    .Distinct());
        }

        public Wheres Wheres { get; } = new(Constraints ?? []);
    }
}
