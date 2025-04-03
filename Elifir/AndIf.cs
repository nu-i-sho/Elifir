namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static Іf<I> AndIf<I>(
            this Іf<I> o,
            Func<I, bool> condition) =>
                new (i => o.Condition(i) && condition(i));

        public static Іf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this Іf<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I
        {
            Іf<I>.Is<Iʹ> is_I_Iʹ = new ();
            return new ((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
            {
                if (o.Condition(i) && is_I_Iʹ.Condition(i, out iʹ))
                    return true;

                iʹ = default;
                return false;
            });
        }

        public static Іf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this Іf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new ((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
                    {
                        if (o.Condition(i, out iʹ) && condition(iʹ))
                            return true;

                        iʹ = default;
                        return false;
                    });

        public static Іf<I>.Is<Iʺ> AndIf<I, Iʹ, Iʺ>(
            this Іf<I>.Is<Iʹ> o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ
        {
            Іf<Iʹ>.Is<Iʺ> is_Iʹ_Iʺ = new ();
            return new ((I i, [MaybeNullWhen(false)] out Iʺ iʺ) =>
            {
                if (o.Condition(i, out Iʹ? iʹ) &&
                    is_Iʹ_Iʺ.Condition(iʹ, out iʺ))
                    return true;

                iʺ = default;
                return false;
            });
        }

        public static (ꞏꞏꞏ, Іf<I>) AndIf<ꞏꞏꞏ, I>(
            this (ꞏꞏꞏ, Іf<I>) o,
            Func<I, bool> condition) =>
                (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) AndIf<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) AndIf<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    (o.Item1, o.Item2.AndIf(condition));

        public static (ꞏꞏꞏ, Іf<I>.Is<Iʺ>) AndIf<ꞏꞏꞏ, I, Iʹ, Iʺ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    (o.Item1, o.Item2.AndIf(condition));
    }
}
