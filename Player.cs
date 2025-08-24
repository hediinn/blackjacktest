namespace BlackJackTest
{
    public class Player : IPlayer
    {
        int current_count = 0;
        private readonly int standVal = 16;
        private string _name = "";
        private Hand _cards = new();
        private PlayerState playerState = PlayerState.EmptyHand;

        public Player(string n)
        {
            _name = n;            
        }

        public void Bet()
        {
            throw new NotImplementedException();
        }

        public bool CanSplit()
        {
            if (_cards.Count() != 2)
            {
                return false;
            }
            Card card1 = _cards.First();
            int counst = _cards.Count(e => e.Value == card1.Value);
            if (counst == 2)
            {
                return true;
            }
            return false;
        }

        public PlayerState GetPlayerState()
        {
            return playerState;
        }

        public int KnownScore()
        {
            return Utils.ScoreHand(_cards);
        }

        public void PrintHand()
        {
            foreach (Card item in _cards)
            {
                Console.WriteLine($"{item.StringOfMe()}");

            }
        }

        public void PayOut(int money)
        {
            throw new NotImplementedException();
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
                playerState = PlayerState.NewHand;
            }
            if (current_count > 21)
            {
                playerState = PlayerState.Bust;
            }
            else if (current_count == 21)
            {
                playerState = PlayerState.TwentyOne;
            }
        }
        
        public bool WantCard(IPlayer opponent)
        {
            bool iWantCard = true;
            if (opponent.KnownScore() > KnownScore())
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
            if (opponent.GetPlayerState() == PlayerState.Bust)
            {
                iWantCard = false;
            }
            return iWantCard;
       }

        public string GetName()
        {
            return _name;
        }

        public Hand GetHand()
        {
            return _cards;
        }
    }
}
