using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Domain.DTOs
{
    public class ProductDTO
    {
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
    }
}
