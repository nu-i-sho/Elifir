using Elifir.Gen;
using System.Text;

var ifGen = new IfGen();

Console.OutputEncoding = Encoding.UTF8;
foreach (var item in ifGen.Generate(ifGen.Seeds()))
    Console.WriteLine(item);
