namespace Nuisho
{
    using static Elifir;

    public static partial class Elifir
    {
        public readonly record struct E<T, ˣT, Tʹ>(
            Func<ˣT, Tʹ> ThenMap) 
                where ˣT : T;

        public static Func<T, T> End<T, ˣT, Tʹ>(this E<T, ˣT, Tʹ> o) 
            where ˣT  : T 
            where  Tʹ : T =>
                x => x is ˣT ˣx ? o.ThenMap(ˣx) : x;

        public static F<T, ˣT, Tʹ> Else<T, ˣT, Tʹ, Eʹ>(
            this E<T, ˣT, Tʹ> o, 
            Func<T, Eʹ> map)
                where ˣT  : T
                where  Eʹ : class, Tʹ =>
                    new(o.ThenMap, map);
    }

    public static partial class ElifirPlus
    {
        public static F<T, ˣT, Tʹ> Else<T, ˣT, Tʹ, Eʹ>(
            this E<T, ˣT, Tʹ> o, 
            Func<T, Eʹ> map)
                where ˣT  : T
                where  Eʹ : struct, Tʹ =>
                    new(o.ThenMap, x => map(x));
    }

    public static partial class ElifirPlusPlus
    {
        public static F<T, ˣT, Tʹ, Eʹ> Else<T, ˣT, Tʹ, Eʹ>(
            this E<T, ˣT, Tʹ> o, 
            Func<T, Eʹ> map,
            AdHocPolyMarker _ = default)
                where ˣT : T =>
                    new(o.ThenMap, map);
    }
}
