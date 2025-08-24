using System.Collections;

namespace BlackJackTest
{
    public class Hand : IEnumerable<Card>
    {
        private IList<Card> hand = new List<Card>();

        public void Add(Card c)
        {
            hand.Add(c);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            foreach (Card item in hand)
            {
                yield return item;
            }
        }
   
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int ResetHand()
        {
            hand.Clear();
            return hand.Count;    
        }
    }   
}