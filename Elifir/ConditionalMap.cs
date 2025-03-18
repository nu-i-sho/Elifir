namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    internal delegate bool ConditionalMap<in I, Iʹ>(
        I i, [MaybeNullWhen(false)] out Iʹ iʹ);
}
