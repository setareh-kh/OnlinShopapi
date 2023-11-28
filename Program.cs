using Microsoft.EntityFrameworkCore;
using OnlineShopapi.Models;
using OnlineShopapi.Repositories;
using OnlineShopapi.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
var connectionstr= builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<OnlinShopContext>(options => options.UseMySql(connectionstr,ServerVersion.AutoDetect(connectionstr)));
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductCatogoryRepository,ProductCatogoryRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
