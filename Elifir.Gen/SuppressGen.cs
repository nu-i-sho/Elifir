namespace Nuisho.Elifir.Gen
{
    public static class SuppressGen
    {
        public class IDE0060<Seed>(ICodeGen<Seed> origin)
            : ICodeGen<Seed>
        {
            public IEnumerable<string> Generate(Seed o)
            {
                yield return "#pragma warning disable IDE0060 // Remove unused parameter";
                yield return "// All these parameters are necessary to avoid explicit generic parameter types.";
                yield return string.Empty;

                foreach (var line in origin.Generate(o))
                    yield return line;

                yield return string.Empty;
                yield return "#pragma warning restore IDE0060 // Remove unused parameter";
            }
        }

        public class IDE0079<Seed>(ICodeGen<Seed> origin)
            : ICodeGen<Seed>
        {
            public IEnumerable<string> Generate(Seed o)
            {
                yield return "#pragma warning disable IDE0079 // Remove unnecessary suppression";
                yield return "// False positive.";
                yield return string.Empty;

                foreach (var line in origin.Generate(o))
                    yield return line;

                yield return string.Empty;
                yield return "#pragma warning restore IDE0079 // Remove unnecessary suppression";
            }
        }

        public class S3427<Seed>(ICodeGen<Seed> origin)
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
}
