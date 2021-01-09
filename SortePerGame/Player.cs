using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SortePerGame
{
    public class Player
    {
        public List<Card> Hand { get; set; }

        public Player(List<Card> hand)
        {
            this.Hand = hand;
        }

        public void DrawFromDeck(Card card)
        {
            Hand.Add(card);
        }


        public void DrawCardFromPlayer(Player player, int index)
        {
            if (Hand.Count == 0)
            {
                return;
            }
            else
            {
                Hand.Add(player.Hand.ElementAt(index));
                player.Hand.RemoveAt(index);
            }
                
        }
    }
}