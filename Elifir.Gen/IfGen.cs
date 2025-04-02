namespace Nuisho.Elifir.Gen
{
    using static Utils;

    public class IfGen : ICodeGen<IfSeed>
    {
        public IEnumerable<string> Generate(IfSeed o)
        {
            yield return $"public static ({o.Type}, Іf<{o.Params.If}>) If<{o.Params.ShortLine}>(";
            yield return $"    this {o.Type} o,";
            yield return $"    Func<{o.Params.If}, bool> condition)" + (o.Wheres.IsEmpty ? " =>" : "");

            foreach (var line in o.Wheres
                .Produce()) yield return "        " + line;

            yield return  "        (o, If(condition));";
            yield return  "";
            yield return $"public static ({o.Type}, Іf<{o.Params.If}>.Is<{o.Params.Next}>) If<{o.Params.LongLine}>(";
            yield return $"    this {o.Type} o,";
            yield return $"    IsOfType<{o.Params.Next}> condition)";

            foreach (var line in o.Wheres
                .Add(o.Params.Next, o.Params.If)
                .Produce()) yield return "        " + line;

            yield return  "            (o, new());";

            if (!o.NestedImplementation) yield break;
            
            yield return "";

            foreach (var line in Generate(o with
                {
                    Type = $"({ꞏꞏꞏ}, {o.Type})",
                    Params = o.Params with { Free = o.Params.Free.Add(ꞏꞏꞏ) },
                    NestedImplementation = false
                })) yield return line;
        }
    }
}
