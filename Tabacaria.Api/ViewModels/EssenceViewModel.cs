using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Api.ViewModels
{
    public class EssenceViewModel : ProductViewModel
    {
        public string Flavor { get; set; }
        public int Quantity { get; set; }

        public EssenceViewModel()
        {
            Type = ProductType.Essence;
        }
    }
}
