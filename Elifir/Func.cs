using static Nuisho.Elifir;

namespace Nuisho
{
    internal static partial class Internal
    {
        public static Func<T , Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T , Tʹ> o, Func<Tʹ, Tʺ> map) => 
                x => map(o(x));

        public static U<A<Tʹ>, Func<T, Tʹ>> ThenIf<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new(new(condition),
                    o);
    }
}
