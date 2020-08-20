﻿using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Domain.Models;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Domain.Handlers
{
    public class CreateEssenceHandler : IRequestHandler<CreateEssenceCommand, Response<EssenceEntity>>
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

        public async Task<Response<EssenceEntity>> Handle(CreateEssenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //TODO: MOCK
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
