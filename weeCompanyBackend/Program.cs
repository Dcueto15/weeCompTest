using Microsoft.EntityFrameworkCore;
using weeCompanyBackend.Domain.IRepositories;
using weeCompanyBackend.Domain.IServices;
using weeCompanyBackend.Persistence.Context;
using weeCompanyBackend.Repositories;
using weeCompanyBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IContactServices, ContactServices>();

builder.Services.AddScoped<IContactRepositories, ContactRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowWebApp");

app.MapControllers();

app.Run();
