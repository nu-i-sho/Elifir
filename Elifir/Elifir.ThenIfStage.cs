namespace Nuisho
{
    public static partial class Elifir
    {
        public readonly record struct ThenIfStage<TChild, TParent>(
            TChild Child, TParent Parent);
    }
}
