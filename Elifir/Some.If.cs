namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>> AndIf<Some, I>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, bool> condition) =>
                new(o.Prev, new(i => o.Next.Condition(i) && condition(i)));

        public static ˣ<Some, ˣ.If<I>.Is<Iʹ>> AndIf<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<TypeCondition<I, Iʹ>> _)
                where Iʹ : I
        {
            var condition = CreateTypeConditionalMap<I, Iʹ>();
            return new(o.Prev,  
                       new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
                       {
                            if (o.Next.Condition(i) && condition(i, out iʹ))
                                return true;

                            iʹ = default;
                            return false;
                       }));
        }

        public static ˣ<Some, ˣ.If<I>.Then<T>> Then<Some, I, T>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, T> map) =>
                new(o.Prev, 
                    new((I i, [MaybeNullWhen(false)] out T t) =>
                    {
                        if (o.Next.Condition(i))
                        {
                            t = map(i);
                            return true;
                        }

                        t = default;
                        return false;
                    }));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<I>>, ˣ.If<I>> If<Some, I>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<I, bool> condition) =>
                new(o.Then(Identity), new(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<I>>, ˣ.If<I>.Is<Iʹ>> If<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>> o,
            Func<TypeCondition<I, Iʹ>> _)
                where Iʹ : I =>
                    new(o.Then(Identity), new(CreateTypeConditionalMap<I, Iʹ>()));
    }
}
