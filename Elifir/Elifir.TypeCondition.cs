namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct TypeCondition<T, ˣT> where ˣT : T;

        public static TypeConditionIsMorpheme<T> Obj<T>() => new();

        public readonly record struct TypeConditionIsMorpheme<T>
        {
            public TypeCondition<T, ˣT> Is<ˣT>() where ˣT : T => new();
        }

        public static D<T, ˣT> If<T, ˣT>(TypeCondition<T, ˣT> _) where ˣT : T => new();
    }
}
