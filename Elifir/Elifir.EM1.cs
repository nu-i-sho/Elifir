namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class Through<Tʹ> {    
        public static partial class To<Tʺ> 
        {
            public readonly struct EM1(
                Func<T , Result<Tʺ>> aExtMap,
                Func<T , Tʺ> aMap,
                Func<Tʺ, bool> bFilter,
                Func<Tʺ, Tʺ> bMap,
                Func<Tʺ, Tʹ> bElseMap)
            {
                public From<T>.To<Tʺ>.EM0 Map(Func<Tʹ, Tʺ> map) =>
                   new(aExtMap, aMap, bFilter, bMap, map.Compose(bElseMap)); 

                public Through<Tʺʹ>.To<Tʺ>.EM1 Map<Tʺʹ>(Func<Tʹ, Tʺʹ> map) =>
                   new(aExtMap, aMap, bFilter, bMap, map.Compose(bElseMap)); 

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
        }}}
    }
}
