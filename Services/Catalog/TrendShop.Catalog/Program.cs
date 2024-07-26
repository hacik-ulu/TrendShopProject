using Microsoft.Extensions.Options;
using System.Reflection;
using TrendShop.Catalog.Operations.CategoryServices;
using TrendShop.Catalog.Operations.ProductDetailDetailServices;
using TrendShop.Catalog.Operations.ProductDetailServices;
using TrendShop.Catalog.Operations.ProductImageImageServices;
using TrendShop.Catalog.Operations.ProductImageServices;
using TrendShop.Catalog.Operations.ProductServices;
using TrendShop.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// sp --> service provider ile DatabaseSettings deðerlerine ulaþacak.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
