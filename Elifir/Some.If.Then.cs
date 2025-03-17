namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> Then<Some, I, T, Tʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o,
            Func<T, Tʹ> map) =>
                new(o.Prev,
                    new((I i, [MaybeNullWhen(false)] out Tʹ tʹ) =>
                    {
                        if (o.Next.ConditionalMap(i, out T? t))
                        {
                            tʹ = map(t);
                            return true;
                        }

                        tʹ = default;
                        return false;
                    }));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>> If<Some, I, T>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o,
            Func<T, bool> condition) =>
                new(o, new(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Is<Tʹ>> If<Some, I, T, Tʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o,
            Func<TypeCondition<T, Tʹ>> _)
                where Tʹ : T =>
                    new(o, new(CreateTypeConditionalMap<T, Tʹ>()));

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else> Else<Some, I, T>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o) =>
                new(o.Prev, new(o.Next.ConditionalMap));
    }
}
