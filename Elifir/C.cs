namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct C<T, Tʹ, Eʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap,
            Func<T, Eʹ> ElseMap);

        public static C<T, Tʹ, Eʺ> Then<T, Tʹ, Eʹ, Eʺ>(
            this C<T, Tʹ, Eʹ> o,
            Func<Eʹ, Eʺ> map) =>
                new(o.Condition,
                    o.ThenMap,
                    o.ElseMap.Then(map));

        public static U<A<Eʹ>, C<T, Tʹ, Eʹ>> ThenIf<T, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o,
            Func<Eʹ, bool> condition) =>
                new(new(condition),
                    o);

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
