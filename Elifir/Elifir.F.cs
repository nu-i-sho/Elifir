namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct F<T, ˣT, Tʹ>(
            Func<ˣT, Tʹ> ThenMap,
            Func< T, Tʹ> ElseMap) 
                where ˣT : T;

        public static Func<T, Tʹ> End<T, ˣT, Tʹ>(
            this F<T, ˣT, Tʹ> o)
                where ˣT : T =>
                    x => x is ˣT ˣx
                       ? o.ThenMap(ˣx) 
                       : o.ElseMap(x);

        public readonly record struct F<T, ˣT, Tʹ, Eʹ>(
            Func<ˣT, Tʹ> ThenMap,
            Func< T, Eʹ> ElseMap)
                where ˣT : T;

        public static Func<T, Eʹ> End<T, ˣT, Tʹ, Eʹ>(
            this F<T, ˣT, Tʹ, Eʹ> o)
                where ˣT  : T
                where  Tʹ : Eʹ =>
                    x => x is ˣT ˣx
                       ? o.ThenMap(ˣx) 
                       : o.ElseMap(x);

        public static Func<T, Bʹ> End<T, ˣT, Bʹ, Tʹ, Eʹ>(
            this F<T, ˣT, Tʹ, Eʹ> o, 
            Func<ReturnType<Bʹ>> _)
                where ˣT  : T
                where  Tʹ : notnull, Bʹ 
                where  Eʹ : notnull, Bʹ =>
                    x => x is ˣT ˣx 
                       ? o.ThenMap(ˣx) 
                       : o.ElseMap(x);
    }
}
