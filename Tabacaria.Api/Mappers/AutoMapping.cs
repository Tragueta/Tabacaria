using AutoMapper;
using System;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;

namespace Tabacaria.Api.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateEssenceCommand, EssenceEntity>();
        }

        private T ValidateEnumerator<T>(T enumValue)
        {
            var isValid = Enum.IsDefined(typeof(T), enumValue);
            if (!isValid)
                throw new ArgumentOutOfRangeException(null, "The product type is invalid");

            return enumValue;
        }
    }
}
