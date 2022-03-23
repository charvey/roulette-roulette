using FluentAssertions;
using RouletteRoulette.Roulette;
using RouletteRoulette.Roulette.Bets;
using Xunit;

namespace RouletteRoulette.Tests
{
    public abstract class TableTests
    {
        protected abstract Table subject { get; }

        protected abstract int NumberOfPockets { get; }
        protected abstract IEnumerable<Pocket> ZeroPockets { get; }

        [Fact]
        public void HasCorrectNumberOfPockets() => subject.Pockets.Should().HaveCount(NumberOfPockets).And.OnlyHaveUniqueItems();

        [Theory]
        [InlineData(typeof(BlackBet))]
        [InlineData(typeof(RedBet))]
        [InlineData(typeof(OddBet))]
        [InlineData(typeof(EvenBet))]
        [InlineData(typeof(HighBet))]
        [InlineData(typeof(LowBet))]
        public void HasSingleOneOffBets(Type type) => subject.Bets.Should().ContainSingle(b => b.GetType() == type);

        [Fact]
        public void HasCorrectNumberOfColumnBets() => subject.Bets.OfType<ColumnBet>().Should().HaveCount(ColumnTestData.Columns.Count());

        [Theory]
        [BetterMemberData(nameof(ColumnTestData.Columns), MemberType = typeof(ColumnTestData))]
        public void HasEachColumnBet(int column) => subject.Bets.OfType<ColumnBet>().Should().ContainSingle(b => b.Column == column);

        [Fact]
        public void HasCorrectNumberOfDozenBets() => subject.Bets.OfType<DozenBet>().Should().HaveCount(DozenTestData.Dozens.Count());

        [Theory]
        [BetterMemberData(nameof(DozenTestData.Dozens), MemberType = typeof(DozenTestData))]
        public void HasEachDozenBet(int dozen) => subject.Bets.OfType<DozenBet>().Should().ContainSingle(b => b.Dozen == dozen);

        [Fact]
        public void HasCorrectNumberOfStraightUpBets() => subject.Bets.OfType<StraightUpBet>().Should().HaveCount(NumberOfPockets);

        [Theory]
        [BetterMemberData(nameof(PocketTestData.NumberPockets), MemberType = typeof(PocketTestData))]
        public void HasEachNumericStraightUpBet(Pocket numericPocket) => HasStraightUpBet(numericPocket);

        [Fact]
        public void HasEachZeroStraightUpBet() => ZeroPockets.Should().AllSatisfy(HasStraightUpBet);

        private void HasStraightUpBet(Pocket pocket) => subject.Bets.OfType<StraightUpBet>().Should().ContainSingle(b => b.Pocket == pocket);
    }
}
