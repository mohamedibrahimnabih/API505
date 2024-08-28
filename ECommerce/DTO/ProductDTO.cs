using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Img { get; set; }
        [Range(50, 500)]
        public double Price { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }


        public string CategoryName { get; set; }
    }
}
