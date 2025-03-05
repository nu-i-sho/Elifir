namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class ˣ
    {
        public readonly partial struct If<I> {
        public readonly struct Is<Iʹ>(
            ConditionalMap<I, Iʹ> condition) where Iʹ : I
        {
            internal ConditionalMap<I, Iʹ> Condition => condition;
        }}
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new((I i, [NotNullWhen(true)]
                              [MaybeNullWhen(false)] 
                              out Iʹ iʹ) =>
                    {
                        if (o.Condition(i, out iʹ) 
                           && condition(iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });

        public static ˣ.If<I>.Is<Iʺ> AndIf<I, Iʹ, Iʺ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<ConditionalMap<Iʹ, Iʺ>> condition)
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    new((I i, [NotNullWhen(true)]
                              [MaybeNullWhen(false)] 
                              out Iʺ iʺ) =>
                    {
                        if (o.Condition(i,  out Iʹ? iʹ) && 
                            condition()(iʹ, out iʺ))
                                return true;

                        iʺ = default;
                        return false;
                    });

        public static ˣ.If<I>.Then<T> Then<I, Iʹ, T>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, T> map) 
                where Iʹ : I =>
                    new((I i, [NotNullWhen(true)]
                              [MaybeNullWhen(false)] 
                              out T t) =>
                    {
                        if (o.Condition(i, out Iʹ? iʹ))
                        {
                            t = map(iʹ);
                            return true;
                        }

                        t = default;
                        return false;
                    });

        public static ˣ<ˣ.If<I>.Then<Iʹ>, ˣ.If<Iʹ>> If<I, Iʹ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition) 
                where Iʹ : I =>
                    new(o.Then(Identity), If(condition));

        public static ˣ<ˣ.If<I>.Then<Iʹ>, ˣ.If<Iʹ>.Is<Iʺ>> If<I, Iʹ, Iʺ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<ConditionalMap<Iʹ, Iʺ>> condition) 
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    new(o.Then(Identity), If(condition));
    }
}
