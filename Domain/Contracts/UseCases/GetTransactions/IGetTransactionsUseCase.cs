using Domain.Entities;

namespace Domain.Contracts
{
  public interface IGetTransactionsUseCase
  {
    Task<List<Transaction>> GetAll(TransactionFilter filter);
  }
}
