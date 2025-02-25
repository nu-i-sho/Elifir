namespace Nuisho
{
    public static partial class Elifir
    {
        internal static Func<T, bool> And<T>(
            this Func<T, bool> o,
            Func<T, bool> condition) =>
                x => o(x) && condition(x);

        internal static ConditionalMap<T, Tʹ> And<T, Tʹ>(
            this Func<T, bool> o,
            ConditionalMap<T, Tʹ> conditionalMap)
                where Tʹ : T =>
                    new(o.And(conditionalMap));

        public static ˣ.If<T> If<T>(
            Func<T, bool> condition) =>
                new(condition);
    }
}
