namespace Nuisho.Elifir
{
    public static partial class Syntax
    {
        public static ˣ<Some, ˣ.If<I>.Then<Tʹ>> Then<Some, I, T, Tʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o,
            Func<T, Tʹ> map) =>
                new(o.Prev, 
                    o.Next.Then(map));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>> If<Some, I, T>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o,
            Func<T, bool> condition) =>
                new(o, If(condition));

        public static ˣ<ˣ<Some, ˣ.If<I>.Then<T>>, ˣ.If<T>.Is<Tʹ>> If<Some, I, T, Tʹ>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o,
            IsOfType<Tʹ> _)
                where Tʹ : T =>
                    new(o, new());

        public static ˣ<Some, ˣ.If<I>.Then<T>.Else> Else<Some, I, T>(
            this ˣ<Some, ˣ.If<I>.Then<T>> o) =>
                new(o.Prev, 
                    o.Next.Else());
    }
}
