using ECommerceAPI.Endpoints.Product;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ECommerceContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProductService>();
<<<<<<< HEAD
builder.Services.AddSingleton<CustomerService>();

builder.Services.AddSingleton<PaymentInfoService>();

=======
>>>>>>> b71a1defd2f5ce490fc4a063c4eec2b98cf2a951

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
