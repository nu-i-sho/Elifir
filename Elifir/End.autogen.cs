// To regenerate this file with the Elifir.Gen remove
// the current file and build/rebuild the current project.

namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static Func<T, Tʺ> End<T, Tʹ, Tʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>) o)
                where Tʹ : Tʺ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, Tʹ> End<T, Tʹ, Tʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>) o,
            AdHocPolyMarker? _ = null)
                where Tʺ : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, B> End<T, Tʹ, Tʺ, B>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʹ : B
                where Tʺ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Func<T, Tʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>) o)
                where Eʺ : Tʺ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, Eʺ> End<T, Tʹ, Tʺ, Eʺ>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>) o,
            AdHocPolyMarker? _ = null)
                where Tʺ : Eʺ =>
                    o.Item1.Then(o.Item2.End());

        public static Func<T, B> End<T, Tʹ, Tʺ, Eʺ, B>(
            this (Func<T, Tʹ>, Іf<Tʹ>.Then<Tʺ>.Else.Then<Eʺ>) o,
            WithReturnType<B> withReturnTypeB)
                where Tʺ : B
                where Eʺ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static Іf<I>.Then<T> End<I, T>(
            this (Іf<I>, Іf<I>.Then<T>) o)
                where I : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<I> End<I, T>(
            this (Іf<I>, Іf<I>.Then<T>) o,
            AdHocPolyMarker? _ = null)
                where T : I =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, B>(
            this (Іf<I>, Іf<I>.Then<T>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where T : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) End<ꞏꞏꞏ, I, T>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o)
                where I : T =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<I>) End<ꞏꞏꞏ, I, T>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o,
            AdHocPolyMarker? _ = null)
                where T : I =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, T, B>(
            this ((ꞏꞏꞏ, Іf<I>), Іf<I>.Then<T>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where T : B =>
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

        public static Іf<I>.Then<Tʹ> End<I, Iʹ, Tʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o)
                where Iʹ : I, Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<Iʹ> End<I, Iʹ, Tʹ>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, Iʹ, Tʹ, B>(
            this (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o)
                where Iʹ : I, Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<Iʹ>) End<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Iʹ : I
                where Tʹ : Iʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<B>) End<ꞏꞏꞏ, I, Iʹ, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where Iʹ : I, B
                where Tʹ : B =>
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

        public static Іf<I>.Then<Tʹ> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o)
                where T : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : T =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<B> End<I, T, Tʹ, B>(
            this (Іf<I>.Then<T>, Іf<T>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where T : B
                where Tʹ : B =>
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
                where T : B
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

        public static Іf<I>.Then<T>.Else.Then<Tʹ> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<Tʹ>) o)
                where I : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<I> End<I, T, Tʹ>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : I =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, Tʹ, B>(
            this (Іf<I>.Then<T>.Else, Іf<I>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<Tʹ>) o)
                where I : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<I>) End<ꞏꞏꞏ, I, T, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : I =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where I : B
                where Tʹ : B =>
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

        public static Іf<I>.Then<T>.Else.Then<Tʹ> End<I, T, E, Tʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o)
                where E : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<E> End<I, T, E, Tʹ>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : E =>
                    o.Item1.Then(o.Item2.End());

        public static Іf<I>.Then<T>.Else.Then<B> End<I, T, E, Tʹ, B>(
            this (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where E : B
                where Tʹ : B =>
                    o.Item1.Then(o.Item2.End(withReturnTypeB));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Tʹ>) End<ꞏꞏꞏ, I, T, E, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o)
                where E : Tʹ =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) End<ꞏꞏꞏ, I, T, E, Tʹ>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o,
            AdHocPolyMarker? _ = null)
                where Tʹ : E =>
                    o.Item1.Then(o.Item2.End());

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<B>) End<ꞏꞏꞏ, I, T, E, Tʹ, B>(
            this ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Then<Tʹ>) o,
            WithReturnType<B> withReturnTypeB)
                where E : B
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
