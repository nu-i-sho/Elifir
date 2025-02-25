//namespace Nuisho
//{
//    using static Elifir;

//    public static partial class Elifir
//    {
//        //public static A<T> If<T>(
//        //    Func<T, bool> condition) =>
//        //        new(condition);
//    }

//    internal static partial class Internal
//    {
//        public static Func<T, bool> And<T>(
//            this Func<T, bool> o,
//            Func<T, bool> condition) =>
//                x => o(x) && condition(x);

//        public static SubTypingCondition<T, ˣT> And<T, ˣT>(
//            this Func<T, bool> o,
//            SubTypingCondition<T, ˣT> condition)
//                where ˣT : T =>
//                    (T x, out ˣT ˣx) =>
//                    {
//                        if (o(x) && condition(x, out ˣx)) 
//                            return true;

//                        ˣx = default;
//                        return false;
//                    };
//    }
//}