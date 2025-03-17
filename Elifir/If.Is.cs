namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class ˣ
    {
        public sealed partial class If<I> {
        public sealed class Is<Iʹ> where Iʹ : I
        {
            internal Is(ConditionalMap<I, Iʹ> condition) =>
                Condition = condition;

            internal ConditionalMap<I, Iʹ> Condition { get; }
        }}
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
                    {
                        if (o.Condition(i, out iʹ) && condition(iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });

        public static ˣ.If<I>.Is<Iʺ> AndIf<I, Iʹ, Iʺ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<TypeCondition<Iʹ, Iʺ>> _)
                where Iʹ : I
                where Iʺ : Iʹ
        {
            var condition = CreateTypeConditionalMap<Iʹ, Iʺ>();
            return new((I i, [MaybeNullWhen(false)] out Iʺ iʺ) =>
            {
                if (o.Condition(i, out Iʹ? iʹ) &&
                      condition(iʹ, out iʺ))
                    return true;

                iʺ = default;
                return false;
            });
        }
        public static ˣ.If<I>.Then<T> Then<I, Iʹ, T>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, T> map) 
                where Iʹ : I =>
                    new((I i, [MaybeNullWhen(false)] out T t) =>
                    {
                        if (o.Condition(i, out Iʹ? iʹ))
                        {
                            t = map(iʹ);
                            return true;
                        }

                        t = default;
                        return false;
                    });

        public static ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>> If<I, Iʹ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition) 
                where Iʹ : I =>
                    new(o, If(condition));

        public static ˣ<ˣ.If<I>.Is<Iʹ>, ˣ.If<Iʹ>.Is<Iʺ>> If<I, Iʹ, Iʺ>(
            this ˣ.If<I>.Is<Iʹ> o,
            Func<TypeCondition<Iʹ, Iʺ>> condition) 
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    new(o, If(condition));
    }
}
