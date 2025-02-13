namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct C<T, Tʹ, Tʺ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap,
            Func<T, Tʺ> ElseMap);

        public static Func<T, Tʹ> End<T, Tʹ>(this C<T, Tʹ, Tʹ> o) =>
            x => o.Condition(x) ? o.ThenMap(x) : o.ElseMap(x);
    }
}
