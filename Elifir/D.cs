namespace Nuisho
{
    using static Elifir;

    public static partial class Elifir
    {
        public readonly record struct D<T, ˣT>(
            SubTypingCondition<T, ˣT> Condition)
                where ˣT : T;
    }

    internal static partial class Internal
    {
        public static E<T, ˣT, Tʹ> Then<T, ˣT, Tʹ>(
            this D<T, ˣT> o, Func<ˣT, Tʹ> map) where ˣT : T =>
                new(o.Condition, map);
    }
}