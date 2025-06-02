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

app.Run();

static void FillCustomerData()
{
    for(int i= 0; i< 10; i++)
    {
        Customer customer = new()
        {
            Id = i + 1,
            Name = $"Customer {i}",
            AddressList = new List<Address>{
                new Address { 
                    id = i,
                    StreetLine1 = "Rua da minha casa",
                    StreetLine2 = "Sua casa",
                    PostalCode = 89560, 
                    Country = "Brasil", 
                    City = "Videira",
                    State = "Sc",
                    AddressType = "Casa" 
                }
            },
        };
        CustomerData.Customers.Add(customer);
    }
}