

using static BlackJackTest.Shoe;
namespace BlackJackTest
{

    public class Game
    {

        Shoe shoe = new();

        public Game(int deckCount)
        {
            for (int i = 0; i < deckCount; i++)
            {
                shoe.AddDeck();
            }
        }
        public void ShuffleShoe()
        {
            shoe.StackOfCards = RandomShuffle(shoe.StackOfCards);
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
        public void GivePlayerACard(IPlayer player1)
        {

            player1.TakeCard(shoe.GiveCard());
        }
        public void GivePlayerAHand(IPlayer player1)
        {

            player1.TakeCard(shoe.GiveCard());
            player1.TakeCard(shoe.GiveCard());
        }

        public bool PlayRound(List<IPlayer> players)
        {
            IPlayer player = players.Last();
            IPlayer player2 = players.First();

            if (player.WantCard(player2))
            {
                GivePlayerACard(player);
            }
            if (Utils.IsPlayerFinished(player))
            {
                Console.WriteLine("---------------------------------");
                return false;
            }
            return true;
        }

    }   
}