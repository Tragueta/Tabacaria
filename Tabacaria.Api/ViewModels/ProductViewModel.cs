using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Api.ViewModels
{
    public class ProductViewModel
    {
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
    }
}
