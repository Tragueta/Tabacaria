using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tabacaria.Domain.Interfaces.Clients;

namespace Tabacaria.Infra.Clients
{
    public class DapperClient : IDapperClient
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection sqlConnection;

        public DapperClient(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnection = new SqlConnection(_configuration.GetConnectionString("Tabacaria"));
        }

        public async Task<bool> InsertAsync<T>(T entity)
        {
            var properties = GetPropertiesName(entity);

            var sql = @$"INSERT INTO [dbo].[{ GetTableName(typeof(T)) }] ( { string.Join(", ", properties) } )
                            VALUES ( @{ string.Join(", @", properties) } )";

            var affectedRows = await sqlConnection.ExecuteAsync(sql, entity, commandType: CommandType.Text);

            return affectedRows > 1;
        }

        public IEnumerable<T> GetAllAsync<T>() where T : class => sqlConnection.Query<T>($"SELECT * FROM [dbo].[{ GetTableName(typeof(T)) }]");

        private dynamic GetTableName(Type type)
        {
            dynamic classTableAttribute = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

            return classTableAttribute.Name ?? type.Name;
        }

        private IList<string> GetPropertiesName<T>(T entity)
        {
            IList<string> entityColumns = new List<string>();

            var properties = entity.GetType().GetProperties().AsList();

            properties.ForEach(x => { entityColumns.Add(x.GetCustomAttribute<ColumnAttribute>()?.Name ?? x.Name); });

            return entityColumns;
        }
    }
}