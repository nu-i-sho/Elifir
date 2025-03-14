namespace Nuisho.Elifir
{
    public sealed class TypeCondition<I, Iʹ>
        where Iʹ : I
    {
        private TypeCondition()
        {
        }
    }

    public static class Object<T>
    {
        public static TypeCondition<T, Tʹ> Is<Tʹ>()
            where Tʹ : T => throw new NotSupportedException("It is not for call !!!");
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Is<Iʹ> If<I, Iʹ>(
            Func<TypeCondition<I, Iʹ>> _)
                where Iʹ : I =>
                    new(CreateTypeConditionalMap<I, Iʹ>());
    }
}