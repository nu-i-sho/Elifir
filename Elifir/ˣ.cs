namespace Nuisho.Elifir
{
    public class ˣ<TPrev, TNext>
    {
        internal ˣ(TPrev prev, TNext next)
        {
            Prev = prev;
            Next = next;
        }

        internal TPrev Prev { get; }
        internal TNext Next { get; }
    }
}
