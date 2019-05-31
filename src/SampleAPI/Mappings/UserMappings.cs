using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;

namespace SampleAPI.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
