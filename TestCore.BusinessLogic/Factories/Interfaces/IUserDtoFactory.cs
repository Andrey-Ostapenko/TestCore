using TestCore.BusinessLogic.DTO;
using TestCore.DataAccess.Model;

namespace TestCore.BusinessLogic.Factories.Interfaces
{
    public interface IUserDtoFactory
    {
        /// <summary>
        ///     Create user model
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        UserData CreateUserData(UserDto userDto);

        /// <summary>
        ///     Create user dto
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        UserDto CreateUserDto(UserData userData);
    }
}