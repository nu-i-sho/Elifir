namespace Nuisho.Elifir.Gen
{
    public class Supress_IDE0060_Gen<Seed>(ICodeGen<Seed> origin)
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
}
