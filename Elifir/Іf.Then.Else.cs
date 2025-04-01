namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this Іf<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new(o.ConditionalMap, elseMap);

        public static (Іf<I>.Then<T>.Else, Іf<I>) If<I, T>(
            this Іf<I>.Then<T>.Else o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static (Іf<I>.Then<T>.Else, Іf<I>.Is<Iʹ>) If<I, T, Iʹ>(
            this Іf<I>.Then<T>.Else o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new());
    }
}
