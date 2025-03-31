﻿namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Іf<I>.Then<Tʹ> End<I, Iʹ, Tʹ, Eʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Iʹ : I
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Eʹ> End<I, Iʹ, Tʹ, Eʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, Iʹ, Tʹ, Eʹ, B>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
