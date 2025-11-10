namespace Domain.Entities
{
    public class Bird
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Bird(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
