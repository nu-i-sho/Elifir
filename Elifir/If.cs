namespace Nuisho
{
    public static partial class ˣ
    {
        public readonly partial record struct If<I>(
            Func<I, bool> Condition);
    }

    public static partial class Elifir
    {
        public static ˣ.If<I> And<I>(
            this ˣ.If<I> o,
            Func<I, bool> condition) =>
                new(o.Condition.And(condition));

        public static ˣ.If<I>.Is<Iʹ> And<I, Iʹ>(
            this ˣ.If<I> o,
            ConditionalMap<I, Iʹ> condition)
                where Iʹ : I =>
                    new(o.Condition.And(condition));

        public static ˣ.If<I>.Then<T> Then<I, T>(
            this ˣ.If<I> o,
            Func<I, T> thenMap) =>
                new((I i, out T t) =>
                {
                    if (o.Condition(i))
                    {
                        t = thenMap(i);
                        return true;
                    }

                    t = default;
                    return false;
                });
    }
}
