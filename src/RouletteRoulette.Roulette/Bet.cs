namespace RouletteRoulette.Roulette
{
    public abstract record Bet
    {
        public abstract int Payout { get; }
        public abstract bool Hits(Pocket pocket);
    }

    /* TODO:
     * Row
     * Split
     * Street
     * Corner
     * Basket (US)
     * Basket (Euro)
     * Double Street
     */
}
