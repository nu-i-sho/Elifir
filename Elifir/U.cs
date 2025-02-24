namespace Nuisho
{
    using static Elifir;


    public static partial class Elifir
    {
        public readonly record struct U<TChild, TParent>(
            TChild Child,
            TParent Parent);

        public static U<A<T>, TParent> And<TParent, T>(
            this U<A<T>, TParent> o,
            Func<T, bool> condition) =>
                new(new(o.Child.Condition.And(condition)), 
                    o.Parent);

        public static U<B<T, Tʹ>, TParent> Then<TParent, T, Tʹ>(
            this U<A<T>, TParent> o,
            Func<T, Tʹ> map) =>
                new(o.Child.Then(map),
                    o.Parent);

        public static U<B<T, Tʺ>, TParent> Then<TParent, T, Tʹ, Tʺ>(
            this U<B<T, Tʹ>, TParent> o,
            Func<Tʹ, Tʺ> map) =>
                new(new(o.Child.Condition, 
                        o.Child.ThenMap.Then(map)),
                    o.Parent);

        public static U<A<Tʹ>, U<B<T, Tʹ>, TParent>> ThenIf<TParent, T, Tʹ>(
            this U<B<T, Tʹ>, TParent> o,
            Func<Tʹ, bool> condition) =>
                new(new(condition),
                    o);

        public static Func<T, Tʹ> End<T, Tʹ, Tʺ>(
            this U<B<Tʹ, Tʺ>, Func<T, Tʹ>> o)
                where Tʺ : Tʹ =>
                    o.Parent.Then(o.Child.End());

        public static U<B<T, Tʹ>, TParent> End<TParent, T, Tʹ, Tʺ>(
            this U<B<Tʹ, Tʺ>, U<B<T, Tʹ>, TParent>> o)
                where Tʺ : Tʹ =>
                    o.Parent.Then(o.Child.End());

        public static U<C<T, Tʹ, Eʹ>, TParent> End<TParent, T, Tʹ, Eʹ, Tʺ>(
            this U<B<Eʹ, Tʺ>, U<C<T, Tʹ, Eʹ>, TParent>> o)
                where Tʺ : Eʹ =>
                    o.Parent.Then(o.Child.End());

        public static U<C<T, Tʹ, Eʹ>, TParent> Else<TParent, T, Tʹ, Eʹ>(
            this U<B<T, Tʹ>, TParent> o,
            Func<T, Eʹ> map) =>
                new(o.Child.Else(map),
                    o.Parent);

        public static U<C<T, Tʹ, Eʺ>, TParent> Then<TParent, T, Tʹ, Eʹ, Eʺ>(
            this U<C<T, Tʹ, Eʹ>, TParent> o,
            Func<Eʹ, Eʺ> map) =>
                new(new(o.Child.Condition, 
                        o.Child.ThenMap,
                        o.Child.ElseMap.Then(map)),
                    o.Parent);

        public static U<A<Eʹ>, U<C<T, Tʹ, Eʹ>, TParent>> ThenIf<TParent, T, Tʹ, Eʹ>(
            this U<C<T, Tʹ, Eʹ>, TParent> o,
            Func<Eʹ, bool> condition) =>
                new(new(condition), 
                    o);

        public static Func<T, Tʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this U<C<Tʹ, Tʺ, Eʺ>, Func<T, Tʹ>> o)
                where Eʺ : Tʺ =>
                    o.Parent.Then(o.Child.End());

        public static Func<T, Eʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this U<C<Tʹ, Tʺ, Eʺ>, Func<T, Tʹ>> o,
            AdHocPolyMarker _ = default)
                where Tʺ : Eʺ =>
                    o.Parent.Then(o.Child.End());

        public static Func<T, Bʺ> End<T, Tʹ, Bʺ, Tʺ, Eʺ>(
            this U<C<Tʹ, Tʺ, Eʺ>, Func<T, Tʹ>> o,
            Func<ReturnType<Bʺ>> @return)
                where Tʺ : Bʺ
                where Eʺ : Bʺ =>
                    o.Parent.Then(o.Child.End(@return));

        public static U<B<T, Tʺ>, TParent> End<TParent, T, Tʹ, Tʺ, Eʺ>(
            this U<C<Tʹ, Tʺ, Eʺ>, U<B<T, Tʹ>, TParent>> o)
                where Eʺ : Tʺ =>
                    o.Parent.Then(o.Child.End());

        public static U<B<T, Eʺ>, TParent> End<TParent, T, Tʹ, Tʺ, Eʺ>(
            this U<C<Tʹ, Tʺ, Eʺ>, U<B<T, Tʹ>, TParent>> o,
            AdHocPolyMarker _ = default)
                where Tʺ : Eʺ =>
                    o.Parent.Then(o.Child.End());

        public static U<B<T, Bʺ>, TParent> End<TParent, T, Tʹ, Bʺ, Tʺ, Eʺ>(
            this U<C<Tʹ, Tʺ, Eʺ>, U<B<T, Tʹ>, TParent>> o,
            Func<ReturnType<Bʺ>> @return)
                where Tʺ : Bʺ
                where Eʺ : Bʺ =>
                    o.Parent.Then(o.Child.End(@return));
        
        public static U<C<T, Tʹ, Tʺ>, TParent> End<TParent, T, Tʹ, Eʹ, Tʺ, Eʺ>(
            this U<C<Eʹ, Tʺ, Eʺ>, U<C<T, Tʹ, Eʹ>, TParent>> o)
                where Eʺ : Tʺ =>
                    o.Parent.Then(o.Child.End());

        public static U<C<T, Tʹ, Eʺ>, TParent> End<TParent, T, Tʹ, Eʹ, Tʺ, Eʺ>(
            this U<C<Eʹ, Tʺ, Eʺ>, U<C<T, Tʹ, Eʹ>, TParent>> o,
            AdHocPolyMarker _ = default)
                where Tʺ : Eʺ =>
                    o.Parent.Then(o.Child.End());

        public static U<C<T, Tʹ, Bʺ>, TParent> End<TParent, T, Tʹ, Eʹ, Bʺ, Tʺ, Eʺ>(
            this U<C<Eʹ, Tʺ, Eʺ>, U<C<T, Tʹ, Eʹ>, TParent>> o,
            Func<ReturnType<Bʺ>> @return)
                where Tʺ : Bʺ
                where Eʺ : Bʺ =>
                    o.Parent.Then(o.Child.End(@return));
    }

    public static partial class ElifirPlus
    {
        public static void Test()
        {
            var _1 =
                AToA
               .ThenIf(ATrue)
                    .Then(AToB)
                    .ThenIf(BTrue)
                        .Then(BToB)
                        .Then(BToB)
                        .ThenIf(BTrue)
                            .Then(BToB)
                            .ThenIf(BTrue)
                                .Then(BToB)
                                .ThenIf(BTrue)
                                    .Then(BToB)
                                .End()
                            .End()
                        .End()
                    .End()
                .Then(BToA)
                .End();

            var _2 = AToA.ThenIf(ATrue).Then(AToC).Else(AToB).End();
            var _3 = AToA.ThenIf(ATrue).Then(AToC).Else(AToD).End(WithReturn<B>);
            var _4 = AToA.ThenIf(ATrue).Then(AToC).Else(AToC).End();
        }

        public static Func<A, bool> ATrue = _ => true;
        public static Func<B, bool> BTrue = _ => true;

        public static Func<A, A> AToA = _ => new();
        public static Func<A, B> AToB = _ => new();
        public static Func<B, A> BToA = _ => new();
        public static Func<B, B> BToB = _ => new();
        public static Func<A, C> AToC = _ => new();
        public static Func<A, D> AToD = _ => new();

        public class A;
        public class B;
        public class C : B;
        public class D : B;
    }
}
