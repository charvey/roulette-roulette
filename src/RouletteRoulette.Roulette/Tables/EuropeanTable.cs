using System;
using System.Collections.Generic;
using System.Linq;

namespace RouletteRoulette.Roulette.Tables
{
    public class EuropeanTable : Table
    {
        public override IEnumerable<Pocket> Pockets => Enum.GetValues(typeof(Pocket)).Cast<Pocket>().Except(new[] { Pocket.G00 });
    }
}
