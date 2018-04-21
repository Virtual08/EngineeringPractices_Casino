using Domain;

namespace TestProject1
{
    public class RollDiceGameFake : RollDiceGame
    {
        public override int getLuckyScore(IDice dice)
        {
            return Score;
        }

        public int Score { get; set; }
    }
}