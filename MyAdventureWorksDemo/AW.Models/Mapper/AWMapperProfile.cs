namespace AW.Models.Mapper
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AWMapperProfile : Profile
    {
        public AWMapperProfile()
        {
            CreateMap<DataAccess.Entities.Person, Person>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.AWBuildVersion, BuildVersion>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.EmailAddress, EmailAddress>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.PersonPhone, PersonPhone>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.PhoneNumberType, PhoneNumberType>()
                .ReverseMap();

            CreateMap<DataAccess.Entities.Customer, Customer>()
                .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.Person.BusinessEntityID))
                .ForMember(dest => dest.PersonType, opt => opt.MapFrom(src => src.Person.PersonType))
                .ForMember(dest => dest.NameStyle, opt => opt.MapFrom(src => src.Person.NameStyle))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Person.Title))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.Person.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => src.Person.Suffix))
                .ForMember(dest => dest.EmailPromotion, opt => opt.MapFrom(src => src.Person.EmailPromotion))
                .ForMember(dest => dest.AdditionalContactInfo, opt => opt.MapFrom(src => src.Person.AdditionalContactInfo))
                .ForMember(dest => dest.Demographics, opt => opt.MapFrom(src => src.Person.Demographics))
                .ForMember(dest => dest.EmailAddresses, opt => opt.MapFrom(src => src.Person.EmailAddresses))
                .ForMember(dest => dest.PersonPhones, opt => opt.MapFrom(src => src.Person.PersonPhones));

            CreateMap<Customer, DataAccess.Entities.Customer>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore()).AfterMap((s, d) => { if (s.ModifiedDate != DateTime.MinValue) d.ModifiedDate = s.ModifiedDate; })
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.BusinessEntityID == "0" ? null : new DataAccess.Entities.Person
                {
                    BusinessEntityID = int.Parse(src.BusinessEntityID),
                    PersonType = src.PersonType,
                    NameStyle = src.NameStyle,
                    Title = src.Title,
                    FirstName = src.FirstName,
                    MiddleName = src.MiddleName,
                    LastName = src.LastName,
                    Suffix = src.Suffix,
                    EmailPromotion = src.EmailPromotion,
                    AdditionalContactInfo = src.AdditionalContactInfo,
                    Demographics = src.Demographics,
                    EmailAddresses = src.EmailAddresses != null && src.EmailAddresses.Count > 0 ? Mapper.Map<ICollection<DataAccess.Entities.EmailAddress>>(src.EmailAddresses) : null,
                    PersonPhones = src.PersonPhones != null && src.PersonPhones.Count > 0 ? Mapper.Map<ICollection<DataAccess.Entities.PersonPhone>>(src.PersonPhones) : null
                }));

            CreateMap<DataAccess.Entities.Employee, Employee>()
                .ReverseMap();
        }
    }
}
