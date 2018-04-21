using Domain;
using Moq;

namespace TestProject1
{
    public class PlayerBuilder
    {
        private Player _player = new Player();
        private Chip _chips;
        private int _score = 0;
        private int chipamountforsixbets;

        public Player Please()
        {   
            if (_chips != null)
                _player.Buy(_chips);

            if (_score == -7)
            {
                for (int i = 1; i < 7; i++)
                {
                _player.Bet(new Bet(new Chip(chipamountforsixbets), i));
                }
            }
            else if (_score > -17 && _score < -10)
            {
                int j = 0;
                for (int i = 1; i < 7; i++)
                {
                    if (j < 3 && i != _score * -1 - 10)
                    {
                        _player.Bet(new Bet(new Chip(chipamountforsixbets), i));
                        j++;
                    }
                    else
                    {
                        _player.Bet(new Bet(new Chip(chipamountforsixbets), _score * -1 - 10));
                    }
                }
            }
            else if (_score > -7 && _score < 0)
            {
                for (int i = 1; i < 7; i++)
                {
                    _player.Bet(new Bet(new Chip(chipamountforsixbets), _score*-1));
                }
            }
            else if (_score > 0)
                _player.Bet(new Bet(_chips, _score));
            
            return _player;
        }

        public PlayerBuilder In(RollDiceGame game)
        {
            _player.Join(game);
            return this;
        }

        public PlayerBuilder WithChips(int chipsAmount)
        {
            _chips = new Chip(chipsAmount);
            return this;
        }

        public PlayerBuilder WithBet(int score)
        {
            _score = score;
            return this;
        }

        public PlayerBuilder WithSixBetsOnSixScore(int chipsamount)
        {
            chipamountforsixbets = chipsamount;
            _score = -7;
            return this;
        }

        public static implicit operator Player(PlayerBuilder _builder)
        {
            return _builder._player;
        }

        public PlayerBuilder WithSixBetsOnOneScore(int chipsamount, int score)
        {
            chipamountforsixbets = chipsamount;
            _score = score*-1;
            return this;
        }

        public PlayerBuilder WithBetsOnDifferentScoreWhenTreeBetsOnOneNumber(int chipsamount,int score)
        {
            chipamountforsixbets = chipsamount;
            _score = score*-1-10;
            return this;
        }
    }
}