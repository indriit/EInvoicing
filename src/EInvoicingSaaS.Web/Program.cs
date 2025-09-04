using Microsoft.EntityFrameworkCore;
using EInvoicingSaaS.Infrastructure.Persistence;
using EInvoicingSaaS.Domain.Interfaces;
using EInvoicingSaaS.Infrastructure.Repositories;
using EInvoicingSaaS.Application.Interfaces;
using EInvoicingSaaS.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository and use case
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<ICreateInvoiceUseCase, CreateInvoiceUseCase>();


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
