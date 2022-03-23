namespace RouletteRoulette.Roulette.Bets
{
    public record HighBet : Bet
    {
        public override int Payout => 1;

        public override bool Hits(Pocket pocket) => pocket.InRange(19, 36);
    }
}
