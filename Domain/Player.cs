using System;
using  System.Collections.Generic;

namespace Domain
{
    public class Player
    {
        private RollDiceGame currentGame;
        public bool IsInGame => currentGame != null;

        public Player()
        {
            CurrentBet = new List<Bet>();
        }

        public void Join(RollDiceGame game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }
            currentGame = game;
            currentGame.AddPlayer(this);
        }

        public void LeaveGame()
        {
            if (!IsInGame)
            {
                throw new InvalidOperationException();
            }
            currentGame.RemovePlayer(this);
            currentGame = null;
        }

        public virtual void Buy(Chip chips)
        {
            availableChips = chips;
            //casino.Buy(chips);
        }

        private Chip availableChips = new Chip(0);

        public int Chips
        {
            get { return availableChips.Amount; }
        }

        public virtual bool Has(Chip chips)
        {
            return availableChips >= chips;
        }

        public int Bet(Bet bet)
        {
            if (bet.Score < 1 || bet.Score > 6) return -1;

            if (!currentGame.Casino.multiple5(bet.Chips)) return -2;
            
            if(bet.Chips.Amount > availableChips.Amount)
                throw new Exception();
            
            availableChips = new Chip(availableChips.Amount - bet.Chips.Amount);
            
            CurrentBet.Add(bet);
            return availableChips.Amount;
        }

        public List<Bet> CurrentBet { get; private set; }

        public virtual void Win(int chipsAmount, int _i)
        {
            availableChips = new Chip(availableChips.Amount + chipsAmount); 
            CurrentBet[_i] = null;
        }

        public virtual void Lose(Chip _chip, int _i)
        {
            currentGame.Casino.Win(_chip.Amount);
            CurrentBet[_i] = null;
        }

        public Chip GetAvailableChips()
        {
            return availableChips;
        }
    }
}