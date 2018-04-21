using Domain;

namespace TestProject1
{
    public class BetBuilder
    {
        private Bet _bet;
        private Chip _chip;
        private int _score;

        public Bet Please()
        {
            _bet = new Bet(_chip, _score);
            return _bet;
        }

        public BetBuilder WithChip(int amount)
        {
            _chip = new Chip(amount);
            return this;
        }

        public BetBuilder WithScore(int score)
        {
            _score = score;
            return this;
        }
        
        public static implicit operator Bet(BetBuilder _builder)
        {
            return _builder._bet;
        }
    }
}