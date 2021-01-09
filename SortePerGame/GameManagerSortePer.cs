using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SortePerGame
{
    class GameManagerSortePer
    {
        public void DealCardsToPlayers(List<Card> shuffledDeck, Player[] players)
        {
            while (shuffledDeck.Count != 0)
            {
                foreach (Player player in players)
                {
                    if (shuffledDeck.Count == 0)
                    {
                        return;
                    }

                    player.DrawFromDeck(shuffledDeck.First());
                    shuffledDeck.RemoveAt(index: 0);
                }
            }
        }

        public void CheckForPair(Player player)
        {
            if (player.Hand.Count == 0)
            {
                return;
            }
            for (int i = 0; i < player.Hand.Count; i++)
            {
                foreach (Card card in player.Hand.ToList())
                {
                    if (card.CardValue == player.Hand[i].CardValue && card.CardSuit != player.Hand[i].CardSuit)
                    {
                        if (card.CardColor == player.Hand[i].CardColor)
                        {
                            Console.WriteLine("found pair " + card.ToString());
                            player.Hand.Remove(card);
                            player.Hand.Remove(player.Hand[i]);
                            
                        }
                    }
                }
            }
        }


        public List<Card> ShuffleDeck(List<Card> card)
        {
            List<Card> shuffledDeck = card.OrderBy(a => Guid.NewGuid()).ToList();
            return shuffledDeck;
        }
    }
}