using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using RouletteRoulette.Roulette.Simulator;
using RouletteRoulette.Roulette.Tables;
using Xunit;

namespace RouletteRoulette.Tests.Simulator
{
    public class SimulatorTests
    {
        [Theory]
        [InstanceData<AmericanTable>]
        [InstanceData<EuropeanTable>]
        public void OutcomesOfASpinAreDistributed(Table table)
        {
            var bets = new Dictionary<Bet, byte>
            {
                { table.Bets.OfType<StraightUpBet>().Single(b => b.Pocket == Pocket.B15),1 }
            };
            var trial = new TrialRunner(table);

            var results = trial.Run(bets, 1);

            results[35].Should().Be(1.0 / table.Pockets.Count());
            results[-1].Should().Be(1.0 - 1.0 / table.Pockets.Count());
            results.Values.Sum().Should().Be(1);
        }

        [Theory]
        [InstanceData<AmericanTable>]
        [InstanceData<EuropeanTable>]
        public void OutcomesAreScaledByetSize(Table table)
        {
            byte betSize = 15;
            var bets = new Dictionary<Bet, byte>
            {
                { table.Bets.OfType<BlackBet>().Single(),betSize }
            };
            var trial = new TrialRunner(table);

            var results = trial.Run(bets, 1);

            results.Keys.Should().BeEquivalentTo(new[] { -betSize, betSize });
        }

        [Theory]
        [InstanceData<AmericanTable>]
        [InstanceData<EuropeanTable>]
        public void OutcomesOfManySpinsAreDistributed(Table table)
        {
            ushort N = 100;
            double epsilon = 1e-9;
            var bets = new Dictionary<Bet, byte>
            {
                { table.Bets.OfType<BlackBet>().Single(),1 }
            };
            var trial = new TrialRunner(table);

            var results = trial.Run(bets, N);

            results[N].Should().BeApproximately(Math.Pow(18.0 / table.Pockets.Count(), N), epsilon);
            results[-N].Should().BeApproximately(Math.Pow(1.0 - 18.0 / table.Pockets.Count(), N), epsilon);
            results.Values.Sum().Should().BeApproximately(1, epsilon);
        }
    }
}
