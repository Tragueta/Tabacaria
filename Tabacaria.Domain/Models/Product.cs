using FluentValidation;
using FluentValidation.Results;
using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Domain.Models
{
    public class Product
    {
        #region Produtct Properties
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
        #endregion

        #region Validation Properties
        public bool Valid { get; set; }
        public ValidationResult ValidationResult { get; set; } 
        #endregion


        public Product(ProductType type, string name, string description, string brand, decimal value)
        {
            Type = type;
            Name = name;
            Description = description;
            Brand = brand;
            Value = value;
        }

        public bool Validate<T>(T model, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
