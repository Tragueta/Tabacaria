using System.Collections.Generic;
using System.Threading.Tasks;
using Tabacaria.Domain.Entities;

namespace Tabacaria.Domain.Interfaces.Repositories
{
    public interface IEssenceRepository
    {
        Task<bool> Insert(EssenceEntity request);

        IEnumerable<EssenceEntity> GetAllEssences();
    }
}
