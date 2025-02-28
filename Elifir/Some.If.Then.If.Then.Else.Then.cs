namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> End<Some, I, T, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>.Else.Then<Eʹ>> o)
                where Eʹ : Tʹ =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<Eʹ>> End<Some, I, T, Tʹ, Eʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>.Else.Then<Eʹ>> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, T, Tʹ, Eʹ, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>.Else.Then<Eʹ>> o,
            ReturnType<B> withReturnB)
                where Tʹ : B
                where Eʹ : B =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End(withReturnB)));
    }
}