namespace Nuisho.Elifir.Gen
{
    public class HeadCommentGen<Seed>(ICodeGen<Seed> origin)
        : ICodeGen<Seed>
    {
        public IEnumerable<string> Generate(Seed o)
        {
            yield return "// To regenerate this file with the Elifir.Gen remove";
            yield return "// the current file and build/rebuild the current project.";
            yield return string.Empty;

            foreach (var line in origin.Generate(o))
                yield return line;
        }
    }
}
