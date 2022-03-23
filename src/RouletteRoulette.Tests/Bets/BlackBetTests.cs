using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class BlackBetTests
    {
        private readonly BlackBet subject;

        public BlackBetTests()
        {
            subject = new BlackBet();
        }

        [Fact]
        public void EvenMoney() => subject.Payout.Should().Be(1);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.BlackPockets), MemberType = typeof(PocketTestData))]
        public void BlacksDoHit(Pocket pocket) => Assert.True(subject.Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(PocketTestData.RedPockets), MemberType = typeof(PocketTestData))]
        public void RedsDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket) => Assert.False(subject.Hits(pocket));
    }
}
