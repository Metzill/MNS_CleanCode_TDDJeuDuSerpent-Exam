using System.Collections;
using System.Xml.Linq;

namespace TDDJeuDuSerpent___Exam
{
    internal class Game
    {
        private bool isOver;
        private Player winner;

        public Game()
        {
            this.isOver = false;
            this.PlayerList = new List<Player>();
        }

        public Player Winner { get; private set; }
        public bool IsOver { get; private set; }
        public List<Player> PlayerList { get; set; }

        internal void Start(string[] playerNames)
        {
            foreach (string playerName in playerNames)
            {
                PlayerList.Add(new Player(playerName));
                Console.WriteLine("Player {0} joined the game !", playerName);
            }
            Console.WriteLine("=====");
        }

        internal void Proceed()
        {
            foreach(Player player in this.PlayerList)
            {
                if (!isOver) PlayATurn(player);
            }
            Console.WriteLine("=====");
        }

        internal void PlayATurn(Player player)
        {
            Console.WriteLine("{0}'s turn ! (position : {1})", player.Name, player.Position);
            player.Move();
            Console.WriteLine("{0} rolled : {1}, moving from {2} ==> to {3}",player.Name, player.Dice.LastRoll, player.LastPosition, player.Position);
            if (player.Position == 50) Wins(player);
            Console.WriteLine("===");
        }

        internal void Wins(Player player)
        {
            this.winner = player;
            this.isOver = true;

            Console.WriteLine("=====");
            Console.WriteLine("Congratulations {0} ! {0} reached case 50 first !", player.Name);
        }
    }
}