namespace GameMemoriLogic
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int TimeLeft { get; set; }
        public bool IsActive { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            TimeLeft = 30;
            IsActive = false;
        }
    }
}