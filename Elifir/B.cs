namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct B<T, Tʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap);

        public static B<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this B<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                new(o.Condition,
                    o.ThenMap.Then(map));

        public static U<A<Tʹ>, B<T, Tʹ>> ThenIf<T, Tʹ>(
            this B<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new(new(condition),
                    o);

        public static C<T, Tʹ, Eʹ> Else<T, Tʹ, Eʹ>(
            this B<T, Tʹ> o,
            Func<T, Eʹ> map) =>
                new(o.Condition, o.ThenMap, map);

        public static Func<T, T> End<T, Tʹ>(
            this B<T, Tʹ> o)
                where Tʹ : T =>
                    x => o.Condition(x)
                       ? o.ThenMap(x)
                       : x;
    }
}
