using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tabacaria.Domain.Interfaces.Clients
{
    public interface IDapperClient
    {
        Task<bool> InsertAsync<T>(T entity);
        IEnumerable<T> GetAllAsync<T>() where T : class;
    }
}
