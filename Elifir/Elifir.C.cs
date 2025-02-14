namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct C<T, Tʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap,
            Func<T, Tʹ> ElseMap);

        public static Func<T, Tʹ> End<T, Tʹ>(
            this C<T, Tʹ> o) =>
                x => o.Condition(x) 
                   ? o.ThenMap(x) 
                   : o.ElseMap(x);

        public readonly record struct C<T, Tʹ, Eʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap,
            Func<T, Eʹ> ElseMap);

        public static Func<T, Eʹ> End<T, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o) 
                where Tʹ : Eʹ =>
                    x => o.Condition(x) 
                       ? o.ThenMap(x) 
                       : o.ElseMap(x);

        public static Func<T, Bʹ> End<T, Bʹ, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o, 
            Func<ReturnType<Bʹ>> _) 
                where Tʹ : notnull, Bʹ 
                where Eʹ : notnull, Bʹ =>
                    x => o.Condition(x) 
                       ? o.ThenMap(x) 
                       : o.ElseMap(x);
    }
}
