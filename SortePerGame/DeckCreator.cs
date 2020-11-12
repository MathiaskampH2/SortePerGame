using System;
using System.Collections.Generic;
using System.Dynamic;

namespace SortePerGame
{
    public class DeckCreator
    {
        public List<Card> ListOfCards;
        public List<Card> tempList;
        private Random random = new Random();


        public int rng(int min, int max)
        {
            return random.Next(min, max);
        }


        public List<Card> CreateDeckOfCards()
        {
            ListOfCards = new List<Card>();

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    ListOfCards.Add(new Card(i, j));
                }
            }

            return ListOfCards;
        }


        public List<Card> ShuffleCards(List<Card> cardList)
        {
            for (int i = 0; i < ListOfCards.Count; i++)
            {
                Card tempList = cardList[i];

                int index = rng(0, cardList.Count);

                cardList[i] = cardList[index];

                cardList[index] = tempList;
            }

            return tempList;
        }

        public List<Card> GetShuffledCards()
        {

            ListOfCards = CreateDeckOfCards();

            tempList = new List<Card>();

            tempList = ShuffleCards(ListOfCards);

            return tempList;
        }


        //public List<Card> CreateShuffledDeck(List<Card> cardList)
        //{

        //    ListOfCards = new List<Card>();

        //    ListOfCards = GetShuffledCards(CreateShuffledDeck());

        //}

    }
}