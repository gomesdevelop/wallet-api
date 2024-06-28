using System.Data;

namespace Infrastructure.Contexts
{
  public interface IDbContext
  {
    IDbConnection CreateConnection();
  }
}
