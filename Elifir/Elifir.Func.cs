namespace Nuisho
{
    public static partial class Elifir
    {
        public static Func<T , Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T , Tʹ> o,
            Func<Tʹ, Tʺ> map) => 
                x => map(o(x));
    }
}
