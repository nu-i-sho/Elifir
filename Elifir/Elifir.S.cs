namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class Mono<T>
        {
            public readonly record struct S() : From<T>.To<T>.IConvertor
            {
                public Func<T, Result<T>> ExtConvert { get; } =
                    Result<T>.Converted;

                public Func<T, T> Convert { get; } =
                    Identity;

                public From<T>.To<Tʹ>.M0 Map<Tʹ>(Func<T, Tʹ> map) =>
                    new(map);

                public ThenMorpheme<F0> If(Func<T, bool> filter) => 
                   new(new(filter));
            }
        }}
    
}
