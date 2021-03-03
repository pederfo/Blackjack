using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
	static public class Library
	{
        static public int ComputeTotal(List<Card> hand)
        {
            bool ace = false;
            int total = hand.Sum(x => Math.Min(x.Rank, 10));
            foreach (var item in hand)
            {
                if (item.Rank == 1)
                {
                    ace = true;
                    break;
                }
            }
            if (ace)
            {
                total += 10;
            }
            if ((total > 21) && ace)
            {
                total -= 10;
            }
            return total;
        }

        static public void GameOver(int total, int dealerTotal, List<Card> hand, List<Card> dealerHand)
        {
			Console.WriteLine();
            Console.WriteLine("Your total: {0}, dealer total: {1}", total, dealerTotal);
            if ((total > dealerTotal) && total < 22)
            {
                Console.WriteLine("You won!");
            }
            else if ((total < dealerTotal) && dealerTotal < 22)
            {
                Console.WriteLine("Dealer won.");
            }
            else if (total == dealerTotal)
            {
                if (hand.Count < dealerHand.Count)
                {
                    Console.WriteLine("You won because you have less cards!");
                }
                else if (hand.Count > dealerHand.Count)
                {
                    Console.WriteLine("Dealer won because he have less cards.");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
            else
            {
                Console.WriteLine("Game over");
            }
		}
    }
}
