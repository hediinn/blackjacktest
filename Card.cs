namespace BlackJackTest
{
    public enum Suit
    {
        Spade, Heart,
        Diamond, Club
    }
    public enum Names
    {
        Ace = 1, Two, Three,
        Four, Five, Six,
        Seven, Eight, Nine,
        Ten, Jack, Queen, King
    }
    public class Card
    {
        public Card(Names name, int value, Suit s)
        {
            this.Name = name;
            this.Value = value;
            this.Suitt = s;
        }

        public int Value { get; set; }
        public Names Name { get; }
        public Suit Suitt { get; }

        public string StringOfMe()
        {
            return $"{Name} of {Suitt} {Value}";   
        }
    }
}
