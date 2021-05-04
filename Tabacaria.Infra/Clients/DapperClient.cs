using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            // TODO: Pensar em como o DapperClient podeia receber a connectionString de modo que ele fique genérico
            //       e o mesmo client possa ser usado para N SQL Connections
            _configuration = configuration;
            sqlConnection = new SqlConnection(_configuration.GetValue<string>("SqlServer:connectionString"));
        }

        public async Task<bool> InsertAsync<T>(T entity)
        {
            var properties = entity.GetType().GetProperties().AsList().Select(x => x.Name);

            var sql = @$"INSERT INTO [dbo].[{ GetTableName(typeof(T)) }] ( { string.Join(", ", properties) } )
                            VALUES ( @{ string.Join(", @", properties) } )";

            var affectedRows = await sqlConnection.ExecuteAsync(sql, entity, commandType: CommandType.Text);

            return affectedRows > 1;
        }

        public IEnumerable<T> GetAllAsync<T>() where T : class => sqlConnection.Query<T>($"SELECT * FROM [dbo].[{ GetTableName(typeof(T)) }]");

        private dynamic GetTableName(Type type)
        {
            dynamic classTableAttribute = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

            return classTableAttribute.Name;
        }
    }
}