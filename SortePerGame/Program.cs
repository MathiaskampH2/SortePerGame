using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortePerGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to sorte per");
            Thread.Sleep(2000);
            Console.Clear();
            Console.Write("Would you like to play a game Y/N :");
            char userInput = Convert.ToChar(Console.ReadLine());
            GameManagerSortePer gameManagerSortePer = new GameManagerSortePer();
            DeckCreator deckCreator = new DeckCreator();
            List<Card> deckForSortePer = deckCreator.CreateDeckForSortePer();
            List<Card> shuffledDeckSortePer = gameManagerSortePer.ShuffleDeck(deckForSortePer);
            Player[] player = new Player[2];
            player[0] = new Player(new List<Card>());
            player[1] = new Player(new List<Card>());
            gameManagerSortePer.DealCardsToPlayers(shuffledDeckSortePer, player);
            gameManagerSortePer.CheckForPair(player[0]);
            gameManagerSortePer.CheckForPair(player[1]);
            Random rand = new Random();
         
            bool gameOver = false;
            switch (userInput)
            {
                case 'Y':
                    while (!gameOver)
                    {
                        int player1Cards = player[1].Hand.Count;
                        if (player1Cards > 1)
                        {
                            Console.WriteLine("player 0 : choose number between 0 and " + player1Cards);
                            int player0ChooseCardFromPlayer1 = rand.Next(0, player1Cards);
                            Console.WriteLine("you've choose " + player0ChooseCardFromPlayer1);
                            player[0].DrawCardFromPlayer(player[1], player0ChooseCardFromPlayer1);
                            gameManagerSortePer.CheckForPair(player[0]);
                            Console.WriteLine("player 0's turn is over");
                            Thread.Sleep(1000);
                        }
                        if (player[0].Hand.Count == 1 && player[0].Hand.First().CardValue == Card.Value.Jack && player[0].Hand.First().CardSuit == Card.Suit.Clubs)
                        {
                            Console.WriteLine("gameover player0 lost");
                            Thread.Sleep(5000);
                            gameOver = true;
                        }
                        
                        int player0Cards = player[0].Hand.Count;
                        if (player0Cards > 1)
                        {
                            Console.WriteLine("Player 1 : choose number between 0 and " + player0Cards);
                            int player1ChooseCardFromPlayer0 = rand.Next(0, player0Cards);
                            Console.WriteLine("Player 1 choose :" + player1ChooseCardFromPlayer0);
                            player[1].DrawCardFromPlayer(player[0], player1ChooseCardFromPlayer0);
                            gameManagerSortePer.CheckForPair(player[1]);
                            Console.WriteLine("player 0's turn is over");
                            Thread.Sleep(1000);
                        }
                        if (player[1].Hand.Count == 1 && player[1].Hand.First().CardValue == Card.Value.Jack && player[1].Hand.First().CardSuit == Card.Suit.Clubs)
                        {
                            Console.WriteLine("gameover player1 lost");
                            Thread.Sleep(5000);
                            gameOver = true;

                        }

                        Thread.Sleep(1000);
                    }
                    break;
                case 'N':
                    Console.Clear();
                    Thread.Sleep(2000);
                    Console.WriteLine("Bye");
                    break;
            }
        }
    }
}