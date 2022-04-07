namespace BlackJackLibrary
{
    public class Dealer : Player, IBot
    {
        private Deck deck;

        public Dealer() : base("Pepe The Dealer", 5000)
        {
            this.deck = new Deck();
        }

        public Card GiveCard()
        {
            return this.deck.GetRandomCard();
        }

        public void ShuffleCards()
        {
            this.deck = new Deck();
        }

        public void MakeAutoMove(int score)
        {
            if(this.Score < 21 || this.Score < score)
            {
                PickCard(GiveCard());
            }
        }

    }
}
