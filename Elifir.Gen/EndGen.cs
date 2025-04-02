namespace Nuisho.Elifir.Gen
{
    using static Utils;

    public class EndGen : ICodeGen<EndSeed>
    {
        public IEnumerable<string> Generate(EndSeed o)
        {
            yield return $"public static {o._3_Type(o.Params.Then)} End<{o.Params.Line}>(";
            yield return $"    this ({o._1_Type(o.Params.If)}, {o._2_Type}) o)";

            foreach (var line in o.Wheres
                 .Add(o.Params.Else, o.Params.Then)
                 .Produce()) yield return  "        " + line;

            yield return  "            o.Item1.Then(o.Item2.End());";
            yield return  "";
            yield return $"public static {o._3_Type(o.Params.Else)} End<{o.Params.Line}>(";
            yield return $"    this ({o._1_Type(o.Params.If)}, {o._2_Type}) o,";
            yield return  "    AdHocPolyMarker? _ = null)";

            foreach (var line in o.Wheres
                 .Add(o.Params.Then, o.Params.Else)
                 .Produce()) yield return  "        " + line;
                        
            yield return  "            o.Item1.Then(o.Item2.End());";
            yield return  "";
            yield return $"public static {o._3_Type(B)} End<{o.Params.Line}, {B}>(";
            yield return $"    this ({o._1_Type(o.Params.If)}, {o._2_Type}) o,";
            yield return $"    WithReturnType<{B}> withReturnType{B})";

            foreach (var line in o.Wheres
                 .Add(o.Params.Then, B)
                 .Add(o.Params.Else, B)
                 .Produce()) yield return  "        " + line;

            yield return $"            o.Item1.Then(o.Item2.End(withReturnType{B}));";

            if (!o.NestedImplementation) yield break;

            yield return "";

            foreach (var line in Generate(o with
                    {
                        _1_3_TypeTemplate = $"({ꞏꞏꞏ}, {o._1_3_TypeTemplate})",
                        Params = o.Params with { Free = o.Params.Free.Add(ꞏꞏꞏ) },
                        NestedImplementation = false
                    })) 
                yield return line;
        }
    }
}
