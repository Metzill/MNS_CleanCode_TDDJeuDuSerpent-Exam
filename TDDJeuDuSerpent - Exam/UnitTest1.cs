namespace TDDJeuDuSerpent___Exam
{
    [TestClass]
    public class TDDSnakeGame
    {
        [DataTestMethod]
        [DataRow("Hugo")]
        [DataRow("Oguh")]
        public void PlayerOnCreationIsOnPositionZero(string name)
        {
            var player = new Player(name);
            Assert.AreEqual(0, player.Position);
        }

        [DataTestMethod]
        [DataRow("Hugo")]
        [DataRow("Oguh")]
        public void PlayerOnCreationHasAName(string name)
        {
            var player = new Player(name);
            Assert.AreEqual(name, player.Name);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow()]
        public void PlayerNameCannotBeNullOrEmpty(string name)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => new Player(name));
            Assert.AreEqual(exception.Message, string.Format("Name cannot be empty or null"));
        }

        [DataTestMethod]
        [DataRow("Hugo")]
        public void DiceRangeIsBetweenOneAndSix(string name)
        {
            var player = new Player(name);
            int loopCount = 0;

            while (loopCount < 100)
            {
                player.Dice.RollDice();
                Assert.IsTrue((player.Dice.LastRoll > 0) && (player.Dice.LastRoll < 7));
                loopCount++;
            }
        }

        [DataTestMethod]
        [DataRow("Hugo", "Oguh")]
        public void EachPlayerCanRollADice(string name1, string name2)
        {
            var player1 = new Player(name1);
            var player2 = new Player(name2);
            Assert.AreNotEqual(player1.Dice.RollDice(), player2.Dice.RollDice());
        }

        [DataTestMethod]
        [DataRow("Hugo", "Oguh")]
        public void PlayersMovesDiceDistance(string name1, string name2)
        {
            var player1 = new Player(name1);
            var player2 = new Player(name2);

            int player1PositionBeforeRoll = player1.Position;
            int player2PositionBeforeRoll = player2.Position;

            //Move makes the player roll their dice
            player1.Move();
            player2.Move();

            Assert.AreEqual(player1PositionBeforeRoll, player1.Position - player1.Dice.LastRoll);
            Assert.AreEqual(player2PositionBeforeRoll, player2.Position - player2.Dice.LastRoll);
        }

        [DataTestMethod]
        [DataRow("Hugo")]
        public void IfAPlayerMovesOverCaseFiftyTheyAreSetBackToCaseTwentyFive(string name)
        {
            var player = new Player(name);
            bool overextend = false;

            while ((player.LastPosition + player.Dice.LastRoll) <= 50)
            {
                player.Move(); 
            }

            Console.WriteLine("player position before LastRoll : {0}", player.LastPosition);
            Console.WriteLine("player LastRoll : {0}", player.Dice.LastRoll);
            Assert.AreEqual(25, player.Position);
        }

        [DataTestMethod]
        [DataRow("Hugo", "Oguh")]
        public void PlayersAreCreatedWhenGameStart(string name1, string name2)
        {
            var game = new Game();
            Console.WriteLine("name : {0}", name1);
            game.Start(new[] { name1, name2 });

            Assert.AreEqual(game.PlayerList[0].Name, name1);
            Assert.AreEqual(game.PlayerList[1].Name, name2);
        }

        //[DataTestMethod]
        //[DataRow("Hugo", "Oguh")]
        //public void PlayerWinsWhenReachingCaseFifty(string name1, string name2)
        //{
        //    var game = new Game();
        //    Console.WriteLine("name : {0}", name1);
        //    game.Start(new[] {name1, name2 });

        //    while (!game.IsOver) game.Proceed();

        //    Assert.AreEqual(50, game.Winner.Position);
        //}
    }
}