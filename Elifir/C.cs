namespace Nuisho
{
    using static Elifir;

    public static partial class Elifir
    {
        public readonly record struct C<T, Tʹ, Eʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap,
            Func<T, Eʹ> ElseMap);
    }

    internal static partial class Internal
    {
        public static Func<T, Tʹ> End<T, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o)
                where Eʹ : Tʹ =>
                    x => o.Condition(x)
                       ? o.ThenMap(x)
                       : o.ElseMap(x);

        public static Func<T, Eʹ> End<T, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    x => o.Condition(x)
                       ? o.ThenMap(x)
                       : o.ElseMap(x);

        public static Func<T, Bʹ> End<T, Bʹ, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o,
            Func<ReturnType<Bʹ>> _)
                where Tʹ : Bʹ
                where Eʹ : Bʹ =>
                    x => o.Condition(x)
                       ? o.ThenMap(x)
                       : o.ElseMap(x);
    }
}
