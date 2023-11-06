using System.ComponentModel.DataAnnotations;

namespace OnlineShopapi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public required string FirstName { get; set; }
        [MaxLength(250)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public required string Mobile { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(8)]
        public required string Passworrd { get; set; }
        [MaxLength(250)]
        public  string? Emaile { get; set; }
        [MaxLength(250)]
        public  string? Address1 { get; set; }
        [MaxLength(250)]
        public  string? Address2 { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }

    }
}