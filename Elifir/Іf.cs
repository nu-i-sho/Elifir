namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public sealed partial class Іf<I>
    {
        internal Іf(Func<I, bool> condition) =>
            Condition = condition;

        internal Func<I, bool> Condition { get; }
    }

    public static partial class Syntax
    {
        public static Іf<I> AndIf<I>(
            this Іf<I> o,
            Func<I, bool> condition) =>
                new(i => o.Condition(i) && condition(i));

        public static Іf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this Іf<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I
        {
            Іf<I>.Is<Iʹ> is_I_Iʹ = new();
            return new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
            {
                if (o.Condition(i) && is_I_Iʹ.Condition(i, out iʹ))
                    return true;

                iʹ = default;
                return false;
            });
        }
        public static Іf<I>.Then<T> Then<I, T>(
            this Іf<I> o,
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

        public static (Іf<I>, Іf<I>) If<I>(
            this Іf<I> o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static (Іf<I>, Іf<I>.Is<Iʹ>) If<I, Iʹ>(
            this Іf<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new());
    }
}
