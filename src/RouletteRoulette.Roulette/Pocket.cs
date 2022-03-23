namespace RouletteRoulette.Roulette
{
    public enum Pocket
    {
        G0,

        R1, B2, R3, B4, R5, B6, R7, B8, R9, B10,
        B11, R12, B13, R14, B15, R16, B17, R18,
        R19, B20, R21, B22, R23, B24, R25, B26, R27, B28,
        B29, R30, B31, R32, B33, R34, B35, R36,

        G00
    }

    public enum PocketColor
    {
        Red,Black,Green
    }

    public static class PocketExtensions
    {
        public static PocketColor Color(this Pocket pocket)
        {
            if (pocket == Pocket.G0 || pocket == Pocket.G00)
                return PocketColor.Green;

            var pocketValue = (int)pocket;

            if (pocket.InRange(1, 10) || pocket.InRange(19, 28))
                return pocketValue % 2 == 1 ? PocketColor.Red : PocketColor.Black;
            else
                return pocketValue % 2 == 0 ? PocketColor.Red : PocketColor.Black;
        }

        public static bool InRange(this Pocket pocket, int min, int max) => min <= (int)pocket && (int)pocket <= max;
    }
}
