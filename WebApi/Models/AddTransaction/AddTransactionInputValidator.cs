using FluentValidation;
using WebApi.Models.AddTransaction;

namespace WebApi.Models.AddTransaction
{
  public class AddTransactionInputValidator : AbstractValidator<AddTransactionInput>
  {
    public AddTransactionInputValidator()
    {
      RuleFor(x => x.Description).NotEmpty();
      RuleFor(x => x.DueDate).NotEmpty();
      RuleFor(x => x.Amount).GreaterThan(0);
      RuleFor(x => x.TransactionType).IsInEnum();

    }
  }
}