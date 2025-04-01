namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static Іf<I>.Is<Iʹ> AndIf<I, Iʹ>(
            this Іf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
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
            Іf<Iʹ>.Is<Iʺ> is_Iʹ_Iʺ = new();
            return new((I i, [MaybeNullWhen(false)] out Iʺ iʺ) =>
            {
                if (o.Condition(i, out Iʹ? iʹ) &&
                    is_Iʹ_Iʺ.Condition(iʹ, out iʺ))
                    return true;

                iʺ = default;
                return false;
            });
        }

        public static Іf<I>.Then<T> Then<I, Iʹ, T>(
            this Іf<I>.Is<Iʹ> o,
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

        public static (Іf<I>.Is<Iʹ>, Іf<Iʹ>) If<I, Iʹ>(
            this Іf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition) 
                where Iʹ : I =>
                    (o, If(condition));

        public static (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Is<Iʺ>) If<I, Iʹ, Iʺ>(
            this Іf<I>.Is<Iʹ> o,
            IsOfType<Iʺ> condition) 
                where Iʹ : I 
                where Iʺ : Iʹ =>
                    (o, new());
    }
}
