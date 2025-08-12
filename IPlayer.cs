
namespace BlackJackTest
{
    public interface IPlayer
    {
        void Bet();
        bool CanSplit();
        int KnownScore();
        PlayerState GetPlayerState();

        void PayOut(int money);

        public void TakeCard(Card c);

        public void PrintHand();

        bool WantCard(IPlayer opponents);

        string GetName();

    }

    public enum PlayerState
    {
        EmptyHand,
        OneCard,
        NewHand,
        Bust,
        TwentyOne,
        Stand
    }
}