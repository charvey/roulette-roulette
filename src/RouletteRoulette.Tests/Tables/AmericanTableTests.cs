using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Tables;

namespace RouletteRoulette.Tests.Tables
{
    public class AmericanTableTests : TableTests
    {
        protected override Table subject { get; } = new AmericanTable();

        protected override int NumberOfPockets => 38;
        protected override IEnumerable<Pocket> ZeroPockets => new[] { Pocket.G0, Pocket.G00 };
    }
}
