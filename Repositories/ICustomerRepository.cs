using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Dtos.Responses;
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
        Task<CustomerResponseDto> AddCustomerAsync(AddCustomerDto addCustomerDto);
        /// <summary>
        /// To Get Customer By Id You can this function 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer?</returns>
        Task<CustomerResponseDto?> GetCustomerAsync(int id);
        /// <summary>
        /// To read all Customer You can this function
        /// </summary>
        /// <returns>ListCustomer</returns>
        Task<List<CustomerResponseDto>?> GetAllCustomerAsync();
        /// <summary>
        /// To Update Customer Personality You can this function
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCustomerDto"></param>
        /// <returns>Customer?</returns>
        Task<CustomerResponseDto?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto);
        /// <summary>
        /// To Delete Customer by Id You can this function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer?</returns>
        Task<CustomerResponseDto?> DeleteCustomerAsync(int id);
        /// <summary>
        /// To Login Customer You can this function
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        Task<bool> LoginCustomer(string mobile, string password);

    }
}