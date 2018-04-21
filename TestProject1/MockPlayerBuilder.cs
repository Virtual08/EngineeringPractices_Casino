using Domain;
using Moq;

namespace TestProject1
{
    public class MockPlayerBuilder
    {
        private Mock<Player> _player = new Mock<Player>();
        private Chip _chips;
        private int _score;

        public Mock<Player> Please()
        {    
            if (_chips != null)
                _player.Object.Buy(_chips);

            if (_score != 0)
                _player.Object.Bet(new Bet(_chips, _score));
            
            return _player;
        }

        public MockPlayerBuilder In(RollDiceGame game)
        {
            _player.Object.Join(game);
            return this;
        }
        
        public MockPlayerBuilder WithChips(int chipsAmount)
        {
            _chips = new Chip(chipsAmount);
            return this;
        }

        public MockPlayerBuilder WithBet(int score)
        {
            _score = score;
            return this;
        }
        
        public static implicit operator Mock<Player>(MockPlayerBuilder fakeBuilder)
        {
            return fakeBuilder._player;
        }
    }
}