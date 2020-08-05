using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Domain.Models
{
    public abstract class Product
    {
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }

        public Product(ProductType type, string name, string description, string brand, decimal value)
        {
            Type = type;
            Name = name;
            Description = description;
            Brand = brand;
            Value = value;
        }

        public abstract void Validate();
    }
}
