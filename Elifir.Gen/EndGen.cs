namespace Nuisho.Elifir.Gen
{
    public class EndGen : ICodeGen<EndSeed>
    {
        public IEnumerable<string> Generate(EndSeed o) =>
            Generate(o, generateNested: true);

        IEnumerable<string> Generate(EndSeed o, bool generateNested)
        {
            const string B = "B", ꞏꞏꞏ = "ꞏꞏꞏ";

            yield return $"public static {o._1_Type(o.Params.Then)} End<{o.Params.All}>(";
            yield return $"    this ({o._1_Type(o.Params.If)}, {o._2_Type}) o)";

            foreach (var line in o.Wheres
                 .Add(o.Params.Else, o.Params.Then)
                 .Produce("        ")) yield return line;

            yield return  "            o.Item1.Then(o.Item2.End());";

            yield return $"public static {o._1_Type(o.Params.Else)} End<{o.Params.All}>(";
            yield return $"    this ({o._1_Type(o.Params.If)}, {o._2_Type}) o,";
            yield return  "    AdHocPolyMarker ? _ = null)";

            foreach (var line in o.Wheres
                 .Add(o.Params.Then, o.Params.Else)
                 .Produce("        ")) yield return line;
           
            yield return  "            o.Item1.Then(o.Item2.End());";

            yield return $"public static {o._1_Type(B)} End<{o.Params.All}, {B}>(";
            yield return $"    this ({o._1_Type(o.Params.If)}, {o._2_Type}) o,";
            yield return $"    WithReturnType<{B}> withReturnType{B})";

            foreach (var line in o.Wheres
                 .Add(o.Params.Then, B)
                 .Add(o.Params.Else, B)
                 .Produce("        ")) yield return line;

            yield return $"            o.Item1.Then(o.Item2.End(withReturnType{B}));";

            if (!generateNested) yield break;

            foreach (var line in Generate(o with
                    {
                        _1_TypeTemplate = $"({ꞏꞏꞏ}, {o._1_TypeTemplate})",
                        Params = o.Params with { Free = o.Params.Free.Enqueue(ꞏꞏꞏ) }
                    }, generateNested: false)) 
                yield return line;
        }
    }
}
