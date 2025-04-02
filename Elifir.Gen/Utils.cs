namespace Nuisho.Elifir.Gen
{
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public static class Utils
    {
        public const string X = "X";
        public const string
            I = "I", Iʹ = "Iʹ", Iʺ = "Iʺ",
            T = "T", Tʹ = "Tʹ", Tʺ = "Tʺ",
            E = "E", Eʹ = "Eʹ", Eʺ = "Eʺ",
            B = "B",
            ꞏꞏꞏ = "ꞏꞏꞏ";

        public class ParamComparer : IComparer<string>
        {
            ParamComparer() { }

            public static readonly ParamComparer Instance = new ParamComparer();

            static readonly IComparer<int> numComparer = Comparer<int>.Default;
            static readonly ImmutableArray<string> order =
                [ꞏꞏꞏ, I, T, E, Iʹ, Tʹ, Eʹ, Iʺ, Tʺ, Eʺ, B];

            public int Compare(string? x, string? y)
            {
                Debug.Assert(x != null && y != null);
                return numComparer.Compare(
                    order.IndexOf(x),
                    order.IndexOf(y));
            }
        }

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

            public bool IsEmpty => !typesConstraints.Any();

            public IEnumerable<string> Produce()
            {
                if (IsEmpty) yield break;

                var lines = typesConstraints
                    .GroupBy(o => o.Item1)
                    .OrderBy(o => o.Key, ParamComparer.Instance);
                    
                var e = lines.GetEnumerator();

                var hasNext = e.MoveNext();
                while (hasNext)
                {
                    var target = e.Current.Key;
                    var superLine = string.Join(", ", e.Current.Select(x => x.Item2));
                    
                    hasNext = e.MoveNext();
                    var ending = hasNext ? string.Empty : " =>";

                    yield return $"where {target} : {superLine}{ending}";
                }
            }
        }
    }
}
