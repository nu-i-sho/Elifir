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

        public static IfStage<T, Tʹ> If<T, Tʹ>(
            ConditionalMap<T, Tʹ> conditionalMap)
                where Tʹ : T =>
                    new(conditionalMap);
    }
}
