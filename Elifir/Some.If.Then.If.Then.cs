namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> End<Some, I, T, Tʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>> o)
                where T : Tʹ =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<T>> End<Some, I, T, Tʹ>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>> o,
            AdHocPolyMarker _ = default)
                where Tʹ : T =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, T, Tʹ, B>(
            this ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Then<Tʹ>> o,
            Func<B> withReturnB)
                where T  : B
                where Tʹ : B =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End(withReturnB)));
    }
}
