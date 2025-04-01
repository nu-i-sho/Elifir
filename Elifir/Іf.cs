namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

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
    }
}
