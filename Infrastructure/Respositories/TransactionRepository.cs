using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Respositories
{
  public class TransactionRepository : ITransactionRepository
  {
    private readonly WalletContext _context;

    public TransactionRepository(WalletContext context)
    {
      _context = context;
    }

    public async Task<Transaction> Add(Transaction transaction)
    {
      var model = new TransactionModel(
        transaction.UserId,
        transaction.Description,
        transaction.DueDate,
        transaction.Amount,
        transaction.TransactionType
      );

      await _context.Transactions.AddAsync(model);
      await _context.SaveChangesAsync();

      transaction.Id = model.Id;
      return transaction;
    }

    public void Delete(TransactionFilter filter)
    {
      throw new NotImplementedException();
    }

    public Transaction Get(TransactionFilter filter)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Transaction>> GetAll(TransactionFilter filter)
    {
      return await _context.Transactions
        .Where(x => x.UserId == filter.UserId)
        .Select(x => new Transaction
        {
          Id = x.Id,
          UserId = x.UserId,
          Description = x.Description,
          DueDate = x.DueDate,
          Amount = x.Amount,
          TransactionType = x.TransactionType
        })
        .ToListAsync();
    }

    public void Update(TransactionFilter filter, Transaction transaction)
    {
      throw new NotImplementedException();
    }
  }
}