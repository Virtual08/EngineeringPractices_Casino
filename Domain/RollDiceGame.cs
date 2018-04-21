using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private List<Player> players = new List<Player>();
        private Casino casino = new Casino();

        public Casino Casino
        {
            get { return casino; }
        }

        public void AddPlayer(Player player)
        {
            if (players.Count == 6)
            {
                throw new TooManyPlayersException();
            }
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public virtual void Play(IDice dice)
        {
            var luckyScore = getLuckyScore(dice);
            foreach (var player in players)
            {
                for (int i = 0; i < player.CurrentBet.Count; i++)
                {
                    if (player.CurrentBet[i].Score == luckyScore)
                    {
                        player.Win(player.CurrentBet[i].Chips.Amount * 6, i);
                    }
                    else
                    {
                        player.Lose(player.CurrentBet[i].Chips,i);
                    }
                }
            }
        }

        public virtual int getLuckyScore(IDice dice)
        {
            return dice.GetLuckyScore();
        }
    }
}