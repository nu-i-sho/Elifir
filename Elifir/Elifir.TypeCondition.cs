namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct TypeCondition<T, ˣT> 
            where ˣT : T;

        public static class Obj<T>
        {
            public static TypeCondition<T, ˣT> Is<ˣT>() 
                where ˣT : T => 
                    new();
        }

        public static D<T, ˣT> If<T, ˣT>(
            Func<TypeCondition<T, ˣT>> _) 
                where ˣT : T => 
                    new();
    }
}
