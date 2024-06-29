using Domain.Contracts;
using Domain.Contracts.Repositories;
using Domain.Entities;

namespace Application;

public class GetTransactionsUseCase : IGetTransactionsUseCase
{
  private readonly ITransactionRepository _repository;

  public GetTransactionsUseCase(ITransactionRepository repository)
  {
    _repository = repository;
  }

  public Task<List<Transaction>> GetAll(TransactionFilter filter)
  {
    return _repository.GetAll(filter);
  }
}

