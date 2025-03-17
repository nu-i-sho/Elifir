namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Func<I, I>, ˣ.If<I>> If<I>(
            Func<I, bool> condition) =>
                new Func<I, I>(Identity)
                    .If(condition);
    }
}
