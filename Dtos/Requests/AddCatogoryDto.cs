using System.ComponentModel.DataAnnotations;

namespace OnlineShopapi.Dtos.Requests
{
    public class AddCatogoryDto
    {
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }
        [MaxLength(250)]
        public  string? Description { get; set; }

    }
}