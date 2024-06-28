using Domain.Contracts.Repositories.AddCustomer;
using Domain.Contracts.UseCases.AddCustomer;
using Domain.Entities;

namespace Application.UseCases.AddCustomer
{
  public class AddCustomerUseCase : IAddCustomerUseCase
  {
    private readonly IAddCustomerRepository _repository;

    public AddCustomerUseCase(IAddCustomerRepository repository)
    {
      _repository = repository;
    }

    public void AddCustomer(Customer customer)
    {
      _repository.AddCustomer(customer);
    }
  }
}
