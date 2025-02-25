namespace Nuisho
{
    public static partial class Elifir
    {
        public static IfStage<T, T> If<T>(
            Func<T, bool> condition) =>
                new((T x, out T xʹ) =>
                {
                    if (condition(x))
                    {
                        xʹ = x;
                        return true;
                    }

                    xʹ = default;
                    return false;
                });
    }
}
