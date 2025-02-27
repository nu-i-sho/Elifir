namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        //public static ˣ.If<I>.Then<T>.Else<E> End<I, T, E, Tʹ>(
        //    this ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>> o)
        //        where Tʹ : E =>
        //            o.Prev.Then(o.Next.End());

        //public static ˣ.If<I>.Then<T>.Else<Tʹ> End<I, T, E, Tʹ>(
        //    this ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>> o,
        //    AdHocPolyMarker _ = default)
        //        where E : Tʹ =>
        //            o.Prev.Then(o.Next.End());

        //public static ˣ.If<I>.Then<T>.Else<B> End<I, T, E, Tʹ, B>(
        //    this ˣ<ˣ.If<I>.Then<T>.Else<E>>.Then<ˣ.If<E>.Then<Tʹ>> o,
        //    ReturnType<B> withReturnB)
        //        where E  : B
        //        where Tʹ : B =>
        //            o.Prev.Then(o.Next.End(withReturnB));
    }
}
