namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<I, I> End<I, T>(
            this Іf<I>.Then<T> o)
                where T : I =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, T> End<I, T>(
            this Іf<I>.Then<T> o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : i;

        public static Func<I, B> End<I, T, B>(
            this Іf<I>.Then<T> o,
            WithReturnType<B> withReturnB)
                where T : B
                where I : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : i;

        public static Func<I, T> End<I, T, E>(
            this Іf<I>.Then<T>.Else.Then<E> o)
                where E : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, E> End<I, T, E>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, B> End<I, T, E, B>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            WithReturnType<B> _)
                where T : B
                where E : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : o.ElseMap(i);

        // ----------------

        public static Іf<I>.Then<I> End<I, T>(
            this (Іf<I>, Іf<I>.Then<T>) o)
                where T : I =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T> End<I, T>(
            this (Іf<I>, Іf<I>.Then<T>) o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, B>(
            this (Іf<I>, Іf<I>.Then<T>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where I : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<Iʹ> End<I, Iʹ, Tʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Tʹ> End<I, Iʹ, Tʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I, Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, Iʹ, Tʹ, B>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T> End<I, T, E>(
            this (Іf<I>, Іf<I>.Then<T>.Else.Then<E>) o)
                where E : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<E> End<I, T, E>(
            this (Іf<I>, Іf<I>.Then<T>.Else.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, E, B>(
            this (Іf<I>, Іf<I>.Then<T>.Else.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<Tʹ> End<I, Iʹ, Tʹ, Eʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Iʹ : I
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Eʹ> End<I, Iʹ, Tʹ, Eʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, Iʹ, Tʹ, Eʹ, B>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o)
                where Tʹ : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Tʹ> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where T : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, Tʹ, B>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where T  : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<Tʹ> End<I, T, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Eʹ> End<I, T, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, Tʹ, Eʹ, B>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T>.Else.Then<I> End<I, T, E>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<E>) o)
                where E : I =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<E> End<I, T, E>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where I : E =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, E, B>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T>.Else.Then<Tʹ> End<I, T, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<Eʹ> End<I, T, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, Tʹ, Eʹ, B>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T>.Else.Then<E> End<I, T, E, Tʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o)
                where Tʹ : E =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<Tʹ> End<I, T, E, Tʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, E, Tʹ, B>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where E  : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T>.Else.Then<Tʹ> End<I, T, E, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<Eʹ> End<I, T, E, Tʹ, Eʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, E, Tʹ, Eʹ, B>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<I>) End<ꞏꞏꞏ, I, T>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o)
                where T : I =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o,
            AdHocPolyMarker? _ = null)
                where I : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, B>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where T : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<Iʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I, Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>.Else.Then<E>) o)
                where E : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<E>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>.Else.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where T : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, E, B>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>.Else.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Iʹ : I
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<Eʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, Eʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, T, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>) o)
                where T : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where T  : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, T, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<Eʹ>) End<ꞏꞏꞏ, I, T, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, Tʹ, Eʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<I>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<E>) o)
                where E : I =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) End<ꞏꞏꞏ, I, T, E>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<E>) o,
            AdHocPolyMarker? _ = null)
                where I : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<E>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where E : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Eʹ>) End<ꞏꞏꞏ, I, T, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, Tʹ, Eʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) End<ꞏꞏꞏ, I, T, E, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o)
                where Tʹ : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where E : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where E : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o)
                where Eʹ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Eʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ, Eʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : Eʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, Tʹ, Eʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>.Else.Then<Eʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Eʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));
    }
}
