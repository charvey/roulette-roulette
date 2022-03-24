using RouletteRoulette.Roulette.Simulator;
using RouletteRoulette.Roulette.Simulator.DistributionCombiners;

namespace RouletteRoulette.Tests.Simulator.DistributionCombiners
{
    public class CombinatorialDistributionCombinerTests : DistributionCombinerTests
    {
        private protected override IDistributionCombiner subject => new CombinatorialDistributionCombiner();
    }
}
