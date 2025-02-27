namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public readonly struct ReturnType<T>;

        public static ReturnType<T> WithReturn<T>() => 
            new();
    }
}
