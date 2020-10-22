using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Domain.Entities
{
    public class EssenceEntity
    {
        public int Id { get; set; }
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
        public string Flavor { get; set; }
        public int Quantity { get; set; }

    }
}
