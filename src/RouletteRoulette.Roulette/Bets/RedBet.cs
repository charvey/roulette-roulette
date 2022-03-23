namespace RouletteRoulette.Roulette.Bets
{
    public record RedBet : Bet
    {
        public override int Payout => 1;

        public override bool Hits(Pocket pocket) => pocket.Color() == PocketColor.Red;
    }
}
