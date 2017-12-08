using AutoMapper;
using Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        : this("MyProfile")
        {
        }
        protected DomainToViewModelMappingProfile(string profileName)
        : base(profileName)
        {
            CreateMap<ExampleEntity, ExampleViewModel>();
        }
    }
}
