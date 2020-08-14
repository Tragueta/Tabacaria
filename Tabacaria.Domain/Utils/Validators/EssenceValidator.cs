using FluentValidation;
using Tabacaria.Domain.Commands;

namespace Tabacaria.Domain.Utils.Validators
{
    public class EssenceValidator : AbstractValidator<CreateEssenceCommand>
    {
        public EssenceValidator()
        {
            RuleFor(x => x.Type).NotNull();

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Brand).NotEmpty();

            RuleFor(x => x.Value).GreaterThan(0);

            RuleFor(x => x.Flavor).NotEmpty();

            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
