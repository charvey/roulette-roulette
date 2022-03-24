using RouletteRoulette.Roulette.Simulator.DistributionCombiners;
using System.Collections.Generic;
using System.Linq;

namespace RouletteRoulette.Roulette.Simulator
{
    public class TrialRunner
    {
        private readonly IDistributionCombiner combiner = new CombinatorialDistributionCombiner();
        private readonly Table table;

        public TrialRunner(Table table)
        {
            this.table = table;
        }

        public IReadOnlyDictionary<long, double> Run(IReadOnlyDictionary<Bet, byte> bets, ushort trials)
        {
            var singleOutcome = table.Pockets
                    .Select(p => bets.Sum(b => b.Key.Hits(p) ? b.Key.Payout * b.Value : -b.Value))
                    .GroupBy(o => o)
                    .ToDictionary(g => (long)g.Key, g => (double)g.Count() / table.Pockets.Count());

            var outcomes = new Dictionary<long, double> { { 0L, 1.0 } };
            for (var i = 0; i < trials; i++)
            {
                outcomes = combiner.Combine(outcomes, singleOutcome);
            }

            return outcomes;
        }
    }
}
