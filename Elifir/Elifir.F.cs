namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct F<T, ˣT, Tʹ>(
            Func<ˣT, Tʹ> ThenMap,
            Func< T, Tʹ> ElseMap) 
                where ˣT : T;

        public static Func<T, Tʹ> End<T, ˣT, Tʹ>(this F<T, ˣT, Tʹ> o) where ˣT : T =>
            x => x is ˣT ˣx ? o.ThenMap(ˣx) : o.ElseMap(x);
    }
}
