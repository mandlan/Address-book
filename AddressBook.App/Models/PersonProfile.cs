using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AddressBook.Models;
using AddressBook.App.Services;

namespace AddressBook.App.Models
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, EditPersonModel>()
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
            CreateMap<EditPersonModel, Person>();
        }
    }
}
