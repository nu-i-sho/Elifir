namespace Nuisho
{
    internal static partial class Internal
    {
        public static Func<T , Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T , Tʹ> o, Func<Tʹ, Tʺ> map) => 
                x => map(o(x));
    }
}
