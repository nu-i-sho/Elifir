namespace Nuisho
{
    public static partial class Elifir
    {
        public static partial class From<T> {
        public static partial class To<Tʹ>
        {
            public interface IConvertor
            {
                Func<T, Result<Tʹ>> ExtConvert { get; }

                Func<T, Tʹ> Convert { get; }
            }
        }}
    }
}
