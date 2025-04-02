namespace Nuisho.Elifir.Gen
{
    public interface ICodeGen<Seed>
    {
        public IEnumerable<string> Generate(Seed o);
    }
}
