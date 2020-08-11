using AutoMapper;
using System;
using Tabacaria.Api.ViewModels;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.DTOs;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Enumerators;

namespace Tabacaria.Api.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<EssenceViewModel, EssenceDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => ValidateEnumerator<ProductType>(src.Type)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Flavor, opt => opt.MapFrom(src => src.Flavor))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

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
