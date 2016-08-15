using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCore.BusinessLogic.DTO;
using TestCore.BusinessLogic.Factories.Interfaces;
using TestCore.BusinessLogic.Service.Interfaces;
using TestCore.DataAccess.Model;
using TestCore.DataAccess.Repositories.Generic.Interfaces;

namespace TestCore.BusinessLogic.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserDtoFactory _userDtoFactory;
        private readonly IRepository<UserData> _userRepository;

        public UserService(IRepository<UserData> userRepository, IUserDtoFactory userDtoFactory)
        {
            _userRepository = userRepository;
            _userDtoFactory = userDtoFactory;
        }

        /// <summary>
        ///     Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDto>> Get()
        {
            var query = await _userRepository.Table.ToListAsync();
            return query.Select(data => _userDtoFactory.CreateUserDto(data));
        }

        /// <summary>
        ///     Get user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserDto> Get(Guid id)
        {
            var query = await _userRepository.GetByIdAsync(id);
            return _userDtoFactory.CreateUserDto(query);
        }

        /// <summary>
        ///     Insert user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task Insert(UserDto user)
        {
            user.Id = Guid.NewGuid();
            await _userRepository.InsertAsync(_userDtoFactory.CreateUserData(user));
        }

        /// <summary>
        ///     Update user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task Update(UserDto userDto)
        {
            var userData = await _userRepository.GetByIdAsync(userDto.Id);
            await _userRepository.UpdateAsync(userData);
        }

        /// <summary>
        ///     Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var userData = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(userData);
        }
    }
}