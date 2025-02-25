namespace Nuisho
{
    public static partial class Elifir
    {
        public delegate bool ConditionalMap<in T, Tʹ>(T x, out Tʹ xʹ);

        public static class Obj<T>
        {
            public static ConditionalMap<T, ˣT> Is<ˣT>()
                where ˣT : T =>
                    (T x, out ˣT ˣx) =>
                    {
                        if (x is ˣT sub)
                        {
                            ˣx = sub;
                            return true;
                        }

                        ˣx = default;
                        return false;
                    };
        }

        internal static ConditionalMap<T, Tʹ> And<T, Tʹ>(
            this ConditionalMap<T, Tʹ> o,
            Func<Tʹ, bool> condition)
                where Tʹ : T =>
                    new((T x, out Tʹ xʹ) =>
                    {
                        if (o(x, out xʹ) && condition(xʹ))
                            return true;

                        xʹ = default;
                        return false;
                    });

        internal static ConditionalMap<T, Tʺ> And<T, Tʹ, Tʺ>(
            this ConditionalMap<T, Tʹ> o,
            ConditionalMap<Tʹ, Tʺ> condition)
                where Tʹ : T 
                where Tʺ : Tʹ =>
                    new((T x, out Tʺ xʺ) =>
                    {
                        if (o(x, out Tʹ xʹ) && condition(xʹ, out xʺ))
                            return true;

                        xʺ = default;
                        return false;
                    });

        public static ˣ.If<I>.Is<Iʹ> If<I, Iʹ>(
            ConditionalMap<I, Iʹ> condition)
                where Iʹ : I =>
                    new(condition);
    }
}
