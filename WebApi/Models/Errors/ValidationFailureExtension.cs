using FluentValidation.Results;

namespace WebApi.Models.Errors
{
  public static class ValidationFailureExtension
  {

    public static List<CustomValidationFailure> ToCustomValidationFailure(this IEnumerable<ValidationFailure> validationFailures)
    {
      return validationFailures
        .Select(x => new CustomValidationFailure(x.PropertyName, x.ErrorMessage))
        .ToList();
    }
  }
}
