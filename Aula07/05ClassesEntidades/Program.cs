using Microsoft.Extensions.ObjectPool;
using Modelo;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

FillCustomerData();
FillProductData();

app.Run();

static void FillCustomerData()
{
    for(int i = 0; i < 10; i++)
    {
        Customer customer = new()
        {
            Id = i + 1,
            Name = $"Customer {i + 1}",
            HomeAddress = new Address()
            {
                Id = i + 1,
                AddressType = "Casa",
                City = "Videira",
                Country = "Brasil",
                StateOrProvince = "Santa Catarina",
                PostalCode = 89650000,
                StreetLine1 = "Rua da minha casa",
                StreetLine2 = "Rua do meu apartamento",
            }
        };

        CustomerData.Customers.Add(customer);
    }
}

string[] nomesProdutos = ["Sabonete", "Revólver 38"];
static void FillProductData()
{
    for (int i = 0; i < 10; i++)
    {
        Product product = new()
        {
            Id = i + 1,
            ProductName = $"Produto {i + 1}",
            Description = "Sabonete",
            CurrentPrice = new Random().Next(1, 100)
        };

        CustomerData.Products.Add(product);
    }
}