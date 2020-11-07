using Tabacaria.Domain.Entities;

namespace Tabacaria.Domain.Commands
{
    //public class CreateEssenceCommand : ProductCommand<EssenceEntity>
    public class CreateEssenceCommand : ProductCommand
    {
        public string Flavor { get; set; }
        public int Quantity { get; set; }
    }
}
