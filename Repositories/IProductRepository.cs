using OnlineShopapi.Models;
using OnlineShopapi.Repositories.Repositories;
using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Dtos.Responses;

namespace OnlineShopapi.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// to add product you can this function
        /// </summary>
        /// <param name="addProductDto"></param>
        /// <returns>product</returns>
        Task<ProductResponseDto?> AddProductAsync(AddProductDto addProductDto);
        /// <summary>
        /// to get product by id you can this function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>product</returns>
        Task<ProductResponseDto?> GetProductAsync(int id);
        /// <summary>
        /// to read all product you can this function
        /// </summary>
        /// <returns>list of Product</returns>
        Task<List<ProductResponseDto>?> GetAllProductAsync();
        /// <summary>
        /// Filter product by CatogoryId you can this function
        /// </summary>
        /// <param name="CId"></param>
        /// <returns>List<Product></returns>
        Task<List<Product>?> FilterProductByCIdAsync(int CId);
        /// <summary>
        ///  to update product by id you can this function
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateProductDto"></param>
        /// <returns>product</returns>
        Task<ProductResponseDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        /// <summary>
        /// to remove product by id you can this function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>product</returns>
        Task<ProductResponseDto?> RemoveProductAsync(int id);
    }
}