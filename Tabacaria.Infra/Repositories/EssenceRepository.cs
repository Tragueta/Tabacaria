using AutoFixture;
using System;
using System.Collections.Generic;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Interfaces.Repositories;

namespace Tabacaria.Infra.Repositories
{
    public class EssenceRepository : IEssenceRepository
    {
        private Random Random = new Random();
        private Fixture Fixture = new Fixture();

        public EssenceEntity Insert(EssenceEntity request)
        {
            return new EssenceEntity()
            {
                Id = Random.Next(1, 100),
                Type = request.Type,
                Name = request.Name,
                Description = request.Description,
                Brand = request.Brand,
                Value = request.Value,
                Flavor = request.Flavor,
                Quantity = request.Quantity
            };
        }

        public IEnumerable<EssenceEntity> GetAllEssences()
        {
            return Fixture.CreateMany<EssenceEntity>(Random.Next(1, 10));
        }
    }
}
