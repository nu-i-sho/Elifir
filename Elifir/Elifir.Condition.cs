namespace Nuisho
{
    public static partial class Elifir
    {
        public static Func<T, bool> And<T>(
                 this Func<T, bool> o,
                      Func<T, bool> condition) =>
                            x => o(x) && condition(x);

        public static A<T> If<T>(Func<T, bool> condition) =>
            new(condition);
    }
}