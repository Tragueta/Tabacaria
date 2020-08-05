using System;
using System.Collections.Generic;
using System.Text;

namespace Tabacaria.Domain.DTOs
{
    public class EssenceDTO : ProductDTO
    {
        public string Flavor { get; set; }
        public int Quantity { get; set; }
    }
}
