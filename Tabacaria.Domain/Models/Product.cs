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
    }
}
