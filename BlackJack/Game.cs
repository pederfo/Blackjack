using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack
{
	public class Game
	{
        public void Play()
        {
            var deck = new Deck();
            var hand = new List<Card>();
            var dealerHand = new List<Card>();

            // randomize
            var shuffledDeck = deck.Shuffle(deck.Cards.ToList());

            // Initial draw_
            for (int i = 0; i < 2; i++)
            {
                hand.Add(shuffledDeck.Dequeue());
                dealerHand.Add(shuffledDeck.Dequeue());
            }

            var dealerTotal = Library.ComputeTotal(dealerHand);
            var total = Library.ComputeTotal(hand);
            Console.WriteLine("Your hand: {0} {1}, {2} {3}. Total is {4}", hand[0].Suit, hand[0].Rank, hand[1].Suit, hand[1].Rank, total);
            Console.WriteLine("Dealers hand: {0} {1}, {2} {3}. Total is {4}", dealerHand[0].Suit, dealerHand[0].Rank, dealerHand[1].Suit, dealerHand[1].Rank, dealerTotal);

            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();

                if (read.ToLower() == "hit")
                {
                    var card = shuffledDeck.Dequeue();
                    hand.Add(card);

                    total = Library.ComputeTotal(hand);
                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.Rank, total);
                    if (total > 21)
                    {
                        Console.WriteLine("Total is above 21.");
                        break;
                    }
                }
                else if (read.ToLower() == "stand")
                {
                    // dealers turn
                    Thread.Sleep(500);
                    Console.WriteLine("Dealers turn.");
                    for (int i = 2; i < deck.Cards.Count(); i++)
                    {

                        if (dealerTotal > 15)
                        {
                            Console.WriteLine("Dealer stands");
                            break;
                        }
                        else if (dealerTotal > 21)
                        {
                            Console.WriteLine("Dealer is bust");
                            break;
                        }

                        var card = shuffledDeck.Dequeue();
                        dealerHand.Add(card);
                        dealerTotal = Library.ComputeTotal(dealerHand);
                        Console.WriteLine("Dealer draw {0} {1}. Total is {2}", card.Suit, card.Rank, dealerTotal);

                    }
                    break;
                }
            }
            Thread.Sleep(500);
            Library.GameOver(total, dealerTotal, hand, dealerHand);
            AnotherGame();
        }

        public void AnotherGame()
        {
            Console.WriteLine("Play again? (y)");
            var input = Console.ReadLine();

            switch (input)
            {
                case "y":
                    Console.Clear();
                    Play();
                    break;
                default:
                    break;
            }
        }
    }
}
