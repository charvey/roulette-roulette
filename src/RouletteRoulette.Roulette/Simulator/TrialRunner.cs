using System.Collections.Generic;
using System.Linq;

namespace RouletteRoulette.Roulette.Simulator
{
    public class TrialRunner
    {
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
                    .ToDictionary(g => g.Key, g => (double)g.Count() / table.Pockets.Count());

            var outcomes = new Dictionary<long, double> { { 0L, 1.0 } };
            for (var i = 0; i < trials; i++)
            {
#pragma warning disable CS0162 // Unreachable code detected
                switch (1)
                {
                    case 1:
                        var newOutcome = new Dictionary<long, double>();

                        foreach (var j in outcomes)
                        {
                            foreach (var k in singleOutcome)
                            {
                                var key = j.Key + k.Key;
                                if (newOutcome.ContainsKey(key))
                                    newOutcome[key] += j.Value * k.Value;
                                else
                                    newOutcome[key] = j.Value * k.Value;
                            }
                        }

                        outcomes = newOutcome;
                        break;
                    case 2:
                        outcomes = outcomes
                            .SelectMany(x => singleOutcome.Select(y => (x.Key + y.Key, x.Value * y.Value)))
                            .GroupBy(x => x.Item1, x => x.Item2)
                            .ToDictionary(x => x.Key, x => x.Sum());
                        break;
                }
#pragma warning restore CS0162 // Unreachable code detected
            }

            return outcomes;
        }
    }
}
