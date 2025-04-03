namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    internal delegate bool ConditionalMap<in I, Iʹ>(
        I i, [MaybeNullWhen(false)] out Iʹ iʹ);

    public delegate Iʹ IsOfType<Iʹ>();

    public static class ObjectOfType<T>
    {
        public delegate (T, Tʹ) IsOfType<Tʹ>()
            where Tʹ : T;
    }

    public delegate T WithReturnType<T>();

    public sealed partial class Іf<I>
    {
        internal Іf(Func<I, bool> condition) =>
            Condition = condition;

        internal Func<I, bool> Condition { get; }
    }

    public sealed partial class Іf<I> {
    public sealed class Is<Iʹ> where Iʹ : I
    {
        internal Is(ConditionalMap<I, Iʹ> condition) =>
            Condition = condition;

        internal Is() : this(
            (I x, [MaybeNullWhen(false)] out Iʹ xʹ) =>
            {
                if (x is Iʹ sub)
                {
                    xʹ = sub;
                    return true;
                }

                xʹ = default;
                return false;
            })
        {
        }

        internal ConditionalMap<I, Iʹ> Condition { get; }
    }}

    public sealed partial class Іf<I> {
    public sealed partial class Then<T>
    {
        internal Then(ConditionalMap<I, T> conditionalMap) =>
            ConditionalMap = conditionalMap;

        internal ConditionalMap<I, T> ConditionalMap { get; }
    }}

    public sealed partial class Іf<I> {
    public sealed partial class Then<T> {
    public sealed partial class Else
    {
        internal Else(ConditionalMap<I, T> conditionalMap) =>
            ConditionalMap = conditionalMap;

        internal ConditionalMap<I, T> ConditionalMap { get; }
    }}}

    public sealed partial class Іf<I> {
    public sealed partial class Then<T> {
    public sealed partial class Else {
    public sealed class Then<E>
    {
        internal Then(
            ConditionalMap<I, T> conditionalMap,
            Func<I, E> elseMap)
        {
            ConditionalMap = conditionalMap;
            ElseMap = elseMap;
        }

        internal ConditionalMap<I, T> ConditionalMap { get; }
        internal Func<I, E> ElseMap { get; }
    }}}}

    public sealed class AdHocPolyMarker
    {
        private AdHocPolyMarker()
        {
        }
    }
}
