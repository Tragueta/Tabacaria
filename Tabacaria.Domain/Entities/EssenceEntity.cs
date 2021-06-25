using System.ComponentModel.DataAnnotations.Schema;
using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Domain.Entities
{
    [Table("Essence")]
    public class EssenceEntity : BaseEntity
    {
        [Column("Type")]
        public ProductType Type { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Brand")]
        public string Brand { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        [Column("Flavor")]
        public string Flavor { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }
    }
}
