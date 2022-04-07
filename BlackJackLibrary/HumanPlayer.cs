using System.Collections.Generic;

namespace BlackJackLibrary
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, int money) : base(name, money) { }

        public void MakeBet(int bet)
        {
            if(bet <= this.Money)
            {
                this.Bet = bet;
                this.Money -= bet;
            }
            else
            {
                this.Bet = this.Money;
                this.Money = 0;
            }
        }
    }
}
