using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests.Bets
{
    public class ColumnBetTests
    {
        [Theory]
        [BetterMemberData(nameof(ColumnTestData.Columns), MemberType = typeof(ColumnTestData))]
        public void ValidColumnCanExist(int column)
        {
            Action x = () => new ColumnBet(column);

            x.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [BetterMemberData(nameof(ColumnTestData.InvalidColumns), MemberType = typeof(ColumnTestData))]
        public void InvalidColumnCantExist(int column)
        {
            Action x = () => new ColumnBet(column);

            x.Should().Throw<ArgumentException>();
        }

        [Theory]
        [BetterMemberData(nameof(ColumnTestData.Columns), MemberType = typeof(ColumnTestData))]
        public void ColumnIsGettable(int column) => new ColumnBet(column).Column.Should().Be(column);

        [Theory]
        [BetterMemberData(nameof(ColumnTestData.Columns), MemberType = typeof(ColumnTestData))]
        public void DoubleMoney(int column) => new ColumnBet(column).Payout.Should().Be(2);

        [Theory]
        [BetterMemberData(nameof(ColumnTestData.NumberPocketsInColumn), MemberType = typeof(ColumnTestData))]
        public void NumbersInColumnDoHit(int column, Pocket pocket) => Assert.True(new ColumnBet(column).Hits(pocket));

        [Theory]
        [BetterMemberData(nameof(ColumnTestData.NumberPocketsInOtherColumns), MemberType = typeof(ColumnTestData))]
        public void NumbersInOtherColumnsDontHit(int column, Pocket pocket) => Assert.False(new ColumnBet(column).Hits(pocket));

        [Theory]
        [InlineData(Pocket.G0)]
        [InlineData(Pocket.G00)]
        public void ZeroesDontHit(Pocket pocket)
        {
            var bets = ColumnTestData.Columns.Select(c => new ColumnBet(c));

            var hits = bets.Select(b => b.Hits(pocket));

            hits.Should().AllSatisfy(h => h.Should().BeFalse());
        }
    }
}
