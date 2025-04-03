namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using static Utils;

    internal sealed record IfSeed(
        string Type,
        IfSeed.GenericParams Params,
        IImmutableList<(string, string)>? Constraints = null,
        bool NestedImplementation = true)
    {
        internal sealed record GenericParams(
            IImmutableList<string> Free, string If, string Next)
        {
            internal string ShortLine => string.Join(", ",
                Free.Concat([If])
                    .Order(ParamComparer.Instance));

            internal string LongLine => string.Join(", ",
                Free.Concat([If, Next])
                    .Order(ParamComparer.Instance));
        }

        internal Wheres Wheres { get; } = new (Constraints ?? []);
    }
}
