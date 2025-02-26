namespace Nuisho.Elifir
{
    public static partial class ˣ
    {
        public readonly partial struct If<I>
        {
            public readonly struct Is<Iʹ>(
                ConditionalMap<I, Iʹ> condition) where Iʹ : I
            {
                internal ConditionalMap<I, Iʹ> Condition => condition;
            }
        }
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Is<Iʹ> And<I, Iʹ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new((I i, out Iʹ iʹ) =>
                    {
                        if (o.Condition(i, out iʹ) 
                           && condition(iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });

        public static ˣ.If<I>.Is<Iʺ> And<I, Iʹ, Iʺ>(
            this ˣ.If<I>.Is<Iʹ> o,
            ConditionalMap<Iʹ, Iʺ> condition)
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    new((I i, out Iʺ iʺ) =>
                    {
                        if (o.Condition(i , out Iʹ iʹ) 
                           && condition(iʹ, out iʺ))
                            return true;

                        iʺ = default;
                        return false;
                    });

        public static ˣ.If<I>.Then<T> Then<I, Iʹ, T>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, T> map) 
                where Iʹ : I =>
                    new((I i, out T t) =>
                    {
                        if (o.Condition(i, out Iʹ iʹ))
                        {
                            t = map(iʹ);
                            return true;
                        }

                        t = default;
                        return false;
                    });
    }
}
