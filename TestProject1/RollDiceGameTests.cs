using NUnit.Framework;
using Domain;

namespace TestProject1
{
    [TestFixture]
    public class RollDiceGameTests
    {
        [Test]
        public void NoMoreThanSixPlayer_Game_AddPlayer() //1.5 Я, как игра, не позволяю войти более чем 6 игрокам
        {
            RollDiceGameFake game = Create
                .GameFake()
                .GameWithPlayers(6);
            Player player = Create
                .Player();
            
            Assert.That(()=>game.AddPlayer(player), Throws.Exception);  // +1 => exception
        }
    }
}