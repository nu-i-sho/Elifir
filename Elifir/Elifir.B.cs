namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct B<T>(
            Func<T, bool> Condition,
            Func<T, T> ThenMap)
        {
            public Func<T, T> Func { get; } = x => Condition(x) ? ThenMap(x) : x;
        }

        public static Func<T, T> Else<T>(this B<T> o, Func<T, T> map) => 
            x => o.Condition(x) ? o.ThenMap(x) : map(x);
    }
}
