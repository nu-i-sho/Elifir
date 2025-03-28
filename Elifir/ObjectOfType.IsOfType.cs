﻿namespace Nuisho.Elifir
{
    public static class ObjectOfType<T>
    {
        public delegate (T, Tʹ) IsOfType<Tʹ>()
            where Tʹ : T;
    }

    public static partial class Syntax
    {
        public static class Object<T>
        {
            public static (T, Tʹ) Is<Tʹ>()
                where Tʹ : T => throw new NotSupportedException("It is not for call !!!");
        }

        public static ˣ.If<I>.Is<Iʹ> If<I, Iʹ>(
            ObjectOfType<I>.IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    new();
    }
}
