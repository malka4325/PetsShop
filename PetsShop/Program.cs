using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<PetsShopContext>(options => options.UseSqlServer
("Data Source=SRV2\\PUPILS;Initial Catalog=PetsShop;Integrated Security=True;TrustServerCertificate=True"));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();


