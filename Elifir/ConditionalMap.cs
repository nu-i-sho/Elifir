namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    internal delegate bool ConditionalMap<in I, Iʹ>(
        I i, [MaybeNullWhen(false)] out Iʹ iʹ);

    public static partial class Syntax
    {
        static ConditionalMap<I, Iʹ> CreateTypeConditionalMap<I, Iʹ>()
            where Iʹ : I =>
                (I x, [MaybeNullWhen(false)] out Iʹ xʹ) =>
                {
                    if (x is Iʹ sub)
                    {
                        xʹ = sub;
                        return true;
                    }

                    xʹ = default;
                    return false;
                };
    }
}
