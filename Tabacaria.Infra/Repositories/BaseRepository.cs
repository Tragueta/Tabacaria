using System.Collections.Generic;
using System.Threading.Tasks;
using Tabacaria.Domain.Interfaces.Clients;
using Tabacaria.Domain.Interfaces.Repositories;

namespace Tabacaria.Infra.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IDapperClient _dapperClient;

        public BaseRepository(IDapperClient dapperClient) => _dapperClient = dapperClient;

        public Task<bool> InsertAsync<T>(T entity) => _dapperClient.InsertAsync(entity);

        public IEnumerable<T> GetAllAsync<T>() where T : class => _dapperClient.GetAllAsync<T>();
    }
}
