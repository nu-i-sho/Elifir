namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct C<T, Tʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap);

        public static Func<T, Tʹ> Else<T, Tʹ>(this C<T, Tʹ> o, Func<T, Tʹ> map) =>
            x => o.Condition(x) ? o.ThenMap(x) : map(x);
    }
}
