namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class Through<Tʹ> {
        public static partial class Then { 
        public static partial class Through<Tʺ> { 
        public static partial class To<Tʺʹ> 
        {
            public readonly struct M4(
                Func<T , Result<Tʹ>> aExtMap,
                Func<T , Tʹ> aMap,
                Func<Tʹ, bool> bFilter,
                Func<Tʹ, Tʺ> bMap,
                Func<Tʺ, bool> cFilter,
                Func<Tʺ, Tʺʹ> cMap)
            {
                public From<T>.Through<Tʹ>.To<Tʺ>.M3 Map(Func<Tʺʹ, Tʺ> map) =>
                   new(aExtMap, aMap, bFilter, bMap, cFilter, map.Compose(cMap));

                public To<Tʺʺ>.M4 Map<Tʺʺ>(Func<Tʺʹ, Tʺʺ> map) =>
                   new(aExtMap, aMap, bFilter, bMap, cFilter, map.Compose(cMap));
            }

        }}}}}
    }
}
