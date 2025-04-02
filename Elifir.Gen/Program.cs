using Nuisho.Elifir.Gen;
using System.Text;

using static Nuisho.Elifir.Gen.Utils;

Dictionary<string, ICodeGen<Token>> generators = new()
{
    { "-end", 
        new SeededGen<IEnumerable<EndSeed>>(
            new CodeFileGen<IEnumerable<EndSeed>>(
                new MultiGen<EndSeed>(
                    new EndGen())),
            EndSeeds.Default)
    }
};

Console.OutputEncoding = Encoding.UTF8;
foreach (var item in generators[args[0]].Generate(new Token()))
    Console.WriteLine(item);
