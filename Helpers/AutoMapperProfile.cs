using AutoMapper;
using CaseTracker.Dtos;
using CaseTracker.Models;

namespace CaseTracker.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Case, CaseDtos>().ReverseMap();

            CreateMap<Case, CaseUpdateDtos>().ReverseMap();
        }
    }
}
