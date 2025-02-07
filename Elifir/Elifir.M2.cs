namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class Through<Tʹ> {
        public static partial class To<Tʺ>
        {
            public readonly struct M2(
                    Func<T, Result<Tʹ>> aExtMap,
                    Func<T, Tʹ> aMap,
                    Func<Tʹ, bool> bFilter,
                    Func<Tʹ, Tʺ> bMap)
            {

                public From<T>.To<Tʹ>.M1 Map(Func<Tʺ, Tʹ> map) =>
                    new(aExtMap, aMap, bFilter, map.Compose(bMap));

                public To<Tʺʹ>.M2 Map<Tʺʹ>(Func<Tʺ, Tʺʹ> map) =>
                    new(aExtMap, aMap, bFilter, map.Compose(bMap));

                public ThenMorpheme<F2> If(Func<Tʺ, bool> filter) =>
                    new(new(aExtMap, aMap, bFilter, bMap, filter));
            }
        }}}
    }
}
