using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;

namespace OnlineShopapi.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// To Add customer you can use this function
        /// </summary>
        /// <param name="addCustomerDto"></param>
        /// <returns>Customer</returns>
        Task<Customer> AddCustomerAsync(AddCustomerDto addCustomerDto);
        /// <summary>
        /// To Get Customer By Id You can this function 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer?</returns>
        Task<Customer?> GetCustomerAsync(int id);
        /// <summary>
        /// To read all Customer You can this function
        /// </summary>
        /// <returns>ListCustomer</returns>
        Task<List<Customer>?> GetAllCustomerAsync();
        /// <summary>
        /// To Update Customer Personality You can this function
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCustomerDto"></param>
        /// <returns>Customer?</returns>
        Task<Customer?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto);
        /// <summary>
        /// To Delete Customer by Id You can this function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer?</returns>
        Task<Customer?> DeleteCustomerAsync(int id);
        /// <summary>
        /// To Login Customer You can this function
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        Task<bool> LoginCustomer(string mobile, string password);

    }
}