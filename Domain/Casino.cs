using System.ComponentModel;
using NUnit.Framework.Internal.Execution;

namespace Domain
{
    public class Casino
    {
        private Chip availableChips = new Chip(10000);
        
        public Chip GetAvailableChips()
        {
            return availableChips;
        }

        public void Win(int PlayerBetChipsAmount)
        {
            availableChips = new Chip(availableChips.Amount + PlayerBetChipsAmount);
        }

        public void Buy(Chip chip)
        {
            availableChips = new Chip(availableChips.Amount - chip.Amount);
        }

        public bool multiple5(Chip chip)
        {
            if (chip.Amount % 5 == 0)
                return true;
            else
                return false;
        }
    }
}