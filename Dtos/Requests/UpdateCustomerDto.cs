using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace  OnlineShopapi.Dtos.Requests
{
    public class UpdateCustomerDto
    {
        [Required]
        [MaxLength(250)]
        public required string FirstName { get; set; }
        [MaxLength(250)]
        [DefaultValue("")]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(8)]
        public required string Passworrd { get; set; }
        [MaxLength(250)]
        [DefaultValue("")]
        public string? Emaile { get; set; }
        [MaxLength(250)]
        [DefaultValue("")]
        public string? Address1 { get; set; }
        [MaxLength(250)]
        [DefaultValue("")]
        public string? Address2 { get; set; }
    }
}