using AutoMapper;
using Tabacaria.Api.ViewModels;
using Tabacaria.Domain.DTOs;

namespace Tabacaria.Api.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<EssenceViewModel, EssenceDTO>();
        }
    }
}
