namespace Nuisho
{
    public static partial class Elifir
    {
        public static T Identity<T>(T x) => x;

        public static bool TrueForAll<T>(T _) => true;

        public static Func<T, Tʺ> Compose<T, Tʹ, Tʺ>(
                 this Func<Tʹ, Tʺ> g,
                      Func<T, Tʹ> f) => x => g(f(x));

        public static Func<T, bool> And<T>(
                 this Func<T, bool> f,
                      Func<T, bool> g) => x => f(x) && g(x);

        public static Func<T, Result<Tʹ>> Ext<T, Tʹ>(Func<T, Tʹ> convert) =>
            Result<Tʹ>.Converted.Compose(convert);
        
        public readonly struct ThenMorpheme<T>(T x)
        {
            public T Then => x;
        }
    }
}
