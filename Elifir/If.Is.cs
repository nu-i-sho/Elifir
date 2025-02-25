namespace Nuisho
{
    public static partial class ˣ
    {
        public readonly partial record struct If<I>
        {
            public readonly record struct Is<Iʹ>(
                Elifir.ConditionalMap<I, Iʹ> Condition) where Iʹ : I;
        }
    }

    public static partial class Elifir
    {
        public static ˣ.If<I>.Is<Iʹ> And<I, Iʹ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new(o.Condition.And(condition));

        public static ˣ.If<I>.Is<Iʺ> And<I, Iʹ, Iʺ>(
            this ˣ.If<I>.Is<Iʹ> o,
            ConditionalMap<Iʹ, Iʺ> condition)
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    new(o.Condition.And(condition));

        public static ˣ.If<I>.Then<T> Then<I, Iʹ, T>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, T> thenMap) 
                where Iʹ : I =>
                    new((I i, out T t) =>
                    {
                        if (o.Condition(i, out Iʹ iʹ))
                        {
                            t = thenMap(iʹ);
                            return true;
                        }

                        t = default;
                        return false;
                    });
    }
}
