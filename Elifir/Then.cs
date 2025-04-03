namespace Nuisho.Elifir
{
    using System.Diagnostics.CodeAnalysis;

    public static partial class Syntax
    {
        public static Func<T, Tʺ> Then<T, Tʹ, Tʺ>(
            this Func<T, Tʹ> o,
            Func<Tʹ, Tʺ> map) =>
                x => map(o(x));

        public static İf<I>.Then<T> Then<I, T>(
            this İf<I> o,
            Func<I, T> map) =>
                new ((I i, [MaybeNullWhen(false)] out T t) =>
                {
                    if (o.Condition(i))
                    {
                        t = map(i);
                        return true;
                    }

                    t = default;
                    return false;
                });

        public static İf<I>.Then<T> Then<I, Iʹ, T>(
            this İf<I>.Is<Iʹ> o,
            Func<Iʹ, T> map)
                where Iʹ : I =>
                    new ((I i, [MaybeNullWhen(false)] out T t) =>
                    {
                        if (o.Condition(i, out Iʹ? iʹ))
                        {
                            t = map(iʹ);
                            return true;
                        }

                        t = default;
                        return false;
                    });

        public static İf<I>.Then<Tʹ> Then<I, T, Tʹ>(
            this İf<I>.Then<T> o,
            Func<T, Tʹ> map) =>
                new ((I i, [MaybeNullWhen(false)] out Tʹ tʹ) =>
                {
                    if (o.ConditionalMap(i, out T? t))
                    {
                        tʹ = map(t);
                        return true;
                    }

                    tʹ = default;
                    return false;
                });

        public static İf<I>.Then<T>.Else.Then<E> Then<I, T, E>(
            this İf<I>.Then<T>.Else o,
            Func<I, E> elseMap) =>
                new (o.ConditionalMap, elseMap);

        public static İf<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this İf<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new (o.ConditionalMap, o.ElseMap.Then(map));

        public static (ꞏꞏꞏ, İf<I>.Then<T>) Then<ꞏꞏꞏ, I, T>(
            this (ꞏꞏꞏ, İf<I>) o,
            Func<I, T> map) =>
                (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, İf<I>.Then<Tʹ>) Then<ꞏꞏꞏ, I, Iʹ, Tʹ>(
            this (ꞏꞏꞏ, İf<I>.Is<Iʹ>) o,
            Func<Iʹ, Tʹ> map)
                where Iʹ : I =>
                    (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, İf<I>.Then<Tʹ>) Then<ꞏꞏꞏ, I, T, Tʹ>(
            this (ꞏꞏꞏ, İf<I>.Then<T>) o,
            Func<T, Tʹ> map) =>
                (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<E>) Then<ꞏꞏꞏ, I, T, E>(
            this (ꞏꞏꞏ, İf<I>.Then<T>.Else) o,
            Func<I, E> map) =>
                (o.Item1, o.Item2.Then(map));

        public static (ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<Eʹ>) Then<ꞏꞏꞏ, I, T, E, Eʹ>(
            this (ꞏꞏꞏ, İf<I>.Then<T>.Else.Then<E>) o,
            Func<E, Eʹ> map) =>
                (o.Item1, o.Item2.Then(map));
    }
}
