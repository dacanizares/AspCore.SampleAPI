using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, BasicUserViewModel>();
        }
    }
}
