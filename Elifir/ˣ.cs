namespace Nuisho.Elifir
{
    public readonly struct ˣ<TPrev, TNext>(
        TPrev prev, TNext next)
    {
        internal TPrev Prev => prev;
        internal TNext Next => next;
    }
}
