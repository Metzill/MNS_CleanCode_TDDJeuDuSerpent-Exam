namespace TDDJeuDuSerpent___Exam
{
    internal class Player
    {
        private int position;
        private int lastPosition;
        private string name;
        private Dice dice;

        public Player(string name)
        {
            isEmptyOrNull(name);
            Position = 0;
            Name = name;
            Dice = new Dice();
        }

        public void Move()
        {
            Dice.RollDice();
            LastPosition = Position;
            Position += Dice.LastRoll;
            //If player goes over last case, set back to 25
            if (Position >= 51) Position = 25;
        }

        private void isEmptyOrNull(string name)
        {
            if (name == null || name == "") throw new ArgumentException(string.Format("Name cannot be empty or null"));
        }

        public int Position { get; set; }
        public int LastPosition { get; set; }
        public string Name { get; private set; }
        public Dice Dice { get; private set; }
    }
}
