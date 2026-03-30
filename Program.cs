using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Project_2.Data;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;
using Project_2.Repositories.ProductRepositories;
using Project_2.Repositories.CategoryRepositories;
using Project_2.Repositories.SupplierRepositories;
using Project_2.Repositories.UnitOfWork;
using Project_2.Helpers.Mapping;
using Project_2.Validators.ProductValidators;
using FluentValidation.AspNetCore;
using Project_2.DTOs.ProductDTOs;
using Project_2.Services;

namespace Project_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔥 DbContext
            builder.Services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // 🔥 Repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

            // 🔥 UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 🔥 AutoMapper
            builder.Services.AddAutoMapper(typeof(ProductProfile));

            // 🔥 FluentValidation
            builder.Services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
            builder.Services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductValidator>();

            // 🔥 Services
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<SupplierService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
