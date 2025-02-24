namespace Nuisho
{
    using static Elifir;

    public static partial class Elifir
    {
        public delegate bool SubTypingCondition<T, ˣT>(T x, out ˣT ˣx)
            where ˣT : T;

        public static class Obj<T>
        {
            public static SubTypingCondition<T, ˣT> Is<ˣT>()
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

        public static D<T, ˣT> If<T, ˣT>(
            SubTypingCondition<T, ˣT> condition) 
                where ˣT : T => 
                    new(condition);
    }

    internal static partial class Internal
    {
        public static SubTypingCondition<T, ˣˣT> And<T, ˣT, ˣˣT>(
            this SubTypingCondition<T, ˣT> o,
            SubTypingCondition<ˣT, ˣˣT> condition)
                where  ˣT :  T
                where ˣˣT : ˣT =>
                    (T x, out ˣˣT ˣˣx) =>
                    {
                        if (o(x, out ˣT ˣx))
                            return condition(ˣx, out ˣˣx);
                        
                        ˣˣx = default;
                        return false;
                    };

        public static SubTypingCondition<T, ˣT> And<T, ˣT>(
            this SubTypingCondition<T, ˣT> o,
            Func<ˣT, bool> condition)
                where ˣT : T =>
                    (T x, out ˣT ˣx) => o(x, out ˣx) && condition(ˣx);
    }
}
