namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Is<Iʹ>> And<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, bool> condition) 
                where Iʹ : I =>
                    new(o.Prev, 
                        o.Next.AndIf(condition));

        public static ˣ<Some, ˣ.If<I>.Is<Iʺ>> And<Some, I, Iʹ, Iʺ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            ConditionalMap<Iʹ, Iʺ> condition)
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    new(o.Prev, 
                        o.Next.AndIf(condition));

        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> Then<Some, I, Iʹ, Tʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, Tʹ> map)
                where Iʹ : I =>
                    new(o.Prev, 
                        o.Next.Then(map));
    }
}
