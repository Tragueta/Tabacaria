namespace Tabacaria.Core.Commands
{
    public class CreateEssenceCommand : ProductCommand
    {
        public string Flavor { get; set; }
        public int Quantity { get; set; }
    }
}
