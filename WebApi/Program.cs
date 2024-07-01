
using Application.UseCases.AddTransaction;
using Domain.Contracts;
using Domain.Contracts.Repositories;
using Domain.Contracts.UseCases.AddTransaction;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Respositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WebApi.Configurations;
using WebApi.Models.AddTransaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WalletContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DigitalAccount")));
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IAddTransactionUseCase, AddTransactionUseCase>();
builder.Services.AddScoped<IGetTransactionsUseCase, Application.GetTransactionsUseCase>();
builder.Services.AddTransient<IValidator<AddTransactionInput>, AddTransactionInputValidator>();

#region [CORS]
builder.Services.AddCors();
#endregion
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

#region [CORS]
app.UseCors(policy =>
{
    policy
      .AllowAnyOrigin().WithOrigins("*")
      .AllowAnyMethod().WithMethods("*")
      .AllowAnyHeader().WithHeaders("*");
});
#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
