using AutoMapper;
using TestCore.BusinessLogic.DTO;
using TestCore.WebApi.Model;

namespace TestCore.WebApi.Mappings.User.Profiles
{
    /// <summary>
    ///     User profiles for automapper
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //User
            CreateMap<UserDto, UserModel>();
            CreateMap<UserModel, UserDto>();
        }
    }
}