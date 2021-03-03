using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public Queue<Card> Cards;
        public Deck()
        {
            Cards = new Queue<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Cards.Enqueue(new Card() { Rank = i, Suit = suit });
                }
            }
            

        }

        public Queue<Card> Shuffle(List<Card> deck)
        {
            return new Queue<Card>(deck.OrderBy(x => Guid.NewGuid()).ToList());
        }
    }
}
