using Microsoft.EntityFrameworkCore;

namespace OnlineShopapi.Models
{
    public class OnlinShopContext:DbContext
    {
       public OnlinShopContext(DbContextOptions <OnlinShopContext> options):base(options)
       {

       }
       public DbSet<Product> Products {get; set;}
       public DbSet<ProductCatogory> ProductCatogories {get; set;}
       public DbSet<Customer> Customers {get; set;}
    }
}