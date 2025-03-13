﻿namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣIf<I> If<I>(
            Func<I, bool> condition) =>
                new(condition);
    }
}
