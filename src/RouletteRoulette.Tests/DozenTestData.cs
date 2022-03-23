using RouletteRoulette.Roulette;

namespace RouletteRoulette.Tests
{
    internal static class DozenTestData
    {
        private static Dictionary<int, Pocket[]> dozenPockets => new[]{
            (1,01),
            (2,13),
            (3,25)
        }.ToDictionary(x => x.Item1, x => Enumerable.Range(x.Item2, 12).Cast<Pocket>().ToArray());

        public static IEnumerable<int> Dozens => dozenPockets.Keys;
        public static IEnumerable<int> InvalidDozens => new[] { dozenPockets.Keys.Min() - 1, dozenPockets.Keys.Max() + 1 };
        public static IEnumerable<object[]> NumberPocketsInDozen => dozenPockets.SelectMany(x => x.Value.Select(p => new object[] { x.Key, p }));
        public static IEnumerable<object[]> NumberPocketsInOtherDozens => dozenPockets.SelectMany(x => PocketTestData.NumberPockets.Except(x.Value).Select(p => new object[] { x.Key, p }));
    }
}
