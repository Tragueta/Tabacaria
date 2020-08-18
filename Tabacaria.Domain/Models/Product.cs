using MediatR;
using Tabacaria.Domain.Enumerators;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Domain.Models
{
    public class Product
    {
        #region Product Properties
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
        #endregion

    }
}
