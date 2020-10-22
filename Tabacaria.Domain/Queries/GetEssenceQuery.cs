using MediatR;
using System.Collections.Generic;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Domain.Queries
{
    public class GetEssenceQuery : IRequest<Response<IEnumerable<EssenceEntity>>>
    {
    }
}
