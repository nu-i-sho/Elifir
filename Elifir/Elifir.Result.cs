namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly struct Result<T>
        { 
            private Result(T value, bool converted)
            {
                Value = value;
                IsConverted = converted;
            }

            public static Func<T, Result<T>> Original => value => new(value, false);
            public static Func<T, Result<T>> Converted => value => new(value, true);

            public T Value { get; }

            public bool IsConverted { get; }
        }
    }
}
