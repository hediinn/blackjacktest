
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
            return player.GetPlayerState() switch
            {
                PlayerState.Bust or PlayerState.Stand or PlayerState.TwentyOne => true,
                _ => false,
            };
        }
        public static void WhoWon(IPlayer player, IPlayer opponents)
        {
            
            if (player.GetPlayerState() == PlayerState.Bust ||
                player.KnownScore() < opponents.KnownScore() &&
                opponents.GetPlayerState() != PlayerState.Bust
          )
            {
                Console.WriteLine($"{opponents.GetName()} has won");
            }
            else
            {
                Console.WriteLine($"{player.GetName()} has won");
            }

        }
    }
}