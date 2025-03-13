namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;
    using static Syntax;

    public partial class ˣIf<I> : IIfAble<ˣIf<I>.Then<I>, I>
    {
        internal ˣIf(Func<I, bool> condition) =>
            Condition = condition;

        internal Func<I, bool> Condition { get; }

        public ˣ<Then<I>, ˣIf<I>> If(Func<I, bool> condition) =>
            new(this.Then(Identity), Syntax.If(condition));

        public ˣ<Then<I>, Is<Iʹ>> If<Iʹ>(Func<TypeCondition<I, Iʹ>> condition)
            where Iʹ : I =>
                new(this.Then(Identity), Syntax.If(condition));
    }

    public static partial class Syntax
    {
        public static ˣIf<I> AndIf<I>(
            this ˣIf<I> o,
            Func<I, bool> condition) =>
                new(i => o.Condition(i) && condition(i));

        public static ˣIf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this ˣIf<I> o,
            Func<TypeCondition<I, Iʹ>> _)
                where Iʹ : I
        {
            var condition = CreateTypeConditionalMap<I, Iʹ>();
            return new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
            {
                if (o.Condition(i) && condition(i, out iʹ))
                    return true;

                iʹ = default;
                return false;
            });
        }
        public static ˣIf<I>.Then<T> Then<I, T>(
            this ˣIf<I> o,
            Func<I, T> map) =>
                new((I i, [MaybeNullWhen(false)] out T t) =>
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
