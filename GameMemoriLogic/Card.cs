namespace GameMemoriLogic
{
    public class Card
    {
        public int Id { get; set; }
        public int PairId { get; set; }
        public bool IsFlipped { get; set; }
        public bool IsMatched { get; set; }
        public string ImagePath { get; set; }

        public Card(int id, int pairId)
        {
            Id = id;
            PairId = pairId;
            IsFlipped = false;
            IsMatched = false;
        } 
    }
}