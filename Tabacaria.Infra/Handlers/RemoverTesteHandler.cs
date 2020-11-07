using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Infra.Handlers
{
    //public class RemoverTesteHandler : IRequestHandler<RemoverTesteComando, Response<EssenceEntity>>
    //{
    //    public Task<Response<EssenceEntity>> Handle(RemoverTesteComando request, CancellationToken cancellationToken)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
    //TODO: 8==========>
    // *****************************************//
    // Mudar para herdar de RequestHandlerBase //
    // ***************************************//

    public class RemoverTesteHandler : IRequestHandler<RemoverTesteComando, Response>
    {
        public Task<Response> Handle(RemoverTesteComando request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
