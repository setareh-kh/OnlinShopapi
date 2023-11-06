
using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;

namespace OnlineShopapi.Repositories.Repositories
{
    public interface IProductCatogoryRepository
    {
        /// <summary>
        /// To add Catogory Product you can use this Function
        /// </summary>
        /// <param name="addCatogoryDto"></param>
        /// <returns>ProductCatogory</returns>
        Task<ProductCatogory?> AddCatogoryAsync(AddCatogoryDto addCatogoryDto);
        /// <summary>
        /// to get catogory by Id you can this function 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductCatogory</returns>
        Task<ProductCatogory?> GetCatogoryAsync(int id);
        /// <summary>
        /// To getall product catogory you can use this function
        /// </summary>
        /// <returns>ProductCatogory</returns>
        Task<List<ProductCatogory>?> GetAllCatogoryAsync();
    }
}

