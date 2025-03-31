﻿namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<Iʹ> End<I, Iʹ, Tʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Tʹ> End<I, Iʹ, Tʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I, Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, Iʹ, Tʹ, B>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
