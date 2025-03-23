namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class ˣ
    {
        public sealed partial class If<I>
        {
            internal If(Func<I, bool> condition) =>
                Condition = condition;

            internal Func<I, bool> Condition { get; }
        }
    }

    public static partial class Syntax
    {
        public static ˣ.If<I> AndIf<I>(
            this ˣ.If<I> o,
            Func<I, bool> condition) =>
                new(i => o.Condition(i) && condition(i));

        public static ˣ.If<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this ˣ.If<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I
        {
            ˣ.If<I>.Is<Iʹ> is_I_Iʹ = new();
            return new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
            {
                if (o.Condition(i) && is_I_Iʹ.Condition(i, out iʹ))
                    return true;

                iʹ = default;
                return false;
            });
        }
        public static ˣ.If<I>.Then<T> Then<I, T>(
            this ˣ.If<I> o,
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

        public static ˣ<ˣ.If<I>, ˣ.If<I>> If<I>(
            this ˣ.If<I> o,
            Func<I, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>, ˣ.If<I>.Is<Iʹ>> If<I, Iʹ>(
            this ˣ.If<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    new(o, new());
    }
}
