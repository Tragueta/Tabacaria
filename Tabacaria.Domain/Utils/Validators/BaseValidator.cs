using FluentValidation;

namespace Tabacaria.Domain.Utils.Validators
{
    public class BaseValidator<T> : AbstractValidator<T> where T : class
    {
    }
}
