namespace Nuisho
{
    using static Elifir;

    public static partial class Elifir
    {
        public readonly record struct B<T, Tʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap);

        public static Func<T, T> End<T, Tʹ>(this B<T, Tʹ> o) where Tʹ : T =>
            x => o.Condition(x) ? o.ThenMap(x) : x;

        public static C<T, Tʹ> Else<T, Tʹ, Eʹ>(this B<T, Tʹ> o, Func<T, Eʹ> map) where Eʹ : class, Tʹ =>
            new(o.Condition, o.ThenMap, map);
    }

    public static class ElifirPlus
    {
        public static C<T, Tʹ> Else<T, Tʹ, Eʹ>(this B<T, Tʹ> o, Func<T, Eʹ> map) where Eʹ : struct, Tʹ =>
            new(o.Condition, o.ThenMap, x => map(x));
    }

    public static class ElifirPlusPlus
    {
        public static C<T, Tʹ, Eʹ> Else<T, Tʹ, Eʹ>(this B<T, Tʹ> o, Func<T, Eʹ> map, 
            AdHocPolyMarker _ = default) =>
                new(o.Condition, o.ThenMap, map);
    }
}
