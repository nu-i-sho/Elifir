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
            Func<ConditionalMap<I, Iʹ>> condition)
                where Iʹ : I =>
                    new(o.Prev, 
                        o.Next.AndIf(condition));

        public static ˣ<Some, ˣ.If<I>.Then<T>> Then<Some, I, T>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, T> map) =>
                new(o.Prev, 
                    o.Next.Then(map));
    }
}
