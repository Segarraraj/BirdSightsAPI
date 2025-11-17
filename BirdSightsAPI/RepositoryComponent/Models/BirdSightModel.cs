using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryComponent.Models
{
    [Table("BirdSights")]
    public class BirdSightModel
    {
        [Key]
        public int Id { get; set; }
        public int BirdId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }

        public BirdModel Bird { get; set; }

        public BirdSightModel(int id, int birdId, int count, DateTime date,
            DateTime createdAt)
        {
            Id = id;
            BirdId = birdId;
            Count = count;
            Date = date;

            CreatedAt = createdAt;
        }
    }
}
