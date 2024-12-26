using FluentValidation;

namespace OnlineScheduling.Application.Commands.v1.Customer.CreateOrUpdate;

public class CreateOrUpdateCustomerCommandValidator : AbstractValidator<CreateOrUpdateCustomerCommand>
{
    public CreateOrUpdateCustomerCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("Por favor, informe o nome.");
    }
}