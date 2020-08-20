using System.Collections.Generic;
using Tabacaria.Domain.Entities;

namespace Tabacaria.Domain.Interfaces.Repositories
{
    public interface IEssenceRepository
    {
        EssenceEntity Insert(EssenceEntity request);

        IEnumerable<EssenceEntity> GetAllEssences();
    }
}
