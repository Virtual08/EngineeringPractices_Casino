using System;
using System.ComponentModel;
using System.Diagnostics;
using NUnit.Framework;
using Domain;
using Moq;

namespace TestProject1
{
    [TestFixture]
    public class PlayerTests
    {
        public Player CreatePlayerInGame()
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .Please();
            
            return player;
        }

        public Player PlayerInGameWithChips(int chipsamount)
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .WithChips(1000)
                .Please();

            return player;
        }
        
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        
        [Test]
        public void Join_Player_IsInGame() // 1.1 Я, как игрок, могу войти в игру
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create 
                .Player()
                .In(game)
                .Please();
            
            Assert.AreEqual(true, player.IsInGame);
        }

        [Test]
        public void Leave_Player_LeaveGame() // 1.2 Я, как игрок, могу выйти из игры
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .Please();
            
            player.LeaveGame();
            
            Assert.AreEqual(false, player.IsInGame);
        }

        [Test]
        public void CanNotLeaveIfDidNotJoin_Player_LeaveGame() // 1.3 Я, как игрок, не могу выйти из игры, если я в нее не входил
        {
            Player player = Create
                .Player()
                .Please();
                        
            Assert.That(()=>player.LeaveGame(), Throws.Exception);
        }

        [Test]
        public void ICanPlayOnlyOneGameAtATime_Player_Join() // 1.4 Я, как игрок, могу играть только в одну игру одновременно
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .Please();
            
            Assert.That(()=>player.Join(game), Throws.InvalidOperationException);
        }

        [Test]
        public void CanBuyChipsToBet_Player_Bet() // 2.1 Я, как игрок, могу купить фишки у казино, чтобы делать ставки
        {
            RollDiceGameFake game = Create
                .GameFake()
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .WithChips(500)
                .Please();
            Bet bet = Create
                .Bet()
                .WithChip(500)
                .WithScore(5)
                .Please();

            player.Bet(bet);
            
            Assert.AreEqual(bet, player.CurrentBet[0]);
        }

        [Test]
        public void Play_Winner_ShouldGetMoreChips() // 2.2 Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
        {   
            RollDiceGameFake game = Create
                .GameFake()
                .score(5)
                .Please();
            Player player = Create
                .Player()
                .In(game)
                .WithChips(500)
                .WithBet(5)
                .Please();            
            Dice dice = Create
                .Dice()
                .Please();

            game.Play(dice);
            
            Assert.AreEqual(true, player.Has(new Chip(1000)));
        }
        /*
        [Test]
        public void WhenPlay_WithWinner_GameShouldCallWin_Mocks() // 2.2.1 Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
        {
            RollDiceGameFake game = Create
                .Game()
                .score(5)
                .Please();
            DiceFake dice = Create
                .Dice()
                .Please();
            Mock<Player> winner = Create
                .MockPlayer()
                .In(game)
                .WithChips(10)
                .WithBet(5)
                .Please();
            winner.Setup(x => x.Buy(It.IsAny<Chip>()));
           
            game.Play(dice);
            
            winner.Verify(x=>x.Win(10*6),Times.Once);  
        }
        
        [Test]
        public void WhenPlay_WithLoser_GameShouldCallLose_Mocks() // 2.2.2
        {
            RollDiceGameFake game = Create
                .Game()
                .score(5)
                .Please();
            DiceFake dice = Create
                .Dice()
                .Please();
            Mock<Player> loser = Create
                .MockPlayer()
                .In(game)
                .WithChips(50)
                .WithBet(3)
                .Please();
            
            loser.Setup(x => x.Buy(new Chip(50)));
               
            game.Play(dice);
            
            loser.Verify(x=>x.Lose(),Times.Once);
        }
        
        [Test]
        public void WhenPlay_WithWinner_GameShouldCallWin_Stubs() // 2.2.3
        {
            RollDiceGameFake game = Create
                .Game()
                .score(5)
                .Please();
            DiceFake dice = Create
                .Dice()
                .Please();
            Mock<Player> winner = Create
                .MockPlayer()
                .In(game)
                .WithChips(10)
                .WithBet(5)
                .Please();
            
            winner.Setup(x => x.Buy(It.IsAny<Chip>()));
               
            game.Play(dice);
            
            winner.Setup(x=>x.Has(new Chip(60))).Returns(true);
        }
        
        [Test]
        public void WhenPlay_WithLoser_GameShouldCallLose_Stubs() // 2.2.4
        {
            RollDiceGameFake game = Create
                .Game()
                .score(5)
                .Please();
            DiceFake dice = Create
                .Dice()
                .Please();
            Mock<Player> loser = Create
                .MockPlayer()
                .In(game)
                .WithChips(50)
                .WithBet(3)
                .Please();
            
            loser.Setup(x => x.Buy(It.IsAny<Chip>()));
               
            game.Play(dice);
            
            loser.Setup(x=>x.Has(new Chip(60))).Returns(false);
        }*/
        
        [Test]
        public void CanNotPutMoreChipsThanBought_Player_Bet() // 2.3 Я, как игрок, не могу поставить фишек больше, чем я купил
        {
            Player player = Create
                .Player()
                .WithChips(500)
                .Please();
            Bet betwithmorechip = Create
                .Bet()
                .WithChip(1000)
                .WithScore(1)
                .Please();
                   
            Assert.That(()=>player.Bet(betwithmorechip), Throws.Exception);
        }

        [Test]
        public void CanMoreThatOneBet_Player_Win() // 2.4 Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша
        {
            RollDiceGame game = Create
                .GameFake()
                .score(6)
                .Please();
            Player winner = Create
                .Player()
                .In(game)
                .WithChips(50 * 6)
                .WithSixBetsOnSixScore(50)
                .Please();
            Dice dice = Create
                .Dice()
                .Please();
            
            game.Play(dice);
                      
            Assert.AreEqual(50*6, winner.Chips);
        }
        
        [Test]
        public void CanOnlyBetOnNumbers1To6_Player_Bet() // 2.6 Я, как игрок, могу поставить только на числа 1 - 6
        {
            Player player = Create
                .Player()
                .WithChips(50)
                .Please();

           Assert.AreEqual(-1, player.Bet(new Bet(player.GetAvailableChips(),8)));
        }

        [Test]
        public void CanLoseIfMadeWrongBet_Loser_Lose() // 3.1 Я, как игрок, могу проиграть, если сделал неправильную ставку
        {
            RollDiceGameFake game = Create
                .GameFake()
                .score(3)
                .Please();
            Player loser = Create
                .Player()
                .In(game)
                .WithChips(50)
                .WithBet(1)
                .Please();
            Dice dice = Create
                .Dice()
                .Please();
            
            game.Play(dice);
            
            Assert.AreEqual(0, loser.Chips);
        }

        [Test]
        public void CanWinSixBetsIfMadeRightBet_Winner_Win() // 3.2 Я, как игрок, могу выиграть 6 ставок, если сделал правильную ставку
        {
            RollDiceGameFake game = Create
                .GameFake()
                .score(1)
                .Please();
            Player winner = Create
                .Player()
                .In(game)
                .WithChips(50*6)
                .WithSixBetsOnOneScore(50,1)
                .Please();
            Dice dice = Create
                .Dice()
                .Please();
            
            game.Play(dice);
            
            Assert.AreEqual(50*6*6,winner.GetAvailableChips().Amount);
        }

        [Test]
        public void CanMakeSeveralBetsOnDifferentNumbersGetWinForThoseThatHaveWon_Player_Win() //3.4 Я, как игрок, могу сделать несколько ставок на разные числа и получить выигрыш по тем, которые выиграли
        {
            RollDiceGameFake game = Create
                .GameFake()
                .score(1)
                .Please();
            Player winner = Create
                .Player()
                .In(game)
                .WithChips(50*6)
                .WithBetsOnDifferentScoreWhenTreeBetsOnOneNumber(50,1)
                .Please();
            Dice dice = Create
                .Dice()
                .Please();
            
            game.Play(dice);
            
            Assert.AreEqual(50*6*3, winner.GetAvailableChips().Amount);
        }
    }
}