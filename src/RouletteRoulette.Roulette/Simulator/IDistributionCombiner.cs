using System.Collections.Generic;

namespace RouletteRoulette.Roulette.Simulator
{
    internal interface IDistributionCombiner
    {
        Dictionary<long, double> Combine(Dictionary<long, double> a, Dictionary<long, double> b);
    }
}
