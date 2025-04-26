namespace Nuisho.Elifir;

public static partial class Syntax
{
    public static Func<I, I> End<I, T>(
        this İf<I>.Then<T> o)
            where T : I =>
                i => o.ConditionalMap(i, out T? t) ? t : i;

    public static Func<I, T> End<I, T>(
        this İf<I>.Then<T> o,
        AdHocPolyMarker? _ = null)
            where I : T =>
                i => o.ConditionalMap(i, out T? t) ? t : i;

    public static Func<I, B> End<I, T, B>(
        this İf<I>.Then<T> o,
        WithReturnType<B> withReturnTypeB)
            where T : B
            where I : B =>
                i => o.ConditionalMap(i, out T? t) ? (B)t : i;

    public static Func<I, T> End<I, T, E>(
        this İf<I>.Then<T>.Else.Then<E> o)
            where E : T =>
                i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

    public static Func<I, E> End<I, T, E>(
        this İf<I>.Then<T>.Else.Then<E> o,
        AdHocPolyMarker? _ = null)
            where T : E =>
                i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

    public static Func<I, B> End<I, T, E, B>(
        this İf<I>.Then<T>.Else.Then<E> o,
        WithReturnType<B> _)
            where T : B
            where E : B =>
                i => o.ConditionalMap(i, out T? t) ? (B)t : o.ElseMap(i);
}
