
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
  public class WalletContext : Microsoft.EntityFrameworkCore.DbContext
  {

    public WalletContext(DbContextOptions<WalletContext> options) : base(options)
    {
    }

    public DbSet<TransactionModel> Transactions { get; set; }
  }
}
