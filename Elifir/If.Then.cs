namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public partial class ˣIf<I> {
    public partial class Then<T> : IIfAble<Then<T>, T>
    {
        internal Then(ConditionalMap<I, T> conditionalMap) =>
            ConditionalMap = conditionalMap;

        internal ConditionalMap<I, T> ConditionalMap { get; }

        public ˣ<Then<T>, ˣIf<T>> If(Func<T, bool> condition) =>
            new(this, Syntax.If(condition));

        public ˣ<Then<T>, ˣIf<T>.Is<Tʹ>> If<Tʹ>(Func<TypeCondition<T, Tʹ>> condition)
            where Tʹ : T =>
                new(this, Syntax.If(condition));
    }}

    public static partial class Syntax
    {
        public static ˣIf<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this ˣIf<I>.Then<T> o,
            Func<T, Tʹ> map) =>
                new((I i, [MaybeNullWhen(false)] out Tʹ tʹ) =>
                {
                    if (o.ConditionalMap(i, out T? t))
                    {
                        tʹ = map(t);
                        return true;
                    }

                    tʹ = default;
                    return false;
                });

        public static ˣIf<I>.Then<T>.Else Else<I, T>(
            this ˣIf<I>.Then<T> o) =>
                new(o.ConditionalMap);

        public static Func<I, I> End<I, T>(
            this ˣIf<I>.Then<T> o)
                where T : I =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, T> End<I, T>(
            this ˣIf<I>.Then<T> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, B> End<I, T, B>(
            this ˣIf<I>.Then<T> o,
            Func<ReturnType<B>> _)
                where T : B
                where I : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : i;
    }
}
