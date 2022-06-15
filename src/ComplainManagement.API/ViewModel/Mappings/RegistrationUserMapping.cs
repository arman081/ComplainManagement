using AutoMapper;
using ComplainManagement.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.ViewModel.Mappings
{
    public class RegistrationUserMapping: Profile
    {
        public RegistrationUserMapping()
        {
            CreateMap<ComplainManagementUser, RegisterVm>()
            .ForMember(dest =>
                dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest =>
                dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest =>
                dest.UserEmail,
                opt => opt.MapFrom(src => src.UserEmail))
            .ForMember(dest =>
                dest.UserName,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest =>
                dest.Password,
                opt => opt.MapFrom(src => src.Password))
            .ReverseMap();
        }

    }
}
