namespace Nuisho.Elifir.Gen
{
    public class CodeFileGen<Seed>(ICodeGen<Seed> subGen)
        : ICodeGen<Seed>
    {
        public IEnumerable<string> Generate(Seed o)
        {
                yield return "namespace Nuisho.Elifir";
                yield return "{";
                yield return "    public static partial class Syntax";
                yield return "    {";
            
            foreach (var line in subGen.Generate(o))
                yield return "        " + line;

                yield return "    }";
                yield return "}";
        }
    }
}
