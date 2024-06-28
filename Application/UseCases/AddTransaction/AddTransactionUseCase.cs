using Domain.Contracts.Repositories.AddTransaction;
using Domain.Contracts.UseCases.AddTransaction;
using Domain.Entities;

namespace Application.UseCases.AddTransaction
{
  public class AddTransactionUseCase : IAddTransactionUseCase
  {
    private readonly IAddTransactionRepository _repository;

    public AddTransactionUseCase(IAddTransactionRepository repository)
    {
      _repository = repository;
    }

    public void AddTransaction(Transaction customer)
    {
      _repository.Add(customer);
    }
  }
}
