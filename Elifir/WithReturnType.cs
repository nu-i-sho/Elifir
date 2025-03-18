namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public delegate T WithReturnType<T>();

        public static T WithReturn<T>() => 
            throw new NotSupportedException("It is not for call !!!");
    }
}
