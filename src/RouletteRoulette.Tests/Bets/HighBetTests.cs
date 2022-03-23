using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class HighBetTests
    {
        private readonly HighBet subject;

        public HighBetTests()
        {
            subject = new HighBet();
        }

        [Fact]
        public void EvenMoney() => subject.Payout.Should().Be(1);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.HighPockets), MemberType = typeof(PocketTestData))]
        public void HighsDoHit(Pocket pocket) => Assert.True(subject.Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(PocketTestData.LowPockets), MemberType = typeof(PocketTestData))]
        public void LowsDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));
    }
}
