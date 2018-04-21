using System;

namespace Domain
{
    public class Bet
    {
        public Chip Chips { get; }
        public int Score { get; }

        public Bet(Chip chips, int score)
        {
            if(score < 0 && score > 7)
                throw new Exception();
            
            Chips = chips;
            Score = score;
        }
    }
}