
using System.Collections;
using System.Reflection.Metadata;

namespace BlackJackTest
{
    public class Shoe
    {
        public static Random Random = new Random();
        public IList<Card> StackOfCards = new List<Card>();
        public IList<Card> Discard = new List<Card>();

        public void AddDeck()
        {
            foreach (Suit sut in Enum.GetValues<Suit>())
            {
                foreach (Names names in Enum.GetValues<Names>())
                {
                    int v = (int)names < 11 ? (int)names : 10;
                    Card c = new Card(names, v, sut);
                    StackOfCards.Add(c);
                }
            }

        }
        public void PrintStack()
        {

            foreach (var item in StackOfCards)
            {
                Console.WriteLine($"{item.Name} of {item.Suitt} {item.Value}");
            }
        }

        public static IList<Card> PerfectShuffle(IList<Card> cards)
        {
            List<Card> cd = new List<Card>();

            for (int i = 0; i < cards.Count / 2; i++)
            {
                cd.Add(cards[i]);
                cd.Add(cards[i + (cards.Count / 2)]);
            }
            return cd;

        }

        public static IList<Card> RandomShuffle(IList<Card> cards)
        {


            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
            return cards;
        }
        public Card GiveCard()
        {
            Card c = StackOfCards.First();
            StackOfCards.Remove(c);
            return c;
        }

        public void AddCardToDiscard(Card card)
        {
            Discard.Add(card);
        }

        public void ResetDecks()
        {
            foreach (var item in Discard)
            {
                StackOfCards.Add(item);
            }
            Discard.Clear();
        }

    }   
}