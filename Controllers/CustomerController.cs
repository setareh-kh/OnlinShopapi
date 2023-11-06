using Microsoft.AspNetCore.Mvc;
using OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;
using OnlineShopapi.Repositories;


namespace OnlineShopapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Customercontroller : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public Customercontroller(ICustomerRepository customerRepository)
        {
            _customerRepository=customerRepository;
        }
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> LoginCustomerAsync(string mobile,string password)
        {
            bool status= await _customerRepository.LoginCustomer(mobile,password);
            return Ok(status==false ? "login faild":"login successfully");
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerDto addCustomerDto)
        {
            var customer=await _customerRepository.AddCustomerAsync(addCustomerDto);
            return Ok($"{customer.FirstName} {customer.LastName} with IdNumber {customer.Id} is registered");
        }
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            Customer? customer=await _customerRepository.GetCustomerAsync(id);
            return Ok(customer==null?$"CusomerId not exsist":customer);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {
            List<Customer>? customer=await _customerRepository.GetAllCustomerAsync();
            return Ok(customer==null?$"No Any Customer exsist":customer);
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id,[FromBody] UpdateCustomerDto updateCustomerDto)
        {
            Customer? customer=await _customerRepository.UpdateCustomerAsync(id,updateCustomerDto);
            return Ok(customer==null?$"Not found the CustomerId":customer);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            Customer? customer=await _customerRepository.DeleteCustomerAsync(id);
            return Ok(customer==null?$"Not found the CustomerId":customer);
        }
    }
}