namespace Nuisho.Elifir.Gen
{
    public class MultiGen<Seed>(ICodeGen<Seed> itemGen) 
        : ICodeGen<IEnumerable<Seed>>
    {
        public IEnumerable<string> Generate(IEnumerable<Seed> o)
        {
            using var e = o
                .Select(itemGen.Generate)
                .GetEnumerator();

            bool hasItem = e.MoveNext();
            while (hasItem)
            {
                foreach (var line in e.Current)
                    yield return line;

                hasItem = e.MoveNext();
                if (hasItem)
                    yield return string.Empty;
            }
        }
    }
}
