namespace LI4.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Material(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"Material: {Name}, Description: {Description}, Price: {Price:C}";
        }
    }
}