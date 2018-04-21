using Domain;

namespace TestProject1
{
    public class DiceFakeBuilder
    {
        private DiceFake _dice = new DiceFake();

        public DiceFake Please()
        {
            return _dice;
        }

        public DiceFakeBuilder Score(int _score)
        {
            _dice.Score = _score;
            return this;
        }
        
        public static implicit operator DiceFake(DiceFakeBuilder _builder)
        {
            return _builder._dice;
        }
    }
}