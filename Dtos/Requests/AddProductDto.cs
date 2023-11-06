using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace  OnlineShopapi.Dtos.Requests
{
    public class AddProductDto
    {
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }
        [Required]
        public required int CatogoryId { get; set; }
        [Required]
        [DefaultValue("5")]
        public required int Quantity { get; set; }

    }
}