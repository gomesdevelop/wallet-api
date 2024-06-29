
using Application.UseCases.AddTransaction;
using Domain.Contracts.Repositories.AddTransaction;
using Domain.Contracts.UseCases.AddTransaction;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Respositories.AddTransaction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WebApi.Configurations;
using WebApi.Models.AddTransaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WalletContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DigitalAccount")));
builder.Services.AddScoped<IAddTransactionRepository, AddTransactionRepository>();
builder.Services.AddScoped<IAddTransactionUseCase, AddTransactionUseCase>();
builder.Services.AddTransient<IValidator<AddTransactionInput>, AddTransactionInputValidator>();

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
