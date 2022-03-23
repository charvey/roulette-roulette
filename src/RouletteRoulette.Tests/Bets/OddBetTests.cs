using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class OddBetTests
    {
        private readonly OddBet subject;

        public OddBetTests()
        {
            subject = new OddBet();
        }

        [Fact]
        public void EvenMoney() => subject.Payout.Should().Be(1);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.OddPockets), MemberType = typeof(PocketTestData))]
        public void OddsDoHit(Pocket pocket) => Assert.True(subject.Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(PocketTestData.EvenPockets), MemberType = typeof(PocketTestData))]

        public void EvensDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));
    }
}
