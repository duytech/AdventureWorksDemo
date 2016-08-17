namespace AW.Models.Mapper
{
    using AutoMapper;
    public class AWMapperProfile : Profile
    {
        public AWMapperProfile()
        {
            CreateMap<DataAccess.Entities.Person, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
                .ReverseMap();

            CreateMap<DataAccess.Entities.AWBuildVersion, BuildVersion>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SystemInformationID))
                .ForMember(dest => dest.DatabaseVersion, opt => opt.MapFrom(src => src.Database_Version))
                .ReverseMap();
        }
    }
}
