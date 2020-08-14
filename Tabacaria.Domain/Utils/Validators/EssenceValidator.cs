using FluentValidation;
using Tabacaria.Domain.Commands;

namespace Tabacaria.Domain.Utils.Validators
{
    public class EssenceValidator : AbstractValidator<CreateEssenceCommand>
    {
        public EssenceValidator()
        {
            RuleFor(x => x.Type).NotNull()
                                .WithMessage("The product type can't be null or empty");

            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("The name can't be null or empty");

            RuleFor(x => x.Description).NotEmpty()
                                       .WithMessage("The description can't be null or empty");

            RuleFor(x => x.Brand).NotEmpty()
                                 .WithMessage("The brand can't be null or empty");

            RuleFor(x => x.Value).GreaterThan(0)
                                 .WithMessage("The value needs to be greater than 0");

            RuleFor(x => x.Flavor).NotEmpty()
                                  .WithMessage("The flavor can't be null or empty"); ;

            RuleFor(x => x.Quantity).GreaterThan(0)
                                    .WithMessage("The quantity needs to be greater than 0");
        }
    }
}
