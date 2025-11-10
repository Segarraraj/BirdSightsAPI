namespace Domain.Entities
{
    public class BirdSight
    {
        public int Id { get; set; }
        public int BirdId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        public BirdSight(int id, int birdId, int count, DateTime date) 
        {
            Id = id;
            BirdId = birdId;
            Count = count;
            Date = date;
        }
    }
}
