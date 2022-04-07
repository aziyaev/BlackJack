using System;
using System.Windows.Media;

namespace BlackJackLibrary
{
    public class Card
    {
        public string Label { get; set; }
        public string Sign { get; set; }
        public int Points { get; set; }
        public CardSuit Suit { get; set; }
        public Brush Brush { get; set; }

        public Card(CardSuit suit, (string label, int points) tuple)
        {
            Suit = suit;
            Label = tuple.label;
            Points = tuple.points;

            switch (suit)
            {
                case CardSuit.Clubs:
                    Sign = "♣";
                    Brush = Brushes.Black;
                    break;
                case CardSuit.Diamonds:
                    Sign = "♦";
                    Brush = Brushes.Red;
                    break;
                case CardSuit.Spades:
                    Sign = "♠";
                    Brush = Brushes.Black;
                    break;
                case CardSuit.Hearts:
                    Sign = "♥";
                    Brush = Brushes.Red;
                    break;
                default:
                    break;
            }
        }
    }
}
