using Domain;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class CasinoTests
    {
        [Test]
        public void OnlyX5Bets_Game_Bet() //2.5 Я, как казино, принимаю только ставки, кратные 5
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .WithChips(51)
                .Please();
            
            Assert.AreEqual(-2, player.Bet(new Bet(player.GetAvailableChips(), 1)));
        }

        [Test]
        public void GetChipsThatPlayerLost_Casino_Win() //3.3 Я, как казино, получаю фишки, которые проиграл игрок
        {
            RollDiceGameFake game = Create
                .GameFake()
                .score(1)
                .Please();
            Player loser = Create
                .Player()
                .In(game)
                .WithChips(50)
                .WithBet(5)
                .Please();
            Dice dice = Create
                .Dice()
                .Please();
            
            game.Play(dice);
            
            Assert.AreEqual(10000+50, game.Casino.GetAvailableChips().Amount);
        }
    }
}