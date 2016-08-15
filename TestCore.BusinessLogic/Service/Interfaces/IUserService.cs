using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCore.BusinessLogic.DTO;

namespace TestCore.BusinessLogic.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        ///     Get all users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDto>> Get();

        /// <summary>
        ///     Get user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDto> Get(Guid id);

        /// <summary>
        ///     Insert user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Insert(UserDto user);

        /// <summary>
        ///     Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Update(UserDto user);

        /// <summary>
        ///     Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}