namespace Nuisho.Elifir.Gen;

internal sealed class SyntaxClassGen<Seed>(ICodeGen<Seed> origin)
    : ICodeGen<Seed>
{
    public IEnumerable<string> Generate(Seed o)
    {
        yield return "namespace Nuisho.Elifir";
        yield return "{";
        yield return "    public static partial class Syntax";
        yield return "    {";

        foreach (var line in origin.Generate(o))
            yield return line == string.Empty
                ? string.Empty
                : $"        {line}";

        yield return "    }";
        yield return "}";
    }
}
