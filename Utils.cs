
namespace BlackJackTest
{
    public static class Utils
    {

        public static int ScoreHand(Hand h)
        {
            int score = 0;
            int aceCount = 0;
            foreach (Card item in h)
            {
                if (item.Name == Names.Ace)
                {
                    aceCount++;
                }
                score += item.Value;
            }
            if (aceCount > 0 && score < 12)
            {
                score += 10;
            }
            return score;
        }

        public static bool IsPlayerFinished(IPlayer player)
        {
            switch (player.GetPlayerState())
            {
                case PlayerState.Bust:
                case PlayerState.Stand:
                case PlayerState.TwentyOne:
                    return true;

                default:
                    return false;
            }

        }
        public static void WhoWon(IList<IPlayer> players)
        {
            IPlayer player = players.Last();
            IPlayer player2 = players.First();
            if (player.GetPlayerState() == PlayerState.Bust ||
                player.KnownScore() < player2.KnownScore() &&
                player2.GetPlayerState() != PlayerState.Bust
          )
            {
                Console.WriteLine($"{player2.GetName()} has won");
            }
            else
            {
                Console.WriteLine($"{player.GetName()} has won");
            }

        }
    }
}