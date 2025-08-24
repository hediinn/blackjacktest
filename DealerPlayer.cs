


namespace BlackJackTest
{
    public class DealerPlayer : IPlayer
    {
        int current_count = 0;

        private readonly int standVal = 17;

        private string _name = "";
        private Hand _cards = new();

        private PlayerState playerState = PlayerState.EmptyHand;

        public DealerPlayer()
        {
            _name = "Dealer";
        }
        public void Bet()
        {
            throw new NotImplementedException();
        }

        public bool CanSplit()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return _name;
        }

        public PlayerState GetPlayerState()
        {
            return playerState;
        }

        public int KnownScore()
        {
            if (playerState == PlayerState.Dealer)
            {
                return _cards.First().Value;
            }
            else
            {
                return Utils.ScoreHand(_cards);
            }
        }

        public void PayOut(int money)
        {
            throw new NotImplementedException();
        }

        public void PrintHand()
        {
            if (playerState == PlayerState.Dealer)
            {
                Console.WriteLine($"{_cards.First().StringOfMe()}");
            }
            else
            {
                foreach (Card item in _cards)
                {
                    Console.WriteLine($"{item.StringOfMe()}");
                }
            }
        }

        public void TakeCard(Card c)
        {
            _cards.Add(c);
            current_count = Utils.ScoreHand(_cards);
            if (_cards.Count() < 2)
            {
                playerState = PlayerState.OneCard;
            }
            else if (_cards.Count() == 2)
            {
                playerState = PlayerState.Dealer;
            }

        }

        public bool WantCard(IPlayer opponents)
        {

            bool iWantCard = true;
            if (playerState == PlayerState.Dealer)
            {
                playerState = PlayerState.NewHand;
            }
            if (opponents.KnownScore() > KnownScore())
            {
                iWantCard = true;
            }
            if (KnownScore() > standVal)
            {
                playerState = PlayerState.Stand;
                iWantCard = false;
            }
            if (current_count > 21)
            {
                playerState = PlayerState.Bust;
                iWantCard = false;
            }
            else if (current_count == 21)
            {
                playerState = PlayerState.TwentyOne;
                iWantCard = false;
            }
            if (opponents.GetPlayerState() == PlayerState.Bust)
            {
                iWantCard = false;
            }
            return iWantCard;

        }
        public Hand GetHand()
        {
            return _cards;
        }
    }


}