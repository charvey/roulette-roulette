using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class RedBetTests
    {
        private readonly RedBet subject;

        public RedBetTests()
        {
            subject = new RedBet();
        }

        [Fact]
        public void EvenMoney() => subject.Payout.Should().Be(1);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.RedPockets), MemberType = typeof(PocketTestData))]
        public void RedsDoHit(Pocket pocket) => Assert.True(subject.Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(PocketTestData.BlackPockets), MemberType = typeof(PocketTestData))]

        public void BlacksDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));
    }
}
