using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDJeuDuSerpent___Exam
{
    internal class Dice
    {
        private readonly Random random = new Random();
        private int lastRoll = 0;

        public int RollDice()
        {
            LastRoll = random.Next(1,7);
            return LastRoll;
        }

        public int LastRoll { get; set; }
    }
}
