namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct D<T, ˣT> where ˣT : T;

        public static E<T, ˣT, Tʹ> Then<T, ˣT, Tʹ>(
            this D<T, ˣT> o, Func<ˣT,  Tʹ> map) where ˣT : T => 
                new(map);
    }
}
