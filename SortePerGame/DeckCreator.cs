using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SortePerGame
{
     class DeckCreator
    {
        private List<Card> cards;
        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        public List<Card> CreateDeckForSortePer()
        {
            Cards = CreateDeck();

            foreach (Card card in Cards.ToList())
            {
                if (card.CardSuit == Card.Suit.Spades && card.CardValue == (Card.Value) 10)
                {
                    Cards.Remove(card);
                }
            }
            return Cards;
        }

        // create a deck with 52 card
        public List<Card> CreateDeck()
        {
            Cards = new List<Card>();

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Cards.Add(new Card(i, j));
                }
            }
            return Cards;
        }
    }
}