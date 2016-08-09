using AutoMapper;
using TestCore.BusinessLogic.DTO;
using TestCore.BusinessLogic.Factories.Interfaces;
using TestCore.DataAccess.Model;

namespace TestCore.BusinessLogic.Factories.Implementations
{
    /// <summary>
    ///     User factory
    /// </summary>
    public class UserDtoFactory : IUserDtoFactory
    {
        private readonly IMapper _mapper;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public UserDtoFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        ///     Create user model
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserData CreateUserData(UserDto userDto)
        {
            return _mapper.Map<UserData>(userDto);
        }

        /// <summary>
        ///     Create user dto
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public UserDto CreateUserDto(UserData userData)
        {
            return _mapper.Map<UserDto>(userData);
        }
    }
}