namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ.If<I> If<I>(
            Func<I, bool> condition) =>
                new(condition);
    }
}
