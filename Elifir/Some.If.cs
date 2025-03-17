namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>> AndIf<Some, I>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, bool> condition) =>
                new(o.Prev, 
                    o.Next.AndIf(condition));

        public static ˣ<Some, ˣ.If<I>.Is<Iʹ>> AndIf<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<TypeCondition<I, Iʹ>> condition)
                where Iʹ : I =>
                    new(o.Prev, 
                        o.Next.AndIf(condition));

        public static ˣ<Some, ˣ.If<I>.Then<T>> Then<Some, I, T>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, T> map) =>
                new(o.Prev, 
                    o.Next.Then(map));

        public static ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>> If<Some, I>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Is<Iʹ>> If<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<TypeCondition<I, Iʹ>> condition)
                where Iʹ : I =>
                    new(o, If(condition));
    }
}
