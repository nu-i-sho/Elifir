namespace Nuisho.Elifir
{
    public static partial class ˣ
    {
        public readonly partial struct If<I>
        {
            public readonly partial struct Then<T>
            {
                public readonly partial struct Else
                {
                    public readonly partial struct Then<E>(
                        ConditionalMap<I, T> conditionalMap,
                        Func<I, E> elseMap)
                    {
                        internal ConditionalMap<I, T> ConditionalMap => conditionalMap;
                        internal Func<I, E> ElseMap => elseMap;
                    }
                }
            }
        }
    }

    public static partial class Syntax
    {
        public static ˣ.If<I>.Then<T>.Else.Then<Eʹ> Then<I, T, E, Eʹ>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            Func<E, Eʹ> map) =>
                new(o.ConditionalMap,
                    o.ElseMap.Then(map));

        public static ˣ<ˣ.If<I>.Then<T>.Else.Then<E>, ˣ.If<E>> If<I, T, E>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            Func<E, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ.If<I>.Then<T>.Else.Then<E>, ˣ.If<E>.Is<Eʹ>> If<I, T, E, Eʹ>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            ConditionalMap<E, Eʹ> condition)
                where Eʹ : E =>
                    new(o, If(condition));

        public static Func<I, T> End<I, T, E>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o)
                where E : T =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, E> End<I, T, E>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            AdHocPolyMarker _ = default)
                where T : E =>
                    i => o.ConditionalMap(i, out T? t) ? t : o.ElseMap(i);

        public static Func<I, B> End<I, T, E, B>(
            this ˣ.If<I>.Then<T>.Else.Then<E> o,
            ReturnType<B> _)
                where T : B
                where E : B =>
                    i => o.ConditionalMap(i, out T? t) ? (B)t : o.ElseMap(i);
    }
}
