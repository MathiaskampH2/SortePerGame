using System.Dynamic;

namespace SortePerGame
{
    public class Card
    {
        private Suit suit;

        public Suit Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        private Value value;

        public Value Value
        {
            get { return value; }
            set { value = value; }
        }


        public override string ToString()
        {
            return
                suit + " :" + value;
        }


        public Card(int IntSuit, int intValue)
        {
            this.suit = (Suit) IntSuit;

            this.value = (Value) intValue;
        }
    }
}