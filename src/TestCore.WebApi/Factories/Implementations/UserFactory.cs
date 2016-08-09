using System;
using AutoMapper;
using TestCore.BusinessLogic.DTO;
using TestCore.WebApi.Factories.Interfaces;
using TestCore.WebApi.Model;

namespace TestCore.WebApi.Factories.Implementations
{
    /// <summary>
    ///     User factory
    /// </summary>
    public class UserFactory : IUserFactory
    {
        private readonly IMapper _mapper;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public UserFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        ///     Create user model
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserModel CreateUserModel(UserDto userDto)
        {
            return _mapper.Map<UserModel>(userDto);
        }

        /// <summary>
        ///     Create user dto
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserDto CreateUserDto(UserModel userModel)
        {
            userModel.Id = Guid.NewGuid();
            return _mapper.Map<UserDto>(userModel);
        }
    }
}