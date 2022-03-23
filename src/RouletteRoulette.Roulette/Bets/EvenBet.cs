namespace RouletteRoulette.Roulette.Bets
{
    public record EvenBet : Bet
    {
        public override int Payout => 1;

        public override bool Hits(Pocket pocket)
        {
            return pocket != Pocket.G00 && pocket != Pocket.G0 && (int)pocket % 2 == 0;
        }
    }
}
