namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<Eʹ>> Then<Some, I, T, E, Eʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            Func<E, Eʹ> map) =>
                new(o.Prev, new(o.Next.ConditionalMap, o.Next.ElseMap.Then(map)));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>> If<Some, I, T, E>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            Func<E, bool> condition) =>
                new(o, new(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>>, ˣ.If<E>.Is<Eʹ>> If<Some, I, T, E, Eʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> o,
            Func<TypeCondition<E, Eʹ>> _)
                where Eʹ : E =>
                    new(o, new(CreateTypeConditionalMap<E, Eʹ>()));
    }
}