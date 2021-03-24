using AutoFixture;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Repositories;

namespace Tabacaria.Infra.Repositories
{
    public class EssenceRepository : IEssenceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection sqlConnection;

        public EssenceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnection = new SqlConnection(_configuration.GetValue<string>("SqlServer:connectionString"));
        }

        public async Task<bool> Insert(EssenceEntity request)
        {
            var insertEssenceQuery = @"
                INSERT INTO [dbo].[Essence]
                    (
                        Type,
                        Name,
                        Description,
                        Brand,
                        Value,
                        Flavor,
                        Quantity
                    )
                VALUES
                    (
                        @Type,
                        @Name,
                        @Description,
                        @Brand,
                        @Value,
                        @Flavor,
                        @Quantity 
                    )";

            var affectedRows = await sqlConnection.ExecuteAsync(insertEssenceQuery, request, commandType: CommandType.Text);

            return affectedRows > 1;
        }

        public IEnumerable<EssenceEntity> GetAllEssences() => sqlConnection.Query<EssenceEntity>("SELECT * FROM [dbo].[Essence]");
    }
}
