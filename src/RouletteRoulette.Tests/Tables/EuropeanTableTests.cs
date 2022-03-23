using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Tables;

namespace RouletteRoulette.Tests.Tables
{
    public class EuropeanTableTests : TableTests
    {
        protected override Table subject { get; } = new EuropeanTable();

        protected override int NumberOfPockets => 37;
        protected override IEnumerable<Pocket> ZeroPockets => new[] { Pocket.G0 };
    }
}
