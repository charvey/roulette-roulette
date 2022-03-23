namespace RouletteRoulette.Roulette.Bets
{
    public record StraightUpBet(Pocket Pocket) : Bet
    {
        public override int Payout => 35;

        public override bool Hits(Pocket pocket) => pocket == Pocket;
    }
}
