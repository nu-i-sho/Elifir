namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public sealed class ReturnType<T>
        {
            private ReturnType() 
            { 
            }
        }

        public static ReturnType<T> WithReturn<T>() => 
            throw new NotSupportedException("It is not for call !!!");
    }
}
