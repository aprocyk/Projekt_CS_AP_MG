using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJLogic
{
    public class CardDeck
    {
        public List<Card> initialDeck = CreateDeck();
        public List<Card> cards = new List<Card>();
        static Random rng = new Random(Environment.TickCount);
        public static int GetCardCount { get; private set; }

        public static List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            for (int i = 2; i <= Card.GetMaxSuit(); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var card = new Card();
                    card.cardNumber = i;
                    card.Color = (CardColor)j;
                    deck.Add(card);
                }
            }
            return deck;
        }

        public bool IsEmpty()
        {
            return cards.Count == 0;
        }

        public bool HasCards()
        {
            return !IsEmpty();
        }

        public int CardCount()
        {
            return cards.Count;
        }

        public void Shuffle(int cardCount)
        {
            cards = new List<Card>();

            for (int i = 0; i < cardCount; i++)
            {
                var index = rng.Next(0, initialDeck.Count - 1);
                var card = initialDeck[index];
                cards.Add(card);
                initialDeck.RemoveAt(index);
            }
            GetCardCount = initialDeck.Count;
        }

        public void Shuffle_new_deck()
        {
            initialDeck = CreateDeck();
            GetCardCount = initialDeck.Count;
        }


        public Card PickCard()
        {
            CheckNotEmpty();

            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public Card PickCard(int i)
        {
            CheckNotEmpty();

            var card = cards[i];

            return card;
        }

        private void CheckNotEmpty()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty!");
            }
        }
    }
}
