using AutoMapper;
using Microsoft.EntityFrameworkCore;
using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Dtos.Responses;
using OnlineShopapi.Models;

namespace OnlineShopapi.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlinShopContext _onlinShopContext;
        private IMapper _mapper;
        //public bool isLogin = false;
        public Customer? currentCustomer;
        public CustomerRepository(OnlinShopContext onlinShopContext, IMapper mapper)
        {
            _onlinShopContext = onlinShopContext;
            _mapper=mapper;
        }
        public async Task<CustomerResponseDto> AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            var c = _mapper.Map<Customer>(addCustomerDto);
            c.RegisterDate = DateTime.Now;
            await  _onlinShopContext.Customers.AddAsync(c);
            await  _onlinShopContext.SaveChangesAsync();
            return _mapper.Map<CustomerResponseDto>(c);
        }
        public async Task<CustomerResponseDto?> GetCustomerAsync(int id)
        {
            Customer? c = await  _onlinShopContext.Customers.FindAsync(id);
            return c == null ? null : _mapper.Map<CustomerResponseDto>(c);
        }
        public async Task<List<CustomerResponseDto>?> GetAllCustomerAsync()
        {
            List<Customer> lstCustomer = await  _onlinShopContext.Customers.ToListAsync();
            var response=lstCustomer.Select(c=>_mapper.Map<CustomerResponseDto>(c)).ToList();
            return lstCustomer.Count > 0 ? response : null;
        }
        public async Task<CustomerResponseDto?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto)
        {
            Customer? customer = await  _onlinShopContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _mapper.Map(updateCustomerDto,customer);
                await  _onlinShopContext.SaveChangesAsync();
                return _mapper.Map<CustomerResponseDto>(customer);
            }
            else
                return null;

        }
        public async Task<CustomerResponseDto?> DeleteCustomerAsync(int id)
        {
            Customer? customer = await  _onlinShopContext.Customers.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (customer != null)
            {
                 _onlinShopContext.Remove(customer);
                await  _onlinShopContext.SaveChangesAsync();
                return _mapper.Map<CustomerResponseDto>(customer);
            }
            else
                return null;

        }
        public async Task<bool> LoginCustomer(string mobile, string password)
        {
            Customer? customer = await  _onlinShopContext.Customers.SingleOrDefaultAsync(c => c.Mobile == mobile && c.Passworrd == password);
            if (customer != null)
            {
                //isLogin = true;
                currentCustomer=customer;
                return true;
            }
            else
                return false;
        }
        



    }
}