namespace Elifir.Gen
{
    public class IfGen
    {
        public IEnumerable<Seed> Seeds()
        {
            yield return new Seed(
                Type: "Func<T, Tʹ>",
                GenericParams: ["T", "Tʹ"],
                NeedSecondImplementation: false);

            yield return new Seed(
                Type: "Іf<I>",
                GenericParams: ["I"]);

            yield return new Seed(
                Type: "Іf<I>.Is<Iʹ>",
                GenericParams: ["I", "Iʹ"],
                AdditionalConstraint: "Iʹ : I");

            yield return new Seed(
                Type: "Іf<I>.Then<T>",
                GenericParams: ["I", "T"]);

            yield return new Seed(
                Type: "Іf<I>.Then<T>.Else",
                GenericParams: ["I", "T"]);

            yield return new Seed(
                Type: "Іf<I>.Then<T>.Else.Then<E>",
                GenericParams: ["I", "T", "E"]);
        }

        public record Seed(
            string Type,
            IEnumerable<string> GenericParams,
            string? AdditionalConstraint = null,
            bool NeedSecondImplementation = true);

        public IEnumerable<string> Generate(IEnumerable<Seed> o)
        {
                        yield return  "namespace Nuisho.Elifir";
                        yield return  "{";
                        yield return  "    public static partial class Syntax";
                        yield return  "    {";

            foreach (var lines in o.Select(Generate))
            { 
                foreach (var line in lines)
                        yield return $"        {line}";
                        
                        yield return  "";
            }
                        yield return  "    }";
                        yield return  "}";
        }

        public IEnumerable<string> Generate(Seed o)
        {
            var t = o.GenericParams.Last();
            var tʹ = t.Last() switch
            {
                'ʹ' => t.Replace('ʹ', 'ʺ'),
                _ => t + 'ʹ'
            };

            var tLine = string.Join(", ", o.GenericParams);
            var tʹLine = string.Join(", ", o.GenericParams.Concat([tʹ]));

                        yield return $"public static ({o.Type}, Іf<{t}>) If<{tLine}>(";
                        yield return $"    this {o.Type} o,";

            if (o.AdditionalConstraint == null)
            {
                        yield return $"    Func<{t}, bool> condition) =>";
                        yield return  "        (o, If(condition));";
            }
            else
            {
                        yield return $"    Func<{t}, bool> condition)";
                        yield return $"        where {o.AdditionalConstraint} => ";
                        yield return  "            (o, If(condition));";
            }
                        yield return "";
                        yield return $"public static ({o.Type}, Іf<{t}>.Is<{tʹ}>) If<{tʹLine}>(";
                        yield return $"    this {o.Type} o,";
                        yield return $"    IsOfType<{tʹ}> condition)";

            if (o.AdditionalConstraint != null)
                        yield return $"        where {o.AdditionalConstraint}";
                    
                        yield return $"        where {tʹ} : {t} =>";
                        yield return  "            (o, new());";

            if (o.NeedSecondImplementation)
            {
                        yield return "";

                foreach (var line in Generate(o with
                {
                    Type = $"(ꞏꞏꞏ, {o.Type})",
                    GenericParams = Enumerable.Concat(["ꞏꞏꞏ"], o.GenericParams),
                    NeedSecondImplementation = false
                }))
                        yield return line;       
            }
        }
    }
}
