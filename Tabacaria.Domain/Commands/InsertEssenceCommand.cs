using System;
using System.Collections.Generic;
using System.Text;
using Tabacaria.Domain.DTOs;
using Tabacaria.Domain.Models;

namespace Tabacaria.Domain.Commands
{
    public class InsertEssenceCommand : Product
    {
        public string Flavor { get; set; }
        public int Quantity { get; set; }

        public InsertEssenceCommand(EssenceDTO essenceDTO) : base(essenceDTO.Type, essenceDTO.Name, essenceDTO.Description, essenceDTO.Brand, essenceDTO.Value)
        {
            Flavor = essenceDTO.Flavor;
            Quantity = essenceDTO.Quantity;
        }

        public override void Validate()
        {
            //TODO: Udar o FLUENT
            throw new NotImplementedException();
        }
    }
}
