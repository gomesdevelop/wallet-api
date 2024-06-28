using Domain.Entities;

namespace Domain.Contracts.UseCases.AddTransaction
{
  public interface IAddTransactionUseCase
  {
    void AddTransaction(Transaction customer);
  }
}
