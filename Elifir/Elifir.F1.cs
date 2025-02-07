namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public readonly struct F1(
                Func<T , Result<Tʹ>> aExtMap,
                Func<T , Tʹ> aMap,
                Func<Tʹ, bool> bFilter)
            {
                public M1 Map(Func<Tʹ, Tʹ> map) =>
                   new(aExtMap, aMap, bFilter, map);

                public  To<Tʺ>.Else.To<Tʹ>.M2 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                   new(aExtMap, aMap, bFilter, map);
            }
        }}
    }
}
