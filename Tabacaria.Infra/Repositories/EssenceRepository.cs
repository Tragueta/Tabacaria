using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Clients;
using Tabacaria.Domain.Interfaces.Repositories;

namespace Tabacaria.Infra.Repositories
{
    public class EssenceRepository : IEssenceRepository
    {
        private readonly IDapperClient _dapperClient;

        public EssenceRepository(IDapperClient dapperClient) => _dapperClient = dapperClient;

        public async Task<bool> Insert(EssenceEntity request) =>  await _dapperClient.InsertAsync(request);

        public IEnumerable<EssenceEntity> GetAllEssences() => _dapperClient.GetAllAsync<EssenceEntity>();
    }
}
