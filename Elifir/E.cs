//namespace Nuisho
//{
//    using static Elifir;

//    public static partial class Elifir
//    {
//        public readonly record struct E<T, ˣT, Tʹ>(
//            SubTypingCondition<T, ˣT> Condition,
//            Func<ˣT, Tʹ> ThenMap) 
//                where ˣT : T;

//        public static E<T, ˣT, Tʺ> Then<T, ˣT, Tʹ, Tʺ>(
//            this E<T, ˣT, Tʹ> o,
//            Func<Tʹ, Tʺ> map)
//                where ˣT : T =>
//                    new(o.Condition,
//                        o.ThenMap.Then(map));

//        public static F<T, ˣT, Tʹ, Eʹ> Else<T, ˣT, Tʹ, Eʹ>(
//            this E<T, ˣT, Tʹ> o,
//            Func<T, Eʹ> map)
//                where ˣT  : T =>
//                    new(o.Condition, o.ThenMap, map);

//        public static Func<T, T> End<T, ˣT, Tʹ>(
//            this E<T, ˣT, Tʹ> o)
//                where ˣT  : T
//                where  Tʹ : T =>
//                    x => o.Condition(x, out ˣT ˣx)
//                       ? o.ThenMap(ˣx)
//                       : x;

//        public static Func<T, Tʹ> End<T, ˣT, Tʹ>(
//            this E<T, ˣT, Tʹ> o,
//            AdHocPolyMarker _ = default)
//                where ˣT : T
//                where  T : Tʹ =>
//                    x => o.Condition(x, out ˣT ˣx)
//                       ? o.ThenMap(ˣx)
//                       : x;
//    }

//    internal static partial class Internal
//    {

//        //public static F<T, ˣT, Tʹ> Else<T, ˣT, Tʹ, Eʹ>(
//        //    this E<T, ˣT, Tʹ> o,
//        //    Func<T, Eʹ> map)
//        //        where ˣT : T
//        //        where Eʹ : class, Tʹ =>
//        //            new(o.Condition, o.ThenMap, map);
//    }

//    internal static partial class InternalPlus
//    {
//        //public static F<T, ˣT, Tʹ> Else<T, ˣT, Tʹ, Eʹ>(
//        //    this E<T, ˣT, Tʹ> o, 
//        //    Func<T, Eʹ> map)
//        //        where ˣT  : T
//        //        where  Eʹ : struct, Tʹ =>
//        //            new(o.Condition, o.ThenMap, x => map(x));
//    }

//    internal static partial class InternalPlusPlus
//    {
//        //public static F<T, ˣT, Tʹ, Eʹ> Else<T, ˣT, Tʹ, Eʹ>(
//        //    this E<T, ˣT, Tʹ> o, 
//        //    Func<T, Eʹ> map,
//        //    AdHocPolyMarker _ = default)
//        //        where ˣT : T =>
//        //            new(o.Condition, o.ThenMap, map);
//    }
//}
