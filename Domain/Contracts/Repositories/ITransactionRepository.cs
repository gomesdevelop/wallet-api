using Domain.Entities;

namespace Domain.Contracts.Repositories
{
  public interface ITransactionRepository
  {
    Task<Transaction> Add(Transaction transaction);
    Transaction Get(TransactionFilter filter);
    Task<List<Transaction>> GetAll(TransactionFilter filter);
    void Update(TransactionFilter filter, Transaction transaction);
    void Delete(TransactionFilter filter);
  }
}
