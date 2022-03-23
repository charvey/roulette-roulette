using RouletteRoulette.Roulette;
using Xunit;

namespace RouletteRoulette.Tests
{
    public class PocketTests
    {
        [Theory]
        [InlineData(Pocket.G0)]
        [BetterMemberData(nameof(PocketTestData.NumberPockets), MemberType = typeof(PocketTestData))]
        public void PocketEnumsAreEquivalentToValue(Pocket pocket)
        {
            Assert.Equal(((int)pocket).ToString(), pocket.ToString().Substring(1));
        }

        [Theory]
        [BetterMemberData(nameof(PocketTestData.AllPockets), MemberType = typeof(PocketTestData))]
        public void PocketColorRepresentedInEnum(Pocket pocket)
        {
            Assert.Equal(pocket.ToString()[0], pocket.Color().ToString()[0]);
        }
    }
}