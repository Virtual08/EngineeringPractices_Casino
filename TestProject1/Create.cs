namespace TestProject1
{
    public static class Create
    {
        public static PlayerBuilder Player()
        {
            return new PlayerBuilder();
        }

        public static GameFakeBuilder GameFake()
        {
            return new GameFakeBuilder();
        }

        public static DiceFakeBuilder DiceFake()
        {
            return new DiceFakeBuilder();
        }

        public static DiceBuilder Dice()
        {
            return new DiceBuilder();
        }

        public static MockPlayerBuilder MockPlayer()
        {
            return new MockPlayerBuilder();
        }

        public static BetBuilder Bet()
        {
            return new BetBuilder();
        }
    }
}