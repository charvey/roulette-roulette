using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class LowBetTests
    {
        private readonly LowBet subject;

        public LowBetTests()
        {
            subject = new LowBet();
        }

        [Fact]
        public void EvenMoney() => subject.Payout.Should().Be(1);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.LowPockets), MemberType = typeof(PocketTestData))]
        public void LowsDoHit(Pocket pocket) => Assert.True(subject.Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(PocketTestData.HighPockets), MemberType = typeof(PocketTestData))]
        public void HighsDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));
    }
}
