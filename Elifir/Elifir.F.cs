namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct F<T, ˣT, Tʹ>(
            SubTypingCondition<T, ˣT> Condition,
            Func<ˣT, Tʹ> ThenMap,
            Func< T, Tʹ> ElseMap) 
                where ˣT : T;

        public static Func<T, Tʹ> End<T, ˣT, Tʹ>(
            this F<T, ˣT, Tʹ> o)
                where ˣT : T =>
                    x => o.Condition(x, out ˣT ˣx)
                       ? o.ThenMap(ˣx) 
                       : o.ElseMap(x);

        public readonly record struct F<T, ˣT, Tʹ, Eʹ>(
            SubTypingCondition<T, ˣT> Condition,
            Func<ˣT, Tʹ> ThenMap,
            Func< T, Eʹ> ElseMap)
                where ˣT : T;

        public static Func<T, Eʹ> End<T, ˣT, Tʹ, Eʹ>(
            this F<T, ˣT, Tʹ, Eʹ> o)
                where ˣT  : T
                where  Tʹ : Eʹ =>
                    x => o.Condition(x, out ˣT ˣx)
                       ? o.ThenMap(ˣx) 
                       : o.ElseMap(x);

        public static Func<T, Bʹ> End<T, ˣT, Bʹ, Tʹ, Eʹ>(
            this F<T, ˣT, Tʹ, Eʹ> o, 
            Func<ReturnType<Bʹ>> _)
                where ˣT  : T
                where  Tʹ : notnull, Bʹ 
                where  Eʹ : notnull, Bʹ =>
                    x => o.Condition(x, out ˣT ˣx)
                       ? o.ThenMap(ˣx) 
                       : o.ElseMap(x);
    }
}
