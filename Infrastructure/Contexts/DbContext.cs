using System.Data;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Contexts
{
  public class DbContext : IDbContext
  {
    private readonly string _connectionString;

    public DbContext(IConfiguration configuration)
    {
      _connectionString = configuration.GetConnectionString("DigitalAccount") ?? string.Empty;
    }

    public IDbConnection CreateConnection() => new Npgsql.NpgsqlConnection(_connectionString);
  }
}
