// To regenerate this file with the Elifir.Gen remove
// the current file and build/rebuild the current project.

namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (Func<T, Tʹ>, İf<Tʹ>) If<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                (o, If(condition));

        public static (Func<T, Tʹ>, İf<Tʹ>.Is<Tʺ>) If<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            IsOfType<Tʺ> condition)
                where Tʺ : Tʹ =>
                    (o, new ());

        public static (İf<I>, İf<I>) If<I>(
            this İf<I> o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static (İf<I>, İf<I>.Is<Iʹ>) If<I, Iʹ>(
            this İf<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new ());

        public static ((ꞏꞏꞏ, İf<I>), İf<I>) If<ꞏꞏꞏ, I>(
            this (ꞏꞏꞏ, İf<I>) o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, İf<I>), İf<I>.Is<Iʹ>) If<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, İf<I>) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new ());

        public static (İf<I>.Is<Iʹ>, İf<Iʹ>) If<I, Iʹ>(
            this İf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                (o, If(condition));

        public static (İf<I>.Is<Iʹ>, İf<Iʹ>.Is<Iʺ>) If<I, Iʹ, Iʺ>(
            this İf<I>.Is<Iʹ> o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    (o, new ());

        public static ((ꞏꞏꞏ, İf<I>.Is<Iʹ>), İf<Iʹ>) If<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, İf<I>.Is<Iʹ>) o,
            Func<Iʹ, bool> condition)
                where Iʹ : I =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, İf<I>.Is<Iʹ>), İf<Iʹ>.Is<Iʺ>) If<ꞏꞏꞏ, I, Iʹ, Iʺ>(
            this (ꞏꞏꞏ, İf<I>.Is<Iʹ>) o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    (o, new ());

        public static (İf<I>.Then<T>, İf<T>) If<I, T>(
            this İf<I>.Then<T> o,
            Func<T, bool> condition) =>
                (o, If(condition));

        public static (İf<I>.Then<T>, İf<T>.Is<Tʹ>) If<I, T, Tʹ>(
            this İf<I>.Then<T> o,
            IsOfType<Tʹ> condition)
                where Tʹ : T =>
                    (o, new ());

        public static ((ꞏꞏꞏ, İf<I>.Then<T>), İf<T>) If<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, İf<I>.Then<T>) o,
            Func<T, bool> condition) =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, İf<I>.Then<T>), İf<T>.Is<Tʹ>) If<ꞏꞏꞏ, I, T, Tʹ>(
            this (ꞏꞏꞏ, İf<I>.Then<T>) o,
            IsOfType<Tʹ> condition)
                where Tʹ : T =>
                    (o, new ());

        public static (İf<I>.Then<T>.Else, İf<I>) If<I, T>(
            this İf<I>.Then<T>.Else o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static (İf<I>.Then<T>.Else, İf<I>.Is<Iʹ>) If<I, T, Iʹ>(
            this İf<I>.Then<T>.Else o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new ());

        public static ((ꞏꞏꞏ, İf<I>.Then<T>.Else), İf<I>) If<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, İf<I>.Then<T>.Else) o,
            Func<I, bool> condition) =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, İf<I>.Then<T>.Else), İf<I>.Is<Iʹ>) If<ꞏꞏꞏ, I, T, Iʹ>(
            this (ꞏꞏꞏ, İf<I>.Then<T>.Else) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new ());

        public static (İf<I>.Then<T>.Else.Then<E>, İf<E>) If<I, T, E>(
            this İf<I>.Then<T>.Else.Then<E> o,
            Func<E, bool> condition) =>
                (o, If(condition));

        public static (İf<I>.Then<T>.Else.Then<E>, İf<E>.Is<Eʹ>) If<I, T, E, Eʹ>(
            this İf<I>.Then<T>.Else.Then<E> o,
            IsOfType<Eʹ> condition)
                where Eʹ : E =>
                    (o, new ());

        public static ((ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<E>), İf<E>) If<ꞏꞏꞏ, I, T, E>(
            this (ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<E>) o,
            Func<E, bool> condition) =>
                (o, If(condition));

        public static ((ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<E>), İf<E>.Is<Eʹ>) If<ꞏꞏꞏ, I, T, E, Eʹ>(
            this (ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<E>) o,
            IsOfType<Eʹ> condition)
                where Eʹ : E =>
                    (o, new ());
    }
}
