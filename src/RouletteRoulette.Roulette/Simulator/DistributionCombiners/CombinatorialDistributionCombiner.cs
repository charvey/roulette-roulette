using System.Collections.Generic;

namespace RouletteRoulette.Roulette.Simulator.DistributionCombiners
{
    internal class CombinatorialDistributionCombiner : IDistributionCombiner
    {
        public Dictionary<long, double> Combine(Dictionary<long, double> a, Dictionary<long, double> b)
        {
            var newOutcome = new Dictionary<long, double>();

            foreach (var j in a)
            {
                foreach (var k in b)
                {
                    var key = j.Key + k.Key;
                    if (newOutcome.ContainsKey(key))
                        newOutcome[key] += j.Value * k.Value;
                    else
                        newOutcome[key] = j.Value * k.Value;
                }
            }

            return newOutcome;
        }
    }
}
