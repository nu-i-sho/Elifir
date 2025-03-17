using System.Diagnostics.CodeAnalysis;

namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Is<Iʹ>> AndIf<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new(o.Prev,
                        new((I i, [MaybeNullWhen(false)] out Iʹ iʹ) =>
                        {
                            if (o.Next.Condition(i, out iʹ) && condition(iʹ))
                                return true;

                            iʹ = default;
                            return false;
                        }));

        public static ˣ<Some, ˣ.If<I>.Is<Iʺ>> AndIf<Some, I, Iʹ, Iʺ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<TypeCondition<Iʹ, Iʺ>> _)
                where Iʹ : I 
                where Iʺ : Iʹ
        {
            var condition = CreateTypeConditionalMap<Iʹ, Iʺ>();
            return new(o.Prev, 
                       new((I i, [MaybeNullWhen(false)] out Iʺ iʺ) =>
                        {
                            if (o.Next.Condition(i, out Iʹ? iʹ) &&
                                  condition(iʹ, out iʺ))
                                return true;

                            iʺ = default;
                            return false;
                        }));
        }

        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> Then<Some, I, Iʹ, Tʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, Tʹ> map)
                where Iʹ : I =>
                    new(o.Prev,
                        new((I i, [MaybeNullWhen(false)] out Tʹ tʹ) =>
                        {
                            if (o.Next.Condition(i, out Iʹ? iʹ))
                            {
                                tʹ = map(iʹ);
                                return true;
                            }

                            tʹ = default;
                            return false;
                        }));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<Iʹ>>, ˣ.If<Iʹ>> If<Some, I, Iʹ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                    new(o.Then(Identity), 
                        new(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<Iʹ>>, ˣ.If<Iʹ>.Is<Iʺ>> If<Some, I, Iʹ, Iʺ>(
            this ˣ<Some, ˣ.If<I>.Is<Iʹ>> o,
            Func<TypeCondition<Iʹ, Iʺ>> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    new(o.Then(Identity), 
                        new(CreateTypeConditionalMap<Iʹ, Iʺ>()));
    }
}
