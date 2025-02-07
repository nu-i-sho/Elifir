namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public readonly struct ES0
            {
                private readonly Func<T, Result<Tʹ>> _aExtMap;
                private readonly Func<T, Tʹ> _aMap;
                private readonly Func<Tʹ, bool> _bFilter;
                private readonly Func<Tʹ, Tʹ> _bMap;

                public ES0(
                    Func<T , Result<Tʹ>> aExtMap,
                    Func<T , Tʹ> aMap,
                    Func<Tʹ, bool> bFilter,
                    Func<Tʹ, Tʹ> bMap)
                {
                    _aExtMap = aExtMap;
                    _aMap = aMap;
                    _bFilter = bFilter;
                    _bMap = bMap;
                }
            }
        }}
    }
}
