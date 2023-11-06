using Microsoft.EntityFrameworkCore;
using OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;

namespace OnlineShopapi.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlinShopContext _onlinShopContext;
        public ProductRepository(OnlinShopContext onlinShopContext)
        {
            _onlinShopContext = onlinShopContext;
        }
        public async Task<Product?> AddProductAsync(AddProductDto addProductDto)
        {
            var product = new Product()
            {
                Name = addProductDto.Name,
                CatogoryId = addProductDto.CatogoryId,
                QuantityStock = addProductDto.Quantity,
                RegisterDate = DateTime.Now
            };
            await _onlinShopContext.Products.AddAsync(product);
            await _onlinShopContext.SaveChangesAsync();
            return product;

        }
        public async Task<Product?> GetProductAsync(int id)
        {
            Product? product = await _onlinShopContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(id));
            return product == null ? null : product;

        }
        public async Task<List<Product>?> GetAllProductAsync()
        {
            List<Product> productList = await _onlinShopContext.Products.ToListAsync();
            return productList.Count == 0 ? null : productList;

        }
        public async Task<List<Product>?> FilterProductByCIdAsync(int CId)
        {
            List<Product> productList = await _onlinShopContext.Products.Where(p => p.CatogoryId.Equals(CId)).ToListAsync();
            return productList.Count == 0 ? null : productList;

        }
        public async Task<Product?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            Product? product = await _onlinShopContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (product != null)
            {
                product.Name = updateProductDto.Name;
                product.QuantityStock = updateProductDto.Quantity;
                product.UpdateDate = DateTime.Now;
                await _onlinShopContext.SaveChangesAsync();
                return product;
            }
            else
                return null;
        }
        public async Task<Product?> RemoveProductAsync(int id)
        {
            Product? product = await _onlinShopContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (product != null)
            {
                _onlinShopContext.Remove(product);
                await _onlinShopContext.SaveChangesAsync();
                return product;

            }
            else
                return null;


        }

    }
}