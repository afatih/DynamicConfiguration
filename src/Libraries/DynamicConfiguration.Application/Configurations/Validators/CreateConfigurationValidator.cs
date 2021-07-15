using DynamicConfiguration.Application.Configurations.Commands;
using FluentValidation;

namespace DynamicConfiguration.Application.Configurations.Validators
{
    public class CreateConfigurationValidator : AbstractValidator<CreateConfigurationCommand>
    {
        public CreateConfigurationValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Type).NotEmpty();
            RuleFor(c => c.Value).NotEmpty();
            RuleFor(c => c.IsActive).NotNull();
            RuleFor(c => c.ApplicationName).NotEmpty();
        }
    }
}
