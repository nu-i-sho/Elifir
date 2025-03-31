﻿namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<T> End<I, T, E>(
            this (Іf<I>, Іf<I>.Then<T>.Else.Then<E>) o)
                where E : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<E> End<I, T, E>(
            this (Іf<I>, Іf<I>.Then<T>.Else.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, E, B>(
            this (Іf<I>, Іf<I>.Then<T>.Else.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
