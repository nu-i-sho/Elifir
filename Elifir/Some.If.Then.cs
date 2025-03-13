namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣIf<I>.Then<Tʹ>> Then<Some, I, T, Tʹ>(
            this ˣ<Some, ˣIf<I>.Then<T>> o,
            Func<T, Tʹ> map) =>
                new(o.Prev, 
                    o.Next.Then(map));

        public static ˣ<ˣ<Some, ˣIf<I>.Then<T>>, ˣIf<T>> If<Some, I, T>(
            this ˣ<Some, ˣIf<I>.Then<T>> o,
            Func<T, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some, ˣIf<I>.Then<T>>, ˣIf<T>.Is<Tʹ>> If<Some, I, T, Tʹ>(
            this ˣ<Some, ˣIf<I>.Then<T>> o,
            Func<TypeCondition<T, Tʹ>> condition)
                where Tʹ : T =>
                    new(o, If(condition));

        public static ˣ<Some, ˣIf<I>.Then<T>.Else> Else<Some, I, T>(
            this ˣ<Some, ˣIf<I>.Then<T>> o) =>
                new(o.Prev, 
                    o.Next.Else());
    }
}
