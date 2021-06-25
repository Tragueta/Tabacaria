using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tabacaria.Domain.Interfaces.Clients
{
    //TODO: Lembrar de mandar para Foundation.Domain após finalizar
    public interface IDapperClient
    {
        Task<bool> InsertAsync<T>(T entity);
        IEnumerable<T> GetAllAsync<T>() where T : class;
    }
}
