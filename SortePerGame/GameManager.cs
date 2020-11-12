using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerGame
{
    class GameManager
    {
        static void Main(string[] args)
        {
            DeckCreator deckCreator = new DeckCreator();

            List<Card> deck = deckCreator.GetShuffledCards();


            foreach (var card in deck)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
