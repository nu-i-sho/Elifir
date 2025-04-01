namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this Іf<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new(o.ConditionalMap, elseMap);
    }
}
