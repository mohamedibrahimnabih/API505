namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Img { get; set; }
        public double Price { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
