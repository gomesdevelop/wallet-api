using Domain.Entities;

namespace Domain.Contracts.UseCases.AddTransaction
{
  public interface IAddTransactionUseCase
  {
    Task<Transaction> AddTransaction(Transaction customer);
  }
}
