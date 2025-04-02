namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static (Func<T, Tʹ>, Іf<Tʹ>) If<T, Tʹ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, bool> condition) =>
                (o, If(condition));
        
        public static (Func<T, Tʹ>, Іf<Tʹ>.Is<Tʺ>) If<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            IsOfType<Tʺ> condition)
                where Tʺ : Tʹ =>
                    (o, new());

        public static (Іf<I>, Іf<I>) If<I>(
            this Іf<I> o,
            Func<I, bool> condition) =>
                (o, If(condition));
        
        public static (Іf<I>, Іf<I>.Is<Iʹ>) If<I, Iʹ>(
            this Іf<I> o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new());
        
        public static ((ꞏꞏꞏ, Іf<I>), Іf<I>) If<ꞏꞏꞏ, I>(
            this (ꞏꞏꞏ, Іf<I>) o,
            Func<I, bool> condition) =>
                (o, If(condition));
        
        public static ((ꞏꞏꞏ, Іf<I>), Іf<I>.Is<Iʹ>) If<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new());

        public static (Іf<I>.Is<Iʹ>, Іf<Iʹ>) If<I, Iʹ>(
            this Іf<I>.Is<Iʹ> o,
            Func<Iʹ, bool> condition)
                where Iʹ : I => 
                    (o, If(condition));
        
        public static (Іf<I>.Is<Iʹ>, Іf<Iʹ>.Is<Iʺ>) If<I, Iʹ, Iʺ>(
            this Іf<I>.Is<Iʹ> o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    (o, new());
        
        public static ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>) If<ꞏꞏꞏ, I, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            Func<Iʹ, bool> condition)
                where Iʹ : I => 
                    (o, If(condition));
        
        public static ((ꞏꞏꞏ, Іf<I>.Is<Iʹ>), Іf<Iʹ>.Is<Iʺ>) If<ꞏꞏꞏ, I, Iʹ, Iʺ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            IsOfType<Iʺ> condition)
                where Iʹ : I
                where Iʺ : Iʹ =>
                    (o, new());

        public static (Іf<I>.Then<T>, Іf<T>) If<I, T>(
            this Іf<I>.Then<T> o,
            Func<T, bool> condition) =>
                (o, If(condition));
        
        public static (Іf<I>.Then<T>, Іf<T>.Is<Tʹ>) If<I, T, Tʹ>(
            this Іf<I>.Then<T> o,
            IsOfType<Tʹ> condition)
                where Tʹ : T =>
                    (o, new());
        
        public static ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>) If<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o,
            Func<T, bool> condition) =>
                (o, If(condition));
        
        public static ((ꞏꞏꞏ, Іf<I>.Then<T>), Іf<T>.Is<Tʹ>) If<ꞏꞏꞏ, I, T, Tʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o,
            IsOfType<Tʹ> condition)
                where Tʹ : T =>
                    (o, new());

        public static (Іf<I>.Then<T>.Else, Іf<I>) If<I, T>(
            this Іf<I>.Then<T>.Else o,
            Func<I, bool> condition) =>
                (o, If(condition));
        
        public static (Іf<I>.Then<T>.Else, Іf<I>.Is<Iʹ>) If<I, T, Iʹ>(
            this Іf<I>.Then<T>.Else o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new());
        
        public static ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>) If<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else) o,
            Func<I, bool> condition) =>
                (o, If(condition));
        
        public static ((ꞏꞏꞏ, Іf<I>.Then<T>.Else), Іf<I>.Is<Iʹ>) If<ꞏꞏꞏ, I, T, Iʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else) o,
            IsOfType<Iʹ> condition)
                where Iʹ : I =>
                    (o, new());

        public static (Іf<I>.Then<T>.Else.Then<E>, Іf<E>) If<I, T, E>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            Func<E, bool> condition) =>
                (o, If(condition));
        
        public static (Іf<I>.Then<T>.Else.Then<E>, Іf<E>.Is<Eʹ>) If<I, T, E, Eʹ>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            IsOfType<Eʹ> condition)
                where Eʹ : E =>
                    (o, new());
        
        public static ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>) If<ꞏꞏꞏ, I, T, E>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) o,
            Func<E, bool> condition) =>
                (o, If(condition));
        
        public static ((ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>), Іf<E>.Is<Eʹ>) If<ꞏꞏꞏ, I, T, E, Eʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) o,
            IsOfType<Eʹ> condition)
                where Eʹ : E =>
                    (o, new());
    }
}
