using Domain.Contracts.Repositories;
using Domain.Contracts.UseCases.AddTransaction;
using Domain.Entities;

namespace Application.UseCases.AddTransaction
{
  public class AddTransactionUseCase : IAddTransactionUseCase
  {
    private readonly ITransactionRepository _repository;

    public AddTransactionUseCase(ITransactionRepository repository)
    {
      _repository = repository;
    }

    public Task<Transaction> AddTransaction(Transaction customer)
    {
      return _repository.Add(customer);
    }
  }
}
