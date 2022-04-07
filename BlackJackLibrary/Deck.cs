using System;
using System.Collections.Generic;

namespace BlackJackLibrary
{
    public class Deck
    {
        Random random = new Random();
        private List<Card> cards = new List<Card>();
        private List<(string, int)> cardTypes = new List<(string, int)>();

        public Deck()
        {
            cardTypes.Add(("2", 2));
            cardTypes.Add(("3", 3));
            cardTypes.Add(("4", 4));
            cardTypes.Add(("5", 5));
            cardTypes.Add(("6", 6));
            cardTypes.Add(("7", 7));
            cardTypes.Add(("8", 8));
            cardTypes.Add(("9", 9));
            cardTypes.Add(("10", 10));
            cardTypes.Add(("J", 10));
            cardTypes.Add(("Q", 10));
            cardTypes.Add(("K", 10));
            cardTypes.Add(("A", 11));

            foreach(var type in cardTypes)
            {
                cards.Add(new Card(CardSuit.Clubs, type));
                cards.Add(new Card(CardSuit.Diamonds, type));
                cards.Add(new Card(CardSuit.Spades, type));
                cards.Add(new Card(CardSuit.Hearts, type));
            }
        }

        public Card GetRandomCard()
        {
            if (cards.Count == 0)
                throw new Exception("Колода пуста!");

            var r = random.Next(0, cards.Count);
            var card = cards[r];
            cards.RemoveAt(r);

            return card;
        }
    }
}
