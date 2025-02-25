//namespace Nuisho
//{
//    public static partial class Elifir
//    {
//        public readonly record struct D<T, ˣT>(
//            SubTypingCondition<T, ˣT> Condition)
//                where ˣT : T;

//        public static D<T, ˣˣT> And<T, ˣT, ˣˣT>(
//            this D<T, ˣT> o,
//            SubTypingCondition<ˣT, ˣˣT> condition)
//                where  ˣT :  T
//                where ˣˣT : ˣT =>
//                    new(o.Condition.And(condition));

//        public static D<T, ˣT> And<T, ˣT>(
//            this D<T, ˣT> o,
//            Func<ˣT, bool> condition)
//                where ˣT : T =>
//                    new(o.Condition.And(condition));

//        public static E<T, ˣT, Tʹ> Then<T, ˣT, Tʹ>(
//            this D<T, ˣT> o,
//            Func<ˣT, Tʹ> map)
//                where ˣT : T =>
//                    new(o.Condition, map);
//    }
//}