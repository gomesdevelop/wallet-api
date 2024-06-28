using Domain.Contracts.UseCases.AddCustomer;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;
using WebApi.Models.Errors;

namespace WebApi.Controllers
{
  [Route("customers")]
  [ApiController]
  [Authorize]
  public class AddCustomerController : ControllerBase
  {
    private readonly IAddCustomerUseCase _addCustomerUseCase;
    private readonly IValidator<AddCustomerInput> _validator;

    public AddCustomerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> validator)
    {
      _addCustomerUseCase = addCustomerUseCase;
      _validator = validator;
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] AddCustomerInput input)
    {
      var validationResult = _validator.Validate(input);
      if (!validationResult.IsValid)
      {
        return BadRequest(validationResult.Errors.ToCustomValidationFailure());
      }

      var customer = new Customer(input.Name, input.Email, input.Document);
      _addCustomerUseCase.AddCustomer(customer);

      return Created("", customer);
    }
  }
}
