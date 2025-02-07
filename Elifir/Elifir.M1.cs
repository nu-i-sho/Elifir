namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public readonly struct M1 : IConvertor
            {
                private readonly Func<T, Result<Tʹ>> _aExtMap;
                private readonly Func<T, Tʹ> _aMap;
                private readonly Func<Tʹ, bool> _bFilter;
                private readonly Func<Tʹ, Tʹ> _bMap;

                public M1(
                    Func<T , Result<Tʹ>> aExtMap,
                    Func<T , Tʹ> aMap,
                    Func<Tʹ, bool> bFilter,
                    Func<Tʹ, Tʹ> bMap)
                {
                    ExtConvert = x =>
                    {
                        var xʹResult = aExtMap(x);

                        if (xʹResult.IsConverted)
                            return bFilter(xʹResult.Value)
                                 ? Result<Tʹ>.Converted(bMap(xʹResult.Value))
                                 : Result<Tʹ>.Original(xʹResult.Value);

                        return xʹResult;
                    };

                    Convert = x =>
                    {
                        var xʹ = aMap(x);
                        return bFilter(xʹ) ? bMap(xʹ) : xʹ;
                    };

                    _aExtMap = aExtMap;
                    _aMap = aMap;
                    _bFilter = bFilter;
                    _bMap = bMap;
                }

                public Func<T, Result<Tʹ>> ExtConvert { get; }

                public Func<T, Tʹ> Convert { get; }

                public ES0 Else => new(_aExtMap, _aMap, _bFilter, _bMap);

                public M0 End => new(Convert);

                public M1 Map(Func<Tʹ, Tʹ> map) =>
                   new(_aExtMap, _aMap, _bFilter, map.Compose(_bMap)); 

                public To<Tʺ>.Else.To<Tʹ>.M2 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                   new(_aExtMap, _aMap, _bFilter, map.Compose(_bMap)); 
            }
        }}
    }
}
