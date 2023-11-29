using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Dtos.Responses;
using OnlineShopapi.Models;

namespace OnlineShopapi.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlinShopContext _onlinShopContext;
        private IMapper _mapper;
        public ProductRepository(OnlinShopContext onlinShopContext,IMapper mapper)
        {
            _onlinShopContext = onlinShopContext;
            _mapper=mapper;
        }
        public async Task<ProductResponseDto?> AddProductAsync(AddProductDto addProductDto)
        {
            var product = _mapper.Map<Product>(addProductDto);
            product.RegisterDate=DateTime.Now;
            await _onlinShopContext.Products.AddAsync(product);
            await _onlinShopContext.SaveChangesAsync();
            return _mapper.Map<ProductResponseDto>(product);

        }
        public async Task<ProductResponseDto?> GetProductAsync(int id)
        {
            Product? product = await _onlinShopContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(id));
            return product == null ? null : _mapper.Map<ProductResponseDto>(product);

        }
        public async Task<List<ProductResponseDto>?> GetAllProductAsync()
        {
            List<Product> productList = await _onlinShopContext.Products.ToListAsync();
            return productList.Count == 0 ? null : productList.Select(p=>_mapper.Map<ProductResponseDto>(p)).ToList();

        }
        public async Task<List<Product>?> FilterProductByCIdAsync(int CId)
        {
            List<Product> productList = await _onlinShopContext.Products.Where(p => p.CatogoryId.Equals(CId)).ToListAsync();
            return productList.Count == 0 ? null : productList;

        }
        public async Task<ProductResponseDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            Product? product = await _onlinShopContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (product != null)
            {
                _mapper.Map(updateProductDto,product);
                product.UpdateDate = DateTime.Now;
                await _onlinShopContext.SaveChangesAsync();
                return _mapper.Map<ProductResponseDto>(product);
            }
            else
                return null;
        }
        public async Task<ProductResponseDto?> RemoveProductAsync(int id)
        {
            Product? product = await _onlinShopContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (product != null)
            {
                _onlinShopContext.Remove(product);
                await _onlinShopContext.SaveChangesAsync();
                return _mapper.Map<ProductResponseDto>(product);

            }
            else
                return null;


        }

    }
}