namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public readonly struct ES0(
                Func<T, Result<Tʹ>> aExtMap,
                Func<T, Tʹ> aMap,
                Func<Tʹ, bool> bFilter,
                Func<Tʹ, Tʹ> bMap)
            {
                public EM0 Map(Func<Tʹ, Tʹ> map) =>
                    new(aExtMap, aMap, bFilter, bMap, map);

                public Through<Tʺ>.To<Tʹ>.EM1 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                    new(aExtMap, aMap, bFilter, bMap, map);
            }
        }}
    }
}
