using MediatR;
using Tabacaria.Domain.Enumerators;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Domain.Commands
{
    public class ProductCommand : IRequest<Response>
    {
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
    }
}
