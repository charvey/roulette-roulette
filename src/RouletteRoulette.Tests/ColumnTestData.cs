using RouletteRoulette.Roulette;

namespace RouletteRoulette.Tests
{
    internal static class ColumnTestData
    {
        private static Dictionary<int, Pocket[]> columnPockets => new[]{
            (1,new []{1,4,7,10,13,16,19,22,25,28,31,34} ),
            (2,new []{2,5,8,11,14,17,20,23,26,29,32,35} ),
            (3,new []{3,6,9,12,15,18,21,24,27,30,33,36} )
        }.ToDictionary(x => x.Item1, x => x.Item2.Cast<Pocket>().ToArray());

        public static IEnumerable<int> Columns => columnPockets.Keys;
        public static IEnumerable<int> InvalidColumns => new[] { columnPockets.Keys.Min() - 1, columnPockets.Keys.Max() + 1 };
        public static IEnumerable<object[]> NumberPocketsInColumn => columnPockets.SelectMany(x => x.Value.Select(p => new object[] { x.Key, p }));
        public static IEnumerable<object[]> NumberPocketsInOtherColumns => columnPockets.SelectMany(x => PocketTestData.NumberPockets.Except(x.Value).Select(p => new object[] { x.Key, p }));
    }
}
