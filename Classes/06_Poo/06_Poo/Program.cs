using PooModel;
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
    for(int i= 0; i< 10; i++)
    {
        Customer customer = new()
        {
            Id = i + 1,
            Name = $"Customer {i+1}",
            AddressList = new List<Address>{
                new Address { 
                    Id = i,
                    StreetLine1 = "My house street",
                    StreetLine2 = "Your house",
                    PostalCode = 89560000, 
                    Country = "Brasil", 
                    City = "Videira",
                    State = "Sc",
                    AddressType = "Home" 
                }
            },
        };
        CustomerData.Customers.Add(customer);
    }
}

static void FillProductData()
{
    for (int i = 0; i < 10; i++)
    {
        Random rnd = new Random();

        Product product = new()
        {
            Id = i + 1,
            Name = $"Product {i}",
            Description = $"Product {i} description",
            CurrentPrice = rnd.Next(1, 100)
        };
        ProductData.Products.Add(product);
    }
}