﻿namespace Nuisho.Elifir
{
    public delegate T WithReturnType<T>();

    public static partial class Syntax
    {
        public static T WithReturn<T>() => 
            throw new NotSupportedException("It is not for call !!!");
    }
}
