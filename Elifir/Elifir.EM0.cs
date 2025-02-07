namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public readonly struct EM0 : IConvertor
            {
                private readonly Func<T , Result<Tʹ>> _aExtMap;
                private readonly Func<T , Tʹ> _aMap;
                private readonly Func<Tʹ, bool> _bFilter;
                private readonly Func<Tʹ, Tʹ> _bMap;
                private readonly Func<Tʹ, Tʹ> _bElseMap; 

                public EM0(
                    Func<T , Result<Tʹ>> aExtMap,
                    Func<T , Tʹ> aMap,
                    Func<Tʹ, bool> bFilter,
                    Func<Tʹ, Tʹ> bMap,
                    Func<Tʹ, Tʹ> bElseMap)
                {
                    ExtConvert = x =>
                    {
                        var xʹResult = aExtMap(x);

                        if (xʹResult.IsConverted)
                            return bFilter(xʹResult.Value)
                                 ? Result<Tʹ>.Converted(bMap(xʹResult.Value))
                                 : Result<Tʹ>.Original(bElseMap(xʹResult.Value));

                        return xʹResult;
                    };

                    Convert = x =>
                    {
                        var xʹ = aMap(x);
                        return bFilter(xʹ) 
                             ? bMap(xʹ) 
                             : bElseMap(xʹ);
                    };

                    _aExtMap = aExtMap;
                    _aMap = aMap;
                    _bFilter = bFilter;
                    _bMap = bMap;
                    _bElseMap = bElseMap;
                }

                public Func<T, Result<Tʹ>> ExtConvert { get; }

                public Func<T, Tʹ> Convert { get; }

                public M0 End => new(Convert);

                public EM0 Map(Func<Tʹ, Tʹ> map) =>
                   new(_aExtMap, _aMap, _bFilter, _bMap, map.Compose(_bElseMap)); 
                
                public Through<Tʺ>.To<Tʹ>.EM1 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                   new(_aExtMap, _aMap, _bFilter, _bMap, map.Compose(_bElseMap)); 

                //public To<Tʺ>.M0 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                //    new(map.Compose(Convert));

                //public M1 Map(Func<Tʹ, Tʹ> map) =>
                //   new(_aExtMap, _aMap, _bFilter, map.Compose(_bMap)); 

                //public Through<Tʹ>.To<Tʺ>.M2 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                //   new(_aExtMap, _aMap, _bFilter, map.Compose(_bMap)); 



                //public F3 Filter(Func<Tʹ, bool> filter) =>
                //   new(Ext(Convert), Convert, filter);

                //public F3 ThenFilter(Func<Tʹ, bool> filter) =>
                //   new(ExtConvert, Convert, filter);


                //public For<ˣTʹ>.F4 FilterOfType<ˣTʹ>() where ˣTʹ : Tʹ
                //{
                //    var convert = Convert;
                //    return new(x => ConversionResult<Tʹ>.Converted(convert(x).Value));
                //}



                //public For<ˣTʹ>.F4 ThenFilterOfType<ˣTʹ>() where ˣTʹ : Tʹ =>
                //    new(Convert);
            }
        }}
    }
}
