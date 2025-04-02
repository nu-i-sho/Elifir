﻿namespace Nuisho.Elifir.Gen
{
    using System.Collections.Generic;
    using static Utils;

    public class SeededGen<Seed>(ICodeGen<Seed> gen, Seed seed)
        : ICodeGen<Token>
    {
        public IEnumerable<string> Generate(Token o) =>
            gen.Generate(seed);
    }
}
