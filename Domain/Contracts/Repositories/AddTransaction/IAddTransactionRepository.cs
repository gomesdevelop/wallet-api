using Domain.Entities;

namespace Domain.Contracts.Repositories.AddTransaction
{
  public interface IAddTransactionRepository
  {
    void Add(Transaction transaction);
  }
}
