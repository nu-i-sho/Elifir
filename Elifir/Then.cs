namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                x => map(o(x));

        public static Іf<I>.Then<T> Then<I, T>(
            this Іf<I> o,
            Func<I, T> map) =>
                new((I i, [MaybeNullWhen(false)] out T t) =>
                {
                    if (o.Condition(i))
                    {
                        t = map(i);
                        return true;
                    }

                    t = default;
                    return false;
                });

        public static Іf<I>.Then<T> Then<I, Iʹ, T>(
            this Іf<I>.Is<Iʹ> o,
            Func<Iʹ, T> map)
                where Iʹ : I =>
                    new((I i, [MaybeNullWhen(false)] out T t) =>
                    {
                        if (o.Condition(i, out Iʹ? iʹ))
                        {
                            t = map(iʹ);
                            return true;
                        }

                        t = default;
                        return false;
                    });

        public static Іf<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this Іf<I>.Then<T> o,
            Func<T, Tʹ> map) =>
                new((I i, [MaybeNullWhen(false)] out Tʹ tʹ) =>
                {
                    if (o.ConditionalMap(i, out T? t))
                    {
                        tʹ = map(t);
                        return true;
                    }

                    tʹ = default;
                    return false;
                });

        public static Іf<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this Іf<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new(o.ConditionalMap, elseMap);

        public static Іf<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this Іf<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalMap, o.ElseMap.Then(map));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>) Then<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, Іf<I>) o,
            Func<I, T> map) =>
                (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) Then<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this (ꞏꞏꞏ, Іf<I>.Is<Iʹ>) o,
            Func<Iʹ, Tʹ> map)
                where Iʹ : I =>
                    (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, Іf<I>.Then<Tʹ>) Then<ꞏꞏꞏ, I, T, Tʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>) o,
            Func<T, Tʹ> map) =>
                (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) Then<ꞏꞏꞏ, I, T, E>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else) o,
            Func<I, E> map) =>
                (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<Eʹ>) Then<ꞏꞏꞏ, I, T, E, Eʹ>(
            this (ꞏꞏꞏ, Іf<I>.Then<T>.Else.Then<E>) o,
            Func<E, Eʹ> map) =>
                (o.Item1, o.Item2.Then(map));
    }
}
