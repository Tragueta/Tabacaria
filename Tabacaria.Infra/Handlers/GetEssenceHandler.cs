using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Domain.Queries;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Infra.Handlers
{
    //TODO:
    // *****************************************//
    // Mudar para herdar de RequestHandlerBase //
    // ***************************************//

    public class GetEssenceHandler : IRequestHandler<GetEssenceQuery, Response>
    {
        private readonly IEssenceRepository _essenceRepository;
        private readonly IMapper _mapper;

        public GetEssenceHandler(
            IEssenceRepository essenceRepository,
            IMapper mapper)
        {
            _essenceRepository = essenceRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetEssenceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var responseGet = _essenceRepository.GetAllEssences();

                if (responseGet == null)
                    return new Response(false, "Failed to insert the new essence", null);

                return new Response(true, "Success to insert the new essence", responseGet);
            }
            catch (Exception)
            {
                throw new Exception("An internal error occured", null);
            }
        }
    }
}
