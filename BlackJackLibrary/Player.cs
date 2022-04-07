using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BlackJackLibrary
{
    public abstract class Player : IPlay, INotifyPropertyChanged
    {
        private int money;
        private int bet;
        private int score;

        public event PropertyChangedEventHandler PropertyChanged;


        public string Name { get; set; }
        public ObservableCollection<Card> CardSet { get; set; }
        public int Money { get { return money; } set { money = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money))); } }
        public int Bet { get { return bet; } set { bet = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bet))); } }
        public int Score { get { return score; } set { score = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score))); } }

        protected Player(string name, int money)
        {
            Name = name;
            Money = money;
            CardSet = new ObservableCollection<Card>();
        }

        public void PickCard(Card card)
        {
            CardSet.Add(card);
            Score += card.Points;

            if (Score <= 21)
            {
                return;
            }

            Score = 0;
            int A_num = 0;
            foreach (var crd in CardSet)
            {
                if (crd.Points == 11)
                {
                    Score++;
                    A_num++;
                }
                else
                    Score += crd.Points;
            }

            while(Score <= 11 && A_num > 0)
            {
                Score += 10;
                A_num--;
            }
        }

        public void DiscardSet()
        {
            this.CardSet.Clear();
            this.Score = 0;
        }
    }
}
