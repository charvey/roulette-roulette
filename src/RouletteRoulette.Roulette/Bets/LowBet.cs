namespace RouletteRoulette.Roulette.Bets
{
    public record LowBet : Bet
    {
        public override int Payout => 1;

        public override bool Hits(Pocket pocket) => pocket.InRange(1, 18);
    }
}
