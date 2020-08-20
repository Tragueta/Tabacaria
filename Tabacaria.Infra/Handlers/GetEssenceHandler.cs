using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Domain.Queries;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Infra.Handlers
{
    public class GetEssenceHandler : IRequestHandler<GetEssenceQuery, Response<IEnumerable<EssenceEntity>>>
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
        public async Task<Response<IEnumerable<EssenceEntity>>> Handle(GetEssenceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //TODO: MOCK
                var responseGet = _essenceRepository.GetAllEssences();

                if (responseGet == null)
                    return new Response<IEnumerable<EssenceEntity>>(false, "Failed to insert the new essence", null);

                return new Response<IEnumerable<EssenceEntity>>(true, "Success to insert the new essence", responseGet);
            }
            catch (Exception)
            {
                throw new Exception("An internal error occured", null);
            }
        }
    }
}
