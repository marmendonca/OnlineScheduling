using FluentValidation;

namespace OnlineScheduling.Domain.Command.Commands.v1.Customer.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("Por favor, informe o nome.");
    }
}