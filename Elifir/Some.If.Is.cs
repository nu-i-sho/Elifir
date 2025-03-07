namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Is<Iʹ>> AndIf<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, bool> condition) 
                where Iʹ : I =>
                    new(o.Prev, 
                        o.Next.AndIf(condition));

        public static ˣ<Some, ˣ.If<I>.Is<Iʺ>> AndIf<Some, I, Iʹ, Iʺ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<TypeCondition<Iʹ, Iʺ>> condition,
            AdHocPolyMarker _ = default)
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

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<Iʹ>>, ˣ.If<Iʹ>> If<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new(o.Then(Identity), If(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<Iʹ>>, ˣ.If<Iʹ>.Is<Iʺ>> If<Some, I, Iʹ, Iʺ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<TypeCondition<Iʹ, Iʺ>> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    new(o.Then(Identity), If(condition));
    }
}
