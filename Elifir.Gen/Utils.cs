namespace Nuisho.Elifir.Gen
{
    using System;
    using System.Collections.Immutable;
    using System.Diagnostics;

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

            public static readonly ParamComparer Instance = new ();

            static readonly Comparer<int> NumComparer = Comparer<int>.Default;
            static readonly ImmutableDictionary<string, int> Order =
                new[] { ꞏꞏꞏ, I, T, E, Iʹ, Tʹ, Eʹ, Iʺ, Tʺ, Eʺ, B }
                .Select((x, i) => (x, i))
                .ToImmutableDictionary(o => o.x, o => o.i);

            public int Compare(string? x, string? y)
            {
                Debug.Assert(x != null && y != null);
                return NumComparer.Compare(Order[x], Order[y]);
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

        public static Іf If(string t) => new (t);

        public class Іf(string t)
            : StringHolder($"Іf<{t}>")
        {
            public IfThen Then(string t) => new (this, t);

            public IfIs Is(string t) => new (this, t);
        }

        public class IfIs(string prefix, string t)
            : StringHolder($"{prefix}.Is<{t}>");

        public class IfThen(string prefix, string t)
            : StringHolder($"{prefix}.Then<{t}>")
        {
            public IfThenElse Else => new (this);
        }

        public class IfThenElse(string prefix)
            : StringHolder($"{prefix}.Else")
        {
            public IfThenElseThen Then(string t) => new (this, t);
        }

        public class IfThenElseThen(string prefix, string t)
            : StringHolder($"{prefix}.Then<{t}>");

        public class Wheres(IImmutableList<(string, string)> typesConstraints)
        {
            public Wheres Add(string target, string super) =>
                new (typesConstraints.Add((target, super)));

            public bool IsEmpty => !typesConstraints.Any();

            public IEnumerable<string> Produce()
            {
                if (IsEmpty) yield break;

                var lines = typesConstraints
                    .GroupBy(o => o.Item1)
                    .OrderBy(o => o.Key, ParamComparer.Instance);

                using var e = lines.GetEnumerator();

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
