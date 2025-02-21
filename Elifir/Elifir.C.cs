namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct C<T, Tʹ, Eʹ>(
            Func<T, bool> Condition,
            Func<T, Tʹ> ThenMap,
            Func<T, Eʹ> ElseMap);

        public static Func<T, Tʹ> End<T, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o)
                where Eʹ : Tʹ =>
                    x => o.Condition(x)
                       ? o.ThenMap(x)
                       : o.ElseMap(x);

        public static Func<T, Eʹ> End<T, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o,
            AdHocPolyMarker _ = default)
                where Tʹ : Eʹ =>
                    x => o.Condition(x)
                       ? o.ThenMap(x)
                       : o.ElseMap(x);

        public static Func<T, Bʹ> End<T, Bʹ, Tʹ, Eʹ>(
            this C<T, Tʹ, Eʹ> o, 
            Func<ReturnType<Bʹ>> _) 
                where Tʹ : Bʹ 
                where Eʹ : Bʹ =>
                    x => o.Condition(x) 
                       ? o.ThenMap(x) 
                       : o.ElseMap(x);
    }

    //public static partial class ElifirPlus
    //{
    //    public static void Test()
    //    {
    //        var _1 = If(ATrue).Then(AToB).Else(AToC).End();
    //        var _2 = If(ATrue).Then(AToC).Else(AToB).End();
    //        var _3 = If(ATrue).Then(AToC).Else(AToD).End(WithReturn<B>);
    //        var _4 = If(ATrue).Then(AToC).Else(AToC).End(); // !!!
    //    }

    //    public static Func<A, bool> ATrue = _ => true;
    //    public static Func<A, B> AToB = _ => new();
    //    public static Func<A, C> AToC = _ => new();
    //    public static Func<A, D> AToD = _ => new();

    //    public class A;
    //    public class B;
    //    public class C : B;
    //    public class D : B;
    //}
}
