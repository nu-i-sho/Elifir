namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class ˣ
    {
        public partial class If<I> {
        public partial class Then<T>
        {
            internal Then(ConditionalMap<I, T> conditionalMap) =>
                ConditionalMap = conditionalMap;

            internal ConditionalMap<I, T> ConditionalMap { get; }
        }}
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this ˣ.If<I>.Then<T> o,
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

        public static ˣ<ˣ.If<I>.Then<T>, ˣ.If<T>> If<I, T>(
            this ˣ.If<I>.Then<T> o,
            Func<T, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>.Then<T>, ˣ.If<T>.Is<Tʹ>> If<I, T, Tʹ>(
            this ˣ.If<I>.Then<T> o,
            Func<TypeCondition<T, Tʹ>> condition)
                where Tʹ : T =>
                    new(o, If(condition));

        public static ˣ.If<I>.Then<T>.Else Else<I, T>(
            this ˣ.If<I>.Then<T> o) =>
                new(o.ConditionalMap);

        public static Func<I, I> End<I, T>(
            this ˣ.If<I>.Then<T> o)
                where T : I =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, T> End<I, T>(
            this ˣ.If<I>.Then<T> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, B> End<I, T, B>(
            this ˣ.If<I>.Then<T> o,
            Func<ReturnType<B>> _)
                where T : B
                where I : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : i;
    }
}
