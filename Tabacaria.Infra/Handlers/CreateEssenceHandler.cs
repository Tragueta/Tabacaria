using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;

namespace Tabacaria.Domain.Handlers
{
    public class CreateEssenceHandler : IRequestHandler<CreateEssenceCommand, EssenceEntity>
    {
        public Task<EssenceEntity> Handle(CreateEssenceCommand request, CancellationToken cancellationToken)
        {
            //TODO: Continue the validation and implementation of Fluent Validator HERE!
            throw new NotImplementedException();
        }
    }
}
