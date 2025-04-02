namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using static Utils;

    public record EndSeed(
        string _1_TypeTemplate,
        string _2_Type,
        EndSeed.GenericParams Params,
        IImmutableList<(string, string)>? Constraints = null,
        bool RemoveIs = false,
        bool AddThen = false,
        bool NeedNestedImplementation = true)
    {
        public record GenericParams(
            IImmutableQueue<string> Free, string If, string Then, string Else)
        {
            public string Line => string.Join(", ",
                Free.Concat([If, Then, Else])
                    .Distinct());
        }

        public Wheres Wheres { get; } = new(Constraints ?? []);

        public string _1_Type(string closingType)
        {
            var result = _1_TypeTemplate;

            if (RemoveIs)
                result = result.Replace($".Is<{X}>", string.Empty);

            if (AddThen)
            {
                result = result.EndsWith(')')
                    ? result.Substring(0, result.Length - 1) + $".Then<{X}>)"
                    : result + $".Then<{X}>";
            }

            result = result.Replace(X, closingType);

            return result;
        }
    }
}
