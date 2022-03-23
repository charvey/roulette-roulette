using RouletteRoulette.Roulette;

namespace RouletteRoulette.Tests
{
    internal static class PocketTestData
    {
        public static IEnumerable<Pocket> AllPockets => Enum.GetValues<Pocket>();
        public static IEnumerable<Pocket> NumberPockets => AllPockets.Except(new[] { Pocket.G0, Pocket.G00 });
        public static IEnumerable<Pocket> EvenPockets => NumberPockets.Where(p => (int)p % 2 == 0);
        public static IEnumerable<Pocket> OddPockets => NumberPockets.Where(p => (int)p % 2 == 1);
        public static IEnumerable<Pocket> RedPockets => AllPockets.Where(p => p.Color() == PocketColor.Red);
        public static IEnumerable<Pocket> BlackPockets => AllPockets.Where(p => p.Color() == PocketColor.Black);
        public static IEnumerable<Pocket> HighPockets => NumberPockets.Where(p => p.InRange(19, 36));
        public static IEnumerable<Pocket> LowPockets => NumberPockets.Where(p => p.InRange(1, 18));
    }
}
