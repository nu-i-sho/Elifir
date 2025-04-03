namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using static Utils;

    public record IfSeed(
        string Type,
        IfSeed.GenericParams Params,
        IImmutableList<(string, string)>? Constraints = null,
        bool NestedImplementation = true)
    {
        public record GenericParams(
            IImmutableList<string> Free, string If, string Next)
        {
            public string ShortLine => string.Join(", ",
                Free.Concat([If])
                    .Order(ParamComparer.Instance));

            public string LongLine => string.Join(", ",
                Free.Concat([If, Next])
                    .Order(ParamComparer.Instance));
        }

        public Wheres Wheres { get; } = new (Constraints ?? []);
    }
}
