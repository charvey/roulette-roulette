using FluentAssertions;
using RouletteRoulette.Roulette.Simulator;
using Xunit;

namespace RouletteRoulette.Tests.Simulator
{
    public abstract class DistributionCombinerTests
    {
        private protected abstract IDistributionCombiner subject { get; }

        private static Dictionary<long, double> unit { get; } = new Dictionary<long, double> { { 0L, 1.0 } };

        [Fact]
        public void UnitIsIdentity()
        {
            subject.Combine(unit, unit).Should().Equal(unit);
        }

        [Fact]
        public void CombinationOrderShouldntMatter()
        {
            var a = new Dictionary<long, double> { { -1, 0.5 }, { 1, 0.5 } };

            subject.Combine(unit, a).Should().Equal(a);
            subject.Combine(a, unit).Should().Equal(a);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(9)]
        public void InversesShouldCancel(long scale)
        {
            var a = new Dictionary<long, double> { { -scale, 1.0 } };
            var b = new Dictionary<long, double> { { +scale, 1.0 } };

            subject.Combine(a, b).Should().Equal(unit);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(8)]
        public void CoinFlips(int flips)
        {
            var x = new Dictionary<long, double> { { -1, 0.5 }, { +1, 0.5 } };
            var c = unit;

            for (var i = 0; i < flips; i++)
                c = subject.Combine(c, x);

            c.Keys.Min().Should().Be(-flips);
            c.Should().Contain(-flips, Math.Pow(0.5, flips));
            c.Should().Contain(+flips, Math.Pow(0.5, flips));
            c.Keys.Max().Should().Be(+flips);
        }
    }
}
