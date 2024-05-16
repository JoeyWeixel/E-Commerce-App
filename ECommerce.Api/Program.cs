using ECommerceAPI.Endpoints.Customer;
using ECommerceAPI.Endpoints.Product;
using ECommerceAPI.Endpoints.PaymentInfo;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ECommerceContext>(opt =>
    opt.UseInMemoryDatabase("ECommerce"));
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<PaymentInfoService>();




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
