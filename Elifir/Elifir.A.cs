namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct A<T>(
            Func<T, bool> Condition);

        public static B<T, Tʹ> Then<T, Tʹ>(
            this A<T> o, 
            Func<T, Tʹ> map) =>
                new(o.Condition, map);
    }
}
