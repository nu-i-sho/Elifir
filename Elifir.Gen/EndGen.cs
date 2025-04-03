namespace Nuisho.Elifir.Gen
{
    using static Utils;

    public class EndGen : ICodeGen<EndSeed>
    {
        public IEnumerable<string> Generate(EndSeed o)
        {
            yield return $"public static {o.ThirdType(o.Params.Then)} End<{o.Params.Line}>(";
            yield return $"    this ({o.FirstType(o.Params.If)}, {o.SecondType}) o)";

            foreach (var line in o.Wheres
                 .Add(o.Params.Else, o.Params.Then)
                 .Produce()) yield return $"        {line}";

            yield return  "            o.Item1.Then(o.Item2.End());";
            yield return  string.Empty;
            yield return $"public static {o.ThirdType(o.Params.Else)} End<{o.Params.Line}>(";
            yield return $"    this ({o.FirstType(o.Params.If)}, {o.SecondType}) o,";
            yield return  "    AdHocPolyMarker? _ = null)";

            foreach (var line in o.Wheres
                 .Add(o.Params.Then, o.Params.Else)
                 .Produce()) yield return $"        {line}";

            yield return  "            o.Item1.Then(o.Item2.End());";
            yield return  string.Empty;
            yield return $"public static {o.ThirdType(B)} End<{o.Params.Line}, {B}>(";
            yield return $"    this ({o.FirstType(o.Params.If)}, {o.SecondType}) o,";
            yield return $"    WithReturnType<{B}> withReturnType{B})";

            foreach (var line in o.Wheres
                 .Add(o.Params.Then, B)
                 .Add(o.Params.Else, B)
                 .Produce()) yield return $"        {line}";

            yield return $"            o.Item1.Then(o.Item2.End(withReturnType{B}));";

            if (!o.NestedImplementation) yield break;

            yield return  string.Empty;

            foreach (var line in Generate(o with
                    {
                        FirstAndThirdTypeTemplate = $"({ꞏꞏꞏ}, {o.FirstAndThirdTypeTemplate})",
                        Params = o.Params with { Free = o.Params.Free.Add(ꞏꞏꞏ) },
                        NestedImplementation = false
                    }))
                yield return line;
        }
    }
}
