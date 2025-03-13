namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;
    using static Syntax;

    public partial class ˣIf<I> {
    public class Is<Iʹ> : IIfAble<Then<Iʹ>, Iʹ> 
        where Iʹ : I
    {
        internal Is(ConditionalMap<I, Iʹ> condition) =>
            Condition = condition;

        internal ConditionalMap<I, Iʹ> Condition { get; }

        public ˣ<Then<Iʹ>, ˣIf<Iʹ>> If(Func<Iʹ, bool> condition) =>
            new(this.Then(Identity), Syntax.If(condition));

        public ˣ<Then<Iʹ>, ˣIf<Iʹ>.Is<Iʺ>> If<Iʺ>(Func<TypeCondition<Iʹ, Iʺ>> condition)
            where Iʺ : Iʹ =>
                new(this.Then(Identity), Syntax.If(condition));

    }}

    public static partial class Syntax
    {
        public static ˣIf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this ˣIf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
                    {
                        if (o.Condition(i, out iʹ) && condition(iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });

        public static ˣIf<I>.Is<Iʺ> AndIf<I, Iʹ, Iʺ>(
            this ˣIf<I>.Is<Iʹ> o,
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
        public static ˣIf<I>.Then<T> Then<I, Iʹ, T>(
            this ˣIf<I>.Is<Iʹ> o,
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
    }
}
