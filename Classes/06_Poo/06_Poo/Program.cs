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
FillOrderData();

app.Run();

static void FillCustomerData()
{
    CustomerData.Customers.Clear();
    for (int i= 0; i< 10; i++)
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
    CustomerData.Products.Clear();
    Random rnd = new Random();

    for (int i = 0; i < 10; i++)
    {
        Product product = new()
        {
            Id = i + 1,
            Name = $"Product {i+1}",
            Description = $"Product {i+1} description",
            CurrentPrice = rnd.Next(1, 100)
        };
        CustomerData.Products.Add(product);
    }
}

static void FillOrderData()
{
    CustomerData.Orders.Clear();
    var rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        var customer = CustomerData.Customers[rnd.Next(CustomerData.Customers.Count)];
        var shippingAddress = customer.AddressList!.First();

        var order = new Order
        {
            Id = i + 1,
            Customer = customer,
            ShippingAddress = shippingAddress
        };

        int itemCount = rnd.Next(1, 4);
        for (int j = 0; j < itemCount; j++)
        {
            var product = CustomerData.Products[rnd.Next(CustomerData.Products.Count)];

            order.OrderItems.Add(new OrderItem
            {
                Product = product,
                Quantity = rnd.Next(1, 5),
                PurchasePrice = product.CurrentPrice
            });
        }

        CustomerData.Orders.Add(order);
    }
}
