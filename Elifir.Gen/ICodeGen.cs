namespace Nuisho.Elifir.Gen
{
    internal interface ICodeGen<Seed>
    {
        public IEnumerable<string> Generate(Seed o);
    }
}
