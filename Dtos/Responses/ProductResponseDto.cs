namespace OnlineShopapi.Dtos.Responses
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public required int CatogoryId { get; set; }
        public required string Name { get; set; }
        public required int QuantityStock { get; set; }
        public required DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}