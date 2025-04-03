namespace Nuisho.Elifir.Gen
{
    using System;
    using System.Collections.Immutable;
    using System.Diagnostics;

    internal static class Utils
    {
        internal const string X = "X";
        internal const string
            I = "I", Iʹ = "Iʹ", Iʺ = "Iʺ",
            T = "T", Tʹ = "Tʹ", Tʺ = "Tʺ",
            E = "E", Eʹ = "Eʹ", Eʺ = "Eʺ",
            B = "B",
            ꞏꞏꞏ = "ꞏꞏꞏ";

        internal sealed class ParamComparer : IComparer<string>
        {
            ParamComparer() { }

            internal static readonly ParamComparer Instance = new ();

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

        internal sealed class Token;

        internal class StringHolder(string value)
        {
            internal string Value => value;

            public static implicit operator string(StringHolder holder) =>
                holder.Value;
        }

        internal static string Func(string t1, string t2) =>
            $"Func<{t1}, {t2}>";

        internal static Іf If(string t) => new (t);

        internal sealed class Іf(string t)
            : StringHolder($"Іf<{t}>")
        {
            internal IfThen Then(string t) => new (this, t);

            internal IfIs Is(string t) => new (this, t);
        }

        internal sealed class IfIs(string prefix, string t)
            : StringHolder($"{prefix}.Is<{t}>");

        internal sealed class IfThen(string prefix, string t)
            : StringHolder($"{prefix}.Then<{t}>")
        {
            internal IfThenElse Else => new (this);
        }

        internal sealed class IfThenElse(string prefix)
            : StringHolder($"{prefix}.Else")
        {
            internal IfThenElseThen Then(string t) => new (this, t);
        }

        internal sealed class IfThenElseThen(string prefix, string t)
            : StringHolder($"{prefix}.Then<{t}>");

        internal sealed class Wheres(IImmutableList<(string, string)> typesConstraints)
        {
            internal Wheres Add(string target, string super) =>
                new (typesConstraints.Add((target, super)));

            internal bool IsEmpty => !typesConstraints.Any();

            internal IEnumerable<string> Produce()
            {
                if (IsEmpty) yield break;

                var lines = typesConstraints
                    .GroupBy(o => o.Item1, StringComparer.Ordinal)
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
