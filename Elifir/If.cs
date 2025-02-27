namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class ˣ
    {
        public readonly partial struct If<I>(
            Func<I, bool> condition)
        {
            internal Func<I, bool> Condition => condition;
        }
    }

    public static partial class Syntax
    {
        public static ˣ.If<I> And<I>(
            this ˣ.If<I> o,
            Func<I, bool> condition) =>
                new(i => o.Condition(i) && condition(i));

        public static ˣ.If<I>.Is<Iʹ> And<I, Iʹ>(
            this ˣ.If<I> o,
            ConditionalMap<I, Iʹ> condition)
                where Iʹ : I =>
                    new((I i, [NotNullWhen(true)]
                              [MaybeNullWhen(false)] 
                              out Iʹ iʹ) =>
                    {
                        if (o.Condition(i) && 
                              condition(i, out iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });
            
        public static ˣ.If<I>.Then<T> Then<I, T>(
            this ˣ.If<I> o,
            Func<I, T> map) =>
                new((I i, [NotNullWhen(true)]
                          [MaybeNullWhen(false)] out T t) =>
                {
                    if (o.Condition(i))
                    {
                        t = map(i);
                        return true;
                    }

                    t = default;
                    return false;
                });
    }
}
