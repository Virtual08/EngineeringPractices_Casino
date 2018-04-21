using Domain;

namespace TestProject1
{
    public class GameFakeBuilder
    {
        private RollDiceGameFake _game = new RollDiceGameFake();

        public RollDiceGameFake Please()
        {
            return _game;
        }

        public GameFakeBuilder score(int n)
        {
            _game.Score = n;
            return this;
        }

        public GameFakeBuilder GameWithPlayers(int gamers)
        {
            for (int i = 0; i < gamers; i++)
            {
                Player player = Create
                    .Player()
                    .In(_game);
            }

            return this;
        }
        
        public static implicit operator RollDiceGameFake(GameFakeBuilder fakeBuilder)
        {
            return fakeBuilder._game;
        }
    }
}