using Microsoft.EntityFrameworkCore;
using ProvaPub.Extensions;
using ProvaPub.Repositories;
using ProvaPub.Services;
using ProvaPub.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterIoCs();

builder.Services.AddScoped<PixPaymentStrategy>();
builder.Services.AddScoped<CreditCardPaymentStrategy>();
builder.Services.AddScoped<PaypalPaymentStrategy>();

builder.Services.AddDbContext<TestDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ctx")));
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
