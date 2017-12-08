using FluentValidation;

namespace Example.API.ViewModels.Validations
{
    public class ExampleViewModelValidator : AbstractValidator<ExampleViewModel>
    {
        public ExampleViewModelValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
