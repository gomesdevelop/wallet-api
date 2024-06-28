
using Application.UseCases.AddCustomer;
using Domain.Contracts.Repositories.AddCustomer;
using Domain.Contracts.UseCases.AddCustomer;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Respositories.AddCustomer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApi.Configurations;
using WebApi.Models.AddCustomer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDbContext, DbContext>();
builder.Services.AddScoped<IAddCustomerRepository, AddCustomerRepository>();
builder.Services.AddScoped<IAddCustomerUseCase, AddCustomerUseCase>();
builder.Services.AddTransient<IValidator<AddCustomerInput>, AddCustomerInputValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(AddSwaggerGenConfiguration.config);

builder.Services.ConfigureOptions<JwtBearerConfigureOptions>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

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
