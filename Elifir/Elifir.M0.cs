namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public readonly struct M0(Func<T, Tʹ> aMap)
            {
                public Func<T, Result<Tʹ>> ExtConvert { get; } =
                    Result<Tʹ>.Converted.Compose(aMap);

                public Func<T, Tʹ> Convert { get; } =
                    aMap;

                public To<Tʺ>.M0 Map<Tʺ>(Func<Tʹ, Tʺ> map) =>
                    new(map.Compose(Convert));

                public ThenMorpheme<F1> If(Func<Tʹ, bool> filter) =>
                    new(new(ExtConvert, Convert, filter));
            }
        }}
    }
}
