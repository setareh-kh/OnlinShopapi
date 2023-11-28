using AutoMapper;
using Microsoft.EntityFrameworkCore;
using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;
namespace OnlineShopapi.Repositories.Repositories
{
    public class ProductCatogoryRepository:IProductCatogoryRepository
    {
        private readonly OnlinShopContext _onlinShopContext;
        private IMapper _mapper;
        public ProductCatogoryRepository(OnlinShopContext  onlinShopContext,IMapper mapper)
        {
            _onlinShopContext =  onlinShopContext;
            _mapper=mapper;
        }
        public async Task<ProductCatogory?> AddCatogoryAsync(AddCatogoryDto addCatogoryDto)
        {
            ProductCatogory productCatogory = _mapper.Map<ProductCatogory>(addCatogoryDto);
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