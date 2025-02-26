namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some>.Then<ˣ.If<I>> And<Some, I>(
            this ˣ<Some>.Then<ˣ.If<I>> o,
            Func<I, bool> condition) =>
                new(o.Prev, o.Next.And(condition));

        public static ˣ<Some>.Then<ˣ.If<I>.Is<Iʹ>> And<Some, I, Iʹ>(
            this ˣ<Some>.Then<ˣ.If<I>> o,
            ConditionalMap<I, Iʹ> condition)
                where Iʹ : I =>
                    new(o.Prev, o.Next.And(condition));

        public static ˣ<Some>.Then<ˣ.If<I>.Then<T>> Then<Some, I, T>(
            this ˣ<Some>.Then<ˣ.If<I>> o,
            Func<I, T> map) =>
                new(o.Prev, o.Next.Then(map));
    }
}
