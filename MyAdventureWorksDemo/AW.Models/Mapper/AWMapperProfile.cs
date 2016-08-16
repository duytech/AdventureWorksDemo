namespace AW.Models.Mapper
{
    using AutoMapper;
    public class AWMapperProfile : Profile
    {
        public AWMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Person, Person>();
        }
    }
}
