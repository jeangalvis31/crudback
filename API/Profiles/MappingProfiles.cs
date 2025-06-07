using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
