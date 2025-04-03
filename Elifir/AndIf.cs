namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static İf<I> AndIf<I>(
            this İf<I> o,
            Func<I, bool> condition) =>
                new (i => o.Condition(i) && condition(i));

        public static İf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this İf<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I
        {
            İf<I>.Is<Iʹ> is_I_Iʹ = new ();
            return new ((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
            {
                if (o.Condition(i) && is_I_Iʹ.Condition(i, out iʹ))
                    return true;

                iʹ = default;
                return false;
            });
        }

        public static İf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this İf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new ((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
                    {
                        if (o.Condition(i, out iʹ) && condition(iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });

        public static İf<I>.Is<Iʺ> AndIf<I, Iʹ, Iʺ>(
            this İf<I>.Is<Iʹ> o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ
        {
            İf<Iʹ>.Is<Iʺ> is_Iʹ_Iʺ = new ();
            return new ((I i, [MaybeNullWhen(false)] out Iʺ iʺ) =>
            {
                if (o.Condition(i, out Iʹ? iʹ) &&
                    is_Iʹ_Iʺ.Condition(iʹ, out iʺ))
                    return true;

                iʺ = default;
                return false;
            });
        }

        public static (ꞏꞏꞏ, İf<I>) AndIf<ꞏꞏꞏ, I>(
            this (ꞏꞏꞏ, İf<I>) o,
            Func<I, bool> condition) =>
                (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, İf<I>.Is<Iʹ>) AndIf<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, İf<I>) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, İf<I>.Is<Iʹ>) AndIf<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, İf<I>.Is<Iʹ>) o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, İf<I>.Is<Iʺ>) AndIf<ꞏꞏꞏ, I, Iʹ, Iʺ>(
            this (ꞏꞏꞏ, İf<I>.Is<Iʹ>) o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    (o.Item1, o.Item2.AndIf(condition));
    }
}
