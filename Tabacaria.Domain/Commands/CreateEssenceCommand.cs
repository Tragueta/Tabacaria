using MediatR;
using Tabacaria.Domain.DTOs;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Models;
using Tabacaria.Domain.Utils.HttpUtils;
using Tabacaria.Domain.Utils.Validators;

namespace Tabacaria.Domain.Commands
{
    public class CreateEssenceCommand : Product, IRequest<Response<EssenceEntity>>
    {
        public string Flavor { get; set; }
        public int Quantity { get; set; }

        public CreateEssenceCommand(EssenceDTO essenceDTO) : base(essenceDTO.Type, essenceDTO.Name, essenceDTO.Description, essenceDTO.Brand, essenceDTO.Value)
        {
            Flavor = essenceDTO.Flavor;
            Quantity = essenceDTO.Quantity;

            Validate(this, new EssenceValidator());
        }
    }
}
