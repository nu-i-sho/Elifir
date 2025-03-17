namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<I>> End<Some, I, T>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>> o)
                where T : I =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<T>> End<Some, I, T>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End()));

        public static ˣ<Some, ˣ.If<I>.Then<B>> End<Some, I, T, B>(
            this ˣ<ˣ<Some, ˣ.If<I>>, ˣ.If<I>.Then<T>> o,
            Func<ReturnType<B>> withReturnTypeB)
                where I  : B
                where T : B =>
                    new(o.Prev.Prev, 
                        o.Prev.Next.Then(
                             o.Next.End(withReturnTypeB)));
    }
}
