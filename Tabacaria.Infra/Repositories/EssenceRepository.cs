using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Clients;
using Tabacaria.Domain.Interfaces.Repositories;
using Tabacaria.Infra.Clients;

namespace Tabacaria.Infra.Repositories
{
    public class EssenceRepository : IEssenceRepository
    {
        private readonly IBaseRepository _baseRepository;

        public EssenceRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;

        public async Task<bool> Insert(EssenceEntity request) => await _baseRepository.InsertAsync(request);

        public IEnumerable<EssenceEntity> GetAllEssences() => _baseRepository.GetAllAsync<EssenceEntity>();
    }
}
