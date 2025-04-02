namespace Nuisho.Elifir.Gen
{
    public class Supress_IDE0079_Gen<Seed>(ICodeGen<Seed> origin)
        : ICodeGen<Seed>
    {
        public IEnumerable<string> Generate(Seed o)
        {
            yield return "#pragma warning disable IDE0079 // Remove unnecessary supression";
            yield return "// False positive.";
            yield return string.Empty;

            foreach (var line in origin.Generate(o))
                yield return line;

            yield return string.Empty;
            yield return "#pragma warning restore IDE0079 // Remove unnecessary supression";
        }
    }
}
