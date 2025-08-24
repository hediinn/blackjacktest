using System.Diagnostics;

namespace BlackJackTest
{
    public class Table
    {
        private List<IPlayer> _players = new();
        private List<IPlayer> _dealer;
        private Game _game;
        private List<int> wins = [0,0,0];

        public Table(List<IPlayer> players, List<IPlayer> dealer, Game game)
        {
            _players = players;
            _dealer = dealer;
            _game = game;
        }

        private bool AreAllPlayersDone()
        {
            int coun = 0;
            foreach (var item in _players)
            {
                if (Utils.IsPlayerFinished(item))
                {
                    coun += 1;
                }
            }
            return coun == _players.Count;
        }

        private IPlayer? GiveUndonePlayer()
        {
            foreach (var item in _players)
            {
                if (!Utils.IsPlayerFinished(item))
                {
                    return item;
                }
            }
            return null;
        }

        private List<IPlayer> GiveDealer()
        {
            return _dealer;
        }
        private List<IPlayer> GetPlayers()
        {
            return _players;
        }

        internal void Shuffle()
        {
            _game.ShuffleShoe();
        }

        internal void GiveHandsToPlayers()
        {
            foreach (var item in _dealer)
            {
                _game.GivePlayerAHand(item);
            }
            foreach (var item in _players)
            {
                _game.GivePlayerAHand(item);
            }
        }

        internal void Shuffle(int v)
        {
            _game.ShuffleShoe(v);
        }

        public Game GetGame()
        {
            return _game;
        }

        public void PlayAGame()
        {
            bool state = true;

            while (!AreAllPlayersDone())
            {
                IPlayer? active = GiveUndonePlayer();
                while (state && active != null)
                {
                    state = GetGame().PlayRound(active, GiveDealer());
                }
                state = !AreAllPlayersDone();
            }

            for (int i = 0; i < 30; i++)
            {
                GetGame().PlayRound(GiveDealer().First(), GetPlayers());
            }
            if (false)
            {
                foreach (var item in GetPlayers())
                {
                    item.PrintHand();
                    Console.WriteLine($"{item.GetPlayerState()}");
                    Console.WriteLine($"{item.KnownScore()}");
                    Console.WriteLine($"{item.GetName()}");
                    Console.WriteLine("---------------------------------");
                }

                GiveDealer().First().PrintHand();


            }
            Console.WriteLine("#---------------------------------#");
            foreach (var item in GetPlayers())
            {
                IPlayer winningPlayer = Utils.WhoWon(item, GiveDealer().First());
                if (winningPlayer == item)
                {
                    item.PayOut(5);
                    GiveDealer().First().PayOut(-5);
                }
                else
                {
                    item.PayOut(-5);
                    GiveDealer().First().PayOut(5);
                }
                Console.WriteLine($"{winningPlayer.GetName()} Won");
            }
            
            Console.WriteLine("#---------------------------------#");

            foreach (var item in GetPlayers())
            {
                Console.WriteLine($"{item.GetName()} : {item.Money()}");
            }
            Console.WriteLine($"{GiveDealer().First().GetName()} : {GiveDealer().First().Money()}");
            Console.WriteLine("#---------------------------------#");
        }

        public int ResetDecks()
        {
            _game.AddDiscardToDeck();
            return _game.DeckSize();
        }

        public void ResetGame()
        {
            foreach (var item in _dealer)
            {
                _game.GiveHandBack(item.GetHand());
                Debug.Assert(item.GetHand().Count() == 0);
            }

            foreach (var item in _players)
            {
                _game.GiveHandBack(item.GetHand());
                Debug.Assert(item.GetHand().Count() == 0);
            }
        }
    }   
}