using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_initialized : Scenario
    {
        private Deck _deck;
        private List<Card> _hand;
        public override void When()
        {
            _deck = new Deck();
        }

		public override void Given()
		{
            _hand = new List<Card>();
		}

		[Test]
        public void Should_have_52_cards()
        {
            Assert.AreEqual(52, _deck.Cards.Count);
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            Assert.AreEqual(4, _deck.Cards.Select(x => (int)x.Suit).Distinct().ToList().Count);
        }

        [Test]
        public void Compute_correct_total_with_big_ace()
		{
            Card card1 = new Card() { Rank = 1, Suit = Suit.Hearts };
            Card card2 = new Card() { Rank = 5, Suit = Suit.Hearts };
            _hand.Add(card1);
            _hand.Add(card2);
			var total = Library.ComputeTotal(_hand);
            Assert.AreEqual(16, total);
		}

        [Test]
        public void Compute_correct_total_with_small_ace()
        {
            Card card1 = new Card() { Rank = 2, Suit = Suit.Hearts };
            Card card2 = new Card() { Rank = 12, Suit = Suit.Hearts };
            Card card3 = new Card() { Rank = 1, Suit = Suit.Hearts };
            _hand.Add(card1);
            _hand.Add(card2);
            _hand.Add(card3);
            var total = Library.ComputeTotal(_hand);
            Assert.AreEqual(13, total);
        }
    }
}
