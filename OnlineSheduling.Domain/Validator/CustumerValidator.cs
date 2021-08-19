using FluentValidation;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Validator
{
    public class CustumerValidator : AbstractValidator<Custumer>
    {
        public CustumerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .GreaterThan("0")
                .WithMessage("Nome inválido, verifique.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull();
        }
    }
}
