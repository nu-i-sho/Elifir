namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct IfStage<T, Tʹ>(
            ConditionalMap<T, Tʹ> ConditionalMap);

        public static IfStage<T, Tʹ> And<T, Tʹ>(
            this IfStage<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                new((T x, out Tʹ xʹ) =>
                {
                    if (o.ConditionalMap(x, out xʹ) && condition(xʹ))
                        return true;

                    xʹ = default;
                    return false;
                });

        public static IfStage<T, Tʺ> And<T, Tʹ, Tʺ>(
            this IfStage<T, Tʹ> o,
            ConditionalMap<Tʹ, Tʺ> conditionalMap) 
                where Tʺ : Tʹ =>
                    new((T x, out Tʺ xʺ) =>
                    {
                        if (o.ConditionalMap(x,  out Tʹ xʹ) && 
                              conditionalMap(xʹ, out xʺ))
                                return true;

                        xʺ = default;
                        return false;
                    });


        public static IfThenStage<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this IfStage<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                new((T x, out Tʺ xʺ) =>
                {
                    if (o.ConditionalMap(x, out Tʹ xʹ))
                    {
                        xʺ = map(xʹ);
                        return true;
                    }

                    xʺ = default;
                    return false;
                });
    }
}
