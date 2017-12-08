using AutoMapper;
using Example.Model;
using System.Collections.Generic;

namespace Example.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ExampleViewModel, Example>();
        }
    }
}
