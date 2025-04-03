namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using static Utils;

    public record EndSeed(
        string FirstAndThirdTypeTemplate,
        string SecondType,
        EndSeed.GenericParams Params,
        IImmutableList<(string, string)>? Constraints = null,
        bool RemoveIs = false,
        bool AddThen = false,
        bool NestedImplementation = true)
    {
        public record GenericParams(
            IImmutableList<string> Free, string If, string Then, string Else)
        {
            public string Line => string.Join(", ",
                Free.Concat([If, Then, Else])
                    .Distinct()
                    .Order(ParamComparer.Instance));
        }

        public Wheres Wheres { get; } = new (Constraints ?? []);

        public string FirstType(string closingType) =>
            FirstAndThirdTypeTemplate.Replace(X, closingType);

        public string ThirdType(string closingType)
        {
            var result = FirstAndThirdTypeTemplate;

            if (RemoveIs)
                result = result.Replace($".Is<{X}>", string.Empty);

            if (AddThen)
            {
                result = result.EndsWith(')')
                    ? $"{result.AsSpan(0, result.Length - 1)}.Then<{X}>)"
                    : $"{result}.Then<{X}>";
            }

            result = result.Replace(X, closingType);

            return result;
        }
    }
}
