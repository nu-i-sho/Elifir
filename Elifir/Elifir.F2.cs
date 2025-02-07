namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> { 
        public static partial class Through<Tʹ> {
        public static partial class To<Tʺ>
        {
            public readonly struct F2(
                Func<T, Result<Tʹ>> aExtMap,
                Func<T, Tʹ> aMap,
                Func<Tʹ, bool> bFilter,
                Func<Tʹ, Tʺ> bMap,
                Func<Tʺ, bool> cFilter)
            {
                public M3 Map(Func<Tʺ, Tʺ> map) =>
                   new(aExtMap, aMap, bFilter, bMap, cFilter, map);

                public Then.Through<Tʺ>.To<Tʺʹ>.M4 Map<Tʺʹ>(Func<Tʺ, Tʺʹ> map) =>
                   new(aExtMap, aMap, bFilter, bMap, cFilter, map);
            }
        }}}
    }
}
