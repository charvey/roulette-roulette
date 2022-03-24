using System.Collections.Generic;
using System.Linq;

namespace RouletteRoulette.Roulette.Simulator.DistributionCombiners
{
    internal class LinqDistributionCombiner : IDistributionCombiner
    {
        public Dictionary<long, double> Combine(Dictionary<long, double> a, Dictionary<long, double> b)
        {
            return a
                .SelectMany(x => b.Select(y => (x.Key + y.Key, x.Value * y.Value)))
                .GroupBy(x => x.Item1, x => x.Item2)
                .ToDictionary(x => x.Key, x => x.Sum());
        }
    }
}
