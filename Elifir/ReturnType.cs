namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly struct ReturnType<T>;

        public static ReturnType<T> WithReturn<T>() => 
            new();
    }
}
