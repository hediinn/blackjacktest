using System.Diagnostics;
using System.Reflection;
using static BlackJackTest.Shoe;
namespace BlackJackTest
{
    public class Game
    {
        Shoe shoe = new();
        private int _deckCount = 0 ;

        public Game(int deckCount)
        {
            _deckCount = deckCount;
            for (int i = 0; i < deckCount; i++)
            {
                shoe.AddDeck();
            }
        }

        public int DeckSize()
        {
            return shoe.Size();
        }

        public void ShuffleShoe()
        {
            shoe.StackOfCards = RandomShuffle(shoe.StackOfCards);
        }

        public void AddDiscardToDeck()
        {
            shoe.ResetDecks();
            Debug.Assert(shoe.Size() == _deckCount * 52);
        }

        public void ShuffleShoe(int coi)
        {
            shoe.StackOfCards = PerfectShuffle(shoe.StackOfCards);
            shoe.StackOfCards = RandomShuffle(shoe.StackOfCards);
            shoe.StackOfCards = PerfectShuffle(shoe.StackOfCards);
            for (int i = 2; i < coi; i++)
            {
                shoe.StackOfCards = RandomShuffle(shoe.StackOfCards);
                if (i % 2 == 0)
                {
                    shoe.StackOfCards = PerfectShuffle(shoe.StackOfCards);
                }
            }

        }

        private void GivePlayerACard(IPlayer player1)
        {
            player1.TakeCard(shoe.GiveCard());
        }

        public void GivePlayerAHand(IPlayer player1)
        {

            player1.TakeCard(shoe.GiveCard());
            player1.TakeCard(shoe.GiveCard());
        }

        public bool PlayRound(IPlayer activePlayer,IList<IPlayer> opponents)
        {
            int cou = 0;
            foreach (var item in opponents)
            {
                if (activePlayer.WantCard(item))
                {
                    cou += 1;
                }
            }
            if (cou > 0)
            {
                GivePlayerACard(activePlayer);
            }

            if (Utils.IsPlayerFinished(activePlayer))
            {
                return false;
            }
            return true;
        }

        public void GiveHandBack(Hand cards)
        {
            foreach (var item in cards)
            {
                shoe.AddCardToDiscard(item);
            }
            Debug.Assert(cards.ResetHand() == 0);
        }
    }   
}
