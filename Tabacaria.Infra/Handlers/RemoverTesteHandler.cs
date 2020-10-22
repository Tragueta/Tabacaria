using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Infra.Handlers
{
    public class RemoverTesteHandler : IRequestHandler<RemoverTesteComando, Response<EssenceEntity>>
    {
        public Task<Response<EssenceEntity>> Handle(RemoverTesteComando request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
