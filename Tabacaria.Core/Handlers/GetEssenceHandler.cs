using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Core.Queries;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Foundation.Domain.Entites;
using Tabacaria.Foundation.Domain.Handler;

namespace Tabacaria.Core.Handlers
{
    public class GetEssenceHandler : RequestHandlerBase<GetEssenceQuery>
    {
        private readonly IEssenceRepository _essenceRepository;
        private readonly IMapper _mapper;

        public GetEssenceHandler
        (
            IEssenceRepository essenceRepository,
            IMapper mapper
        )
        {
            _essenceRepository = essenceRepository;
        }

        public override async Task<Response> SafeExecuteHandler(GetEssenceQuery request, CancellationToken cancellationToken)
        {
            return null;
            //var responseGet = _essenceRepository.GetAllEssences();

            //if (responseGet == null)
            //    throw new Exception("Failed to insert the new essence");

            //return new Response(true, "Success to insert the new essence", responseGet);
        }
    }
}
