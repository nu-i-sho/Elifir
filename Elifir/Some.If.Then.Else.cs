﻿namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<T>.Else.Then<E>> Then<Some, I, T, E>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else> o,
            Func<I, E> map) =>
                new(o.Prev,
                    o.Next.Then(map));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else>, ˣ.If<I>> If<Some, I, T>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else> o,
            Func<I, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>.Else>, ˣ.If<I>.Is<E>> If<Some, I, T, E>(
            this ˣ<Some, ˣ.If<I>.Then<T>.Else> o,
            IsOfType<E> condition)
                where E : I =>
                    new(o, new());
    }
}
