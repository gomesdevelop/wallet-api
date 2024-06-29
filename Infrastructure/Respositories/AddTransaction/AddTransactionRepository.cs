using Dapper;
using Domain.Contracts.Repositories.AddTransaction;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Respositories.AddTransaction
{
  public class AddTransactionRepository : IAddTransactionRepository
  {
    private readonly WalletContext _context;

    public AddTransactionRepository(WalletContext context)
    {
      _context = context;
    }

    public void Add(Transaction transaction)
    {
      var model = new TransactionModel(
        transaction.UserId,
        transaction.Description,
        transaction.DueDate,
        transaction.Amount,
        transaction.TransactionType
      );

      _context.Transactions.Add(model);
      _context.SaveChanges();
    }
  }
}