using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using ShopApp.shared.Services;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.Configure<ShopAppSettings>(builder.Configuration.GetSection(nameof(ShopAppSettings)));
builder.Services.AddSingleton<IShopAppSettings>(sp => sp.GetRequiredService<IOptions<ShopAppSettings>>().Value);
builder.Services.AddScoped<IProductsServices, ProductsServices>();
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<IItemsServices, ItemsServices>();


// Add services to the container.

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

app.UseCors(Policy => Policy.WithOrigins("http://localhost:5131", "https://localhost:5131")
.AllowAnyMethod().WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
