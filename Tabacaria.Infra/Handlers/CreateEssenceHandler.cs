using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Domain.Handlers
{
    public class CreateEssenceHandler : IRequestHandler<CreateEssenceCommand, Response<EssenceEntity>>
    {
        //TODO: CRIAR CLASSE PARA IMPLEMENTAR "IRequestHandler", IMPLEMENTAR UMA FUNCTION QUE IREI RECEBER DE PARAMETRO E MOVER PARA CAMADA DOMAIN
        private readonly IEssenceRepository _essenceRepository;
        private readonly IMapper _mapper;

        public CreateEssenceHandler(
            IEssenceRepository essenceRepository,
            IMapper mapper)
        {
            _essenceRepository = essenceRepository;
            _mapper = mapper;
        }

        public async Task<Response<EssenceEntity>> Handle(CreateEssenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var responseInsert = _essenceRepository.Insert(_mapper.Map<EssenceEntity>(request));

                if (responseInsert.Id == 0)
                    return new Response<EssenceEntity>(false, "Failed to insert the new essence", null);

                return new Response<EssenceEntity>(true, "Success to insert the new essence", responseInsert);
            }
            catch (Exception)
            {
                throw new Exception("An internal error occured", null);
            }
        }
    }
}
