namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ> { 
        public static partial class Else {
        public static partial class To<Eʹ>
        {
            public readonly struct M2
            {
                private readonly Func<T, Result<Eʹ>> _aExtMap;
                private readonly Func<T, Eʹ> _aMap;
                private readonly Func<Eʹ, bool> _bFilter;
                private readonly Func<Eʹ, Tʹ> _bMap;

                public M2(
                    Func<T,  Result<Eʹ>> aExtMap,
                    Func<T,  Eʹ> aMap,
                    Func<Eʹ, bool> bFilter,
                    Func<Eʹ, Tʹ> bMap)
                {
                    _aExtMap = aExtMap;
                    _aMap = aMap;
                    _bFilter = bFilter;
                    _bMap = bMap;
                }
                
                public From<T>.To<Eʹ>.M1 Map(Func<Tʹ, Eʹ> map) =>
                   new(_aExtMap, _aMap, _bFilter, map.Compose(_bMap));

                public From<T>.To<Tʺ>.Else.To<Eʹ>.M2 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                   new(_aExtMap, _aMap, _bFilter, map.Compose(_bMap)); 
            }
        }}}}
    }
}
