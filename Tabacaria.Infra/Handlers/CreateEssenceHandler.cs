using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Domain.Handlers
{
    public class CreateEssenceHandler : IRequestHandler<CreateEssenceCommand, Response<EssenceEntity>>
    {
        private readonly Interfaces.INotification _notification;
        private readonly IMapper _mapper;

        public CreateEssenceHandler(Interfaces.INotification notification,
                                    IMapper mapper)
        {
            _notification = notification;
            _mapper = mapper;
        }

        public async Task<Response<EssenceEntity>> Handle(CreateEssenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.Valid)
                {
                    _notification.AddNotifications(request.ValidationResult);
                    return new Response<EssenceEntity>(false, _notification.GetErrorMessages(), null);
                }

                return new Response<EssenceEntity>(true, "The essence was successfully created", _mapper.Map<EssenceEntity>(request));
            }
            catch (Exception)
            {
                throw new Exception("An internal error occured", null);
            }
        }
    }
}
