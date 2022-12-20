using FluentValidation.Results;

namespace solidCleanarchitecture.Application.Exceptions
{
    public class ValidationExeption : ApplicationException
    {
        public List<string> Errors { get; set; } = new();

        public ValidationExeption(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
}