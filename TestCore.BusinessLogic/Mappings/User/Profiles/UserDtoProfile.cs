using AutoMapper;
using TestCore.BusinessLogic.DTO;
using TestCore.DataAccess.Model;

namespace TestCore.BusinessLogic.Mappings.User.Profiles
{
    /// <summary>
    ///     User profiles for automapper
    /// </summary>
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            //User
            CreateMap<UserData, UserDto>();
            CreateMap<UserDto, UserData>();
        }
    }
}