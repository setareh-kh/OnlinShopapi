using Microsoft.EntityFrameworkCore;
using  OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Models;

namespace OnlineShopapi.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlinShopContext _onlinShopContext;
        //public bool isLogin = false;
        public Customer? currentCustomer;
        public CustomerRepository(OnlinShopContext onlinShopContext)
        {
            _onlinShopContext = onlinShopContext;
        }
        public async Task<Customer> AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            var c = new Customer()
            {
                FirstName = addCustomerDto.FirstName,
                LastName = addCustomerDto.LastName,
                Mobile = addCustomerDto.Mobile,
                Passworrd = addCustomerDto.Passworrd,
                Emaile = addCustomerDto.Emaile,
                Address1 = addCustomerDto.Address1,
                Address2 = addCustomerDto.Address2,
                RegisterDate = DateTime.Now
            };
            await  _onlinShopContext.Customers.AddAsync(c);
            await  _onlinShopContext.SaveChangesAsync();
            return c;
        }
        public async Task<Customer?> GetCustomerAsync(int id)
        {
            Customer? c = await  _onlinShopContext.Customers.FindAsync(id);
            return c == null ? null : c;
        }
        public async Task<List<Customer>?> GetAllCustomerAsync()
        {
            List<Customer> lstCustomer = await  _onlinShopContext.Customers.ToListAsync();
            return lstCustomer.Count > 0 ? lstCustomer : null;
        }
        public async Task<Customer?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto)
        {
            Customer? customer = await  _onlinShopContext.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.FirstName = updateCustomerDto.FirstName;
                customer.LastName = updateCustomerDto.LastName;
                customer.Passworrd = updateCustomerDto.Passworrd;
                customer.Emaile = updateCustomerDto.Emaile;
                customer.Address1 = updateCustomerDto.Address1;
                customer.Address2 = updateCustomerDto.Address2;
                await  _onlinShopContext.SaveChangesAsync();
                return customer;
            }
            else
                return null;

        }
        public async Task<Customer?> DeleteCustomerAsync(int id)
        {
            Customer? customer = await  _onlinShopContext.Customers.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (customer != null)
            {
                 _onlinShopContext.Remove(customer);
                await  _onlinShopContext.SaveChangesAsync();
                return customer;
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