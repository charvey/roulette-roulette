using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class DozenBetTests
    {
        [Theory]
        [BetterMemberData(nameof(DozenTestData.Dozens), MemberType = typeof(DozenTestData))]
        public void ValidDozenCanExist(int dozen)
        {
            Action x = () => new DozenBet(dozen);

            x.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [BetterMemberData(nameof(DozenTestData.InvalidDozens), MemberType = typeof(DozenTestData))]
        public void InvalidDozenCantExist(int dozen)
        {
            Action x = () => new DozenBet(dozen);

            x.Should().Throw<ArgumentException>();
        }

        [Theory]
        [BetterMemberData(nameof(DozenTestData.Dozens), MemberType = typeof(DozenTestData))]
        public void DozenIsGettable(int dozen) => new DozenBet(dozen).Dozen.Should().Be(dozen);

        [Theory]
        [BetterMemberData(nameof(DozenTestData.Dozens), MemberType = typeof(DozenTestData))]
        public void DoubleMoney(int dozen) => new DozenBet(dozen).Payout.Should().Be(2);

        [Theory]
        [BetterMemberData(nameof(DozenTestData.NumberPocketsInDozen), MemberType = typeof(DozenTestData))]
        public void NumbersInDozenDoHit(int dozen, Pocket pocket) => Assert.True(new DozenBet(dozen).Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(DozenTestData.NumberPocketsInOtherDozens), MemberType = typeof(DozenTestData))]
        public void NumbersInOtherDozensDontHit(int dozen, Pocket pocket) => Assert.False(new DozenBet(dozen).Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket)
        {
            var bets = DozenTestData.Dozens.Select(c => new DozenBet(c));

            var hits = bets.Select(b => b.Hits(pocket));

            hits.Should().AllSatisfy(h => h.Should().BeFalse());
        }
    }
}
