using System;

namespace RouletteRoulette.Roulette.Bets
{
    public record ColumnBet : Bet
    {
        internal const int COLUMNS = 3;
        public int Column { get; init; }

        public ColumnBet(int column)
        {
            if (column <= 0 || COLUMNS < column)
                throw new ArgumentException($"{nameof(Column)} must be in 1 to {COLUMNS}", nameof(column));
            Column = column;
        }

        public override int Payout => 2;

        public override bool Hits(Pocket pocket)
        {
            if (pocket == Pocket.G0 || pocket == Pocket.G00)
                return false;

            return ((int)pocket) % COLUMNS == Column % COLUMNS;
        }
    }
}
