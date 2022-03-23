namespace RouletteRoulette.Roulette.Bets
{
    public record BlackBet : Bet
    {
        public override int Payout => 1;

        public override bool Hits(Pocket pocket) => pocket.Color() == PocketColor.Black;
    }
}
