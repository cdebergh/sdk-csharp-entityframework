using AutoMapper;
using Example.Model;

namespace Example.API.ViewModels.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
            : this("AutoMapperConfiguration")
        {
        }

        protected AutoMapperConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<ExampleEntity, ExampleViewModel>();
            CreateMap<ExampleViewModel, ExampleEntity>();
        }
    }
}
