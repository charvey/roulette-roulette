using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class StraightUpBetTests
    {
        [Theory]
        [BetterMemberData(nameof(PocketTestData.AllPockets), MemberType = typeof(PocketTestData))]
        public void PocketIsGettable(Pocket pocket) => new StraightUpBet(pocket).Pocket.Should().Be(pocket);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.AllPockets), MemberType = typeof(PocketTestData))]
        public void BigPayout(Pocket pocket) => new StraightUpBet(pocket).Payout.Should().Be(35);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.AllPockets), MemberType = typeof(PocketTestData))]
        public void SamePocketShouldHit(Pocket pocket) => new StraightUpBet(pocket).Hits(pocket).Should().BeTrue();

        [Theory]
        [BetterMemberData(nameof(PocketTestData.AllPockets), MemberType = typeof(PocketTestData))]
        public void OtherPocketsShouldNotHit(Pocket pocket)
        {
            var subject = new StraightUpBet(pocket);

            var hits = PocketTestData.AllPockets.Except(new[] { pocket }).Select(subject.Hits);

            hits.Should().AllSatisfy(h => h.Should().BeFalse());
        }
    }
}
