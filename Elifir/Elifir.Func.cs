namespace Nuisho
{
    public static partial class Elifir
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
                 this Func<T, Tʹ> o,
                      Func<Tʹ, Tʺ> map) => x => map(o(x));

        public static Func<T, Tʹ> Then<T, Tʹ>(
                 this Func<T, Tʹ> o, 
                      B<Tʹ> map) => x => map.Func(o(x));
    }
}
