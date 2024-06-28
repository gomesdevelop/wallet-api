using FluentValidation;

namespace WebApi.Models.AddCustomer
{
  public class AddCustomerInputValidator : AbstractValidator<AddCustomerInput>
  {
    public AddCustomerInputValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.Email).NotEmpty();
      RuleFor(x => x.Document).IsValidCPF().WithMessage("Invalid Document");
    }
  }
}
