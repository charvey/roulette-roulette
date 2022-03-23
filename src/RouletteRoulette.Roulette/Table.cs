using RouletteRoulette.Roulette.Bets;
using System.Collections.Generic;
using System.Linq;

namespace RouletteRoulette.Roulette
{
    public abstract class Table
    {
        private IEnumerable<Bet> basicBets { get; } = new Bet[] {
            new BlackBet(), new RedBet(),
            new EvenBet(), new OddBet(),
            new HighBet(), new LowBet()
        };
        private IEnumerable<Bet> straightUpBets => Pockets.Select(p => new StraightUpBet(p));
        private IEnumerable<Bet> columnBets => Enumerable.Range(1, ColumnBet.COLUMNS).Select(c => new ColumnBet(c));
        private IEnumerable<Bet> dozenBets => Enumerable.Range(1, DozenBet.DOZENS).Select(d => new DozenBet(d));

        public abstract IEnumerable<Pocket> Pockets { get; }
        public IEnumerable<Bet> Bets => basicBets.Concat(straightUpBets).Concat(columnBets).Concat(dozenBets);
    }
}
