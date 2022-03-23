using System;

namespace RouletteRoulette.Roulette.Bets
{
    public record DozenBet : Bet
    {
        internal const int DOZENS = 3;
        public int Dozen { get; init; }

        public DozenBet(int dozen)
        {
            if (dozen <= 0 || DOZENS < dozen)
                throw new ArgumentException($"{nameof(Dozen)} must be in 1 to {DOZENS}", nameof(dozen));
            Dozen = dozen;
        }

        public override int Payout => 2;

        public override bool Hits(Pocket pocket)
        {
            if (pocket == Pocket.G0 || pocket == Pocket.G00)
                return false;

            return pocket.InRange(1 + (Dozen - 1) * 12, Dozen * 12);
        }
    }
}
