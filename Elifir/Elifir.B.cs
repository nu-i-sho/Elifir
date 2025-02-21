namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct B<T, Tʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap);

        public static Func<T, T> End<T, Tʹ>(
            this B<T, Tʹ> o) 
                where Tʹ : T =>
                    x => o.Condition(x) 
                       ? o.ThenMap(x) 
                       : x;

        public static C<T, Tʹ, Eʹ> Else<T, Tʹ, Eʹ>(
            this B<T, Tʹ> o,
            Func<T, Eʹ> map) =>
                new(o.Condition, o.ThenMap, map);
    }
}
