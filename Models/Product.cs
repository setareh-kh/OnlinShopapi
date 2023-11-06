using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductCatogory ProductCatogory {  get; set; } = null!;
        [Required]
        [ForeignKey("ProductCatogory")]
        public required int CatogoryId { get; set; }
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }
        [Required]
        [DefaultValue("5")]
        public required int QuantityStock { get; set; }
        [Required]

        public required DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}