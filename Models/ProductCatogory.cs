using System.ComponentModel.DataAnnotations;

namespace OnlineShopapi.Models
{
    public class ProductCatogory
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}