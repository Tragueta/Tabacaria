using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Models;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Domain.Handlers
{
    public class CreateEssenceHandler : IRequestHandler<CreateEssenceCommand, Response<EssenceEntity>>
    {
        private readonly IMapper _mapper;

        public CreateEssenceHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response<EssenceEntity>> Handle(CreateEssenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Chamada repositorio
                //  var obj =_mapper.Map<EssenceEntity>(request);
                // var responseInsert = _repositorio.Insert(obj);
                // return responseInsert;

                return new Response<EssenceEntity>(true, "xx xx xx xx xx", _mapper.Map<EssenceEntity>(request));
            }
            catch (Exception)
            {
                throw new Exception("An internal error occured", null);
            }
        }
    }
}
