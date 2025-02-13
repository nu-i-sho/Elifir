namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct E<T, ˣT, Tʹ>(
            Func<ˣT, Tʹ> ThenMap) 
                where ˣT : T;

        public static F<T, ˣT, Tʹ> Else<T, ˣT, Tʹ>(
            this E<T, ˣT, Tʹ> o, Func<T, Tʹ> map) where ˣT : T => 
                new(o.ThenMap, map);

        public static Func<T, T> End<T, ˣT, Tʹ>(this E<T, ˣT, Tʹ> o)
            where ˣT : T where Tʹ : T => x =>
                x is ˣT ˣx ? o.ThenMap(ˣx) : x;
    }
}
