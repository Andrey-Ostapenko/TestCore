using TestCore.BusinessLogic.DTO;
using TestCore.WebApi.Model;

namespace TestCore.WebApi.Factories.Interfaces
{
    /// <summary>
    ///     Interface user factory
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        ///     Create user model
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        UserModel CreateUserModel(UserDto userDto);

        /// <summary>
        ///     Create user dto
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        UserDto CreateUserDto(UserModel userModel);
    }
}