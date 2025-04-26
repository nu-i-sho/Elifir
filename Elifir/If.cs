namespace Nuisho.Elifir;

public static partial class Syntax
{
    public static İf<I> If<I>(
        Func<I, bool> condition) =>
            new (condition);

    public static İf<I>.Is<Iʹ> If<I, Iʹ>(
        ObjectOfType<I>.IsOfType<Iʹ> condition)
            where Iʹ : I =>
                new ();
}