using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Foundation.Domain.Entites;
using Tabacaria.Foundation.Domain.Handler;

namespace Tabacaria.Domain.Handlers
{
    public class CreateEssenceHandler : RequestHandlerBase<CreateEssenceCommand>
    {
        private readonly IEssenceRepository _essenceRepository;
        private readonly IMapper _mapper;

        public CreateEssenceHandler(
            IEssenceRepository essenceRepository,
            IMapper mapper)
        {
            _essenceRepository = essenceRepository;
            _mapper = mapper;
        }

        public override async Task<Response> SafeExecuteHandler(CreateEssenceCommand request, CancellationToken cancellationToken)
        {

            var responseInsert = _essenceRepository.Insert(_mapper.Map<EssenceEntity>(request));

            if (responseInsert.Id == 0)
                throw new Exception("Failed to insert the new essence");

            return new Response(true, "Success to insert the new essence", responseInsert);

        }

        //public async Task<Response> Handle(CreateEssenceCommand request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var responseInsert = _essenceRepository.Insert(_mapper.Map<EssenceEntity>(request));

        //        if (responseInsert.Id == 0)
        //            return new Response(false, "Failed to insert the new essence", null);

        //        return new Response(true, "Success to insert the new essence", responseInsert);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("An internal error occured", null);
        //    }
        //}
    }
}
