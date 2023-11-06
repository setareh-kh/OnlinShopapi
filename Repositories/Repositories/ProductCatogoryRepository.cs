using Microsoft.EntityFrameworkCore;
using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;
namespace OnlineShopapi.Repositories.Repositories
{
    public class ProductCatogoryRepository:IProductCatogoryRepository
    {
        private readonly OnlinShopContext _onlinShopContext;
        public ProductCatogoryRepository(OnlinShopContext  onlinShopContext)
        {
            _onlinShopContext =  onlinShopContext;
        }
        public async Task<ProductCatogory?> AddCatogoryAsync(AddCatogoryDto addCatogoryDto)
        {
            ProductCatogory productCatogory = new ProductCatogory()
            {
                Name = addCatogoryDto.Name,
                Description = addCatogoryDto.Description
            };
            await  _onlinShopContext.ProductCatogories.AddAsync(productCatogory);
            await  _onlinShopContext.SaveChangesAsync();
            return productCatogory;

        }
        public async Task<ProductCatogory?> GetCatogoryAsync(int id)
        {
            ProductCatogory? productCatogory = await  _onlinShopContext.ProductCatogories.SingleOrDefaultAsync(p => p.Id.Equals(id));
            return productCatogory == null ? null : productCatogory;

        }
        public async Task<List<ProductCatogory>?> GetAllCatogoryAsync()
        {
            List<ProductCatogory> productCatogoryList = await  _onlinShopContext.ProductCatogories.ToListAsync();
            return productCatogoryList.Count == 0 ? null : productCatogoryList;

        }


    }
}