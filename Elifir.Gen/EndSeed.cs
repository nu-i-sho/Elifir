namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using static Utils;

    internal sealed record EndSeed(
        string FirstAndThirdTypeTemplate,
        string SecondType,
        EndSeed.GenericParams Params,
        IImmutableList<(string, string)>? Constraints = null,
        bool RemoveIs = false,
        bool AddThen = false,
        bool NestedImplementation = true)
    {
        internal sealed record GenericParams(
            IImmutableList<string> Free, string If, string Then, string Else)
        {
            internal string Line => string.Join(", ",
                Free.Concat([If, Then, Else])
                    .Order(ParamComparer.Instance)
                    .Distinct());
        }

        internal Wheres Wheres { get; } = new (Constraints ?? []);

        internal string FirstType(string closingType) =>
            FirstAndThirdTypeTemplate.Replace(X, closingType);

        internal string ThirdType(string closingType)
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

            return result.Replace(X, closingType);
        }
    }
}
