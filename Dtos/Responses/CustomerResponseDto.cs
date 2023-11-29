namespace OnlineShopapi.Dtos.Responses
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public  string? FullName { get; set; }
        public  string? Mobile { get; set; }
        public  string? Emaile { get; set; }
        public  string? Address1 { get; set; }
        public  string? Address2 { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
