namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;

    public static class Utils
    {
        public const string X = "X";

        public class Token;

        public class StringHolder(string value)
        {
            public string Value => value;

            public static implicit operator string(StringHolder holder) =>
                holder.Value;
        }

        public static string Func(string t1, string t2) =>
            $"Func<{t1}, {t2}>";

        public static Іf If(string t) => new(t);

        public class Іf(string t)
            : StringHolder($"Іf<{t}>")
        {
            public IfThen Then(string t) => new(this, t);

            public IfIs Is(string t) => new(this, t);
        }

        public class IfIs(string prefix, string t)
            : StringHolder($"{prefix}.Is<{t}>");

        public class IfThen(string prefix, string t)
            : StringHolder($"{prefix}.Then<{t}>")
        {
            public IfThenElse Else => new(this);
        }

        public class IfThenElse(string prefix)
            : StringHolder(prefix + ".Else")
        {
            public IfThenElseThen Then(string t) => new(this, t);
        }

        public class IfThenElseThen(string prefix, string t)
            : StringHolder($"{prefix}.Then<{t}>");

        public class Wheres(IImmutableList<(string, string)> typesConstraints)
        {
            public Wheres Add(string target, string super) =>
                new(typesConstraints.Add((target, super)));

            public IEnumerable<string> Produce(string indentation) =>
                typesConstraints
                    .GroupBy(o => o.Item1)
                    .Select((o, i) => new
                    {
                        Target = o.Key,
                        SuperLine = string.Join(", ", o),
                        Ending = i == typesConstraints.Count - 1
                            ? " =>"
                            : string.Empty
                    })
                    .Select(o => $"{indentation}where {o.Target} : {o.SuperLine}{o.Ending}");
        }
    }
}
