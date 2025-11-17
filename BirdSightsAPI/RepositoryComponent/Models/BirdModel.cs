using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryComponent.Models
{
    [Table("Birds")]
    public class BirdModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<BirdSightModel> Sights { get; set; }

        public BirdModel(int id, string name, DateTime createdAt)
        {
            Id = id;
            Name = name;

            CreatedAt = createdAt;
        }
    }
}
