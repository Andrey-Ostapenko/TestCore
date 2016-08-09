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
        Task<IEnumerable<UserDto>> GetAllUsers();

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
        /// <param name="user"></param>
        /// <returns></returns>
        Task Delete(UserDto user);
    }
}