namespace Nuisho.Elifir.Gen
{
    public class Supress_S3427_Gen<Seed>(ICodeGen<Seed> origin)
        : ICodeGen<Seed>
    {
        public IEnumerable<string> Generate(Seed o)
        {
            yield return "#pragma warning disable S3427   // Method overloads with default parameter values should not overlap";
            yield return "// AdHocPolyMarker parameter is used as a workaround because of the limitation of static polymorphism,";
            yield return "// which doesn't recognize generic constraints as a part of the signature.";
            yield return string.Empty;

            foreach (var line in origin.Generate(o))
                yield return line;

            yield return string.Empty;
            yield return "#pragma warning restore S3427   // Method overloads with default parameter values should not overlap";
        }
    }
}
