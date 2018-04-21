using Domain;

namespace TestProject1
{
    public class DiceBuilder
    {
        private Dice _dice = new Dice();

        public Dice Please()
        {
            return _dice;
        }
        
        public static implicit operator Dice(DiceBuilder _builder)
        {
            return _builder._dice;
        }
    }
}