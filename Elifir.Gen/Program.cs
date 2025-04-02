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
    },
    { "-if",
      new SeededGen<IEnumerable<IfSeed>>(
            new CodeFileGen<IEnumerable<IfSeed>>(
                new MultiGen<IfSeed>(
                    new IfGen())),
            IfSeeds.Default)
    }
};

Console.OutputEncoding = Encoding.UTF8;
foreach (var item in generators[args[0]].Generate(new Token()))
    Console.WriteLine(item);
