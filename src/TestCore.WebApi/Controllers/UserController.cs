using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCore.BusinessLogic.Service.Interfaces;
using TestCore.WebApi.Factories.Interfaces;
using TestCore.WebApi.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TestCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IUserFactory userFactory)
        {
            _userService = userService;
            _userFactory = userFactory;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return users.Select(dto => _userFactory.CreateUserModel(dto));
        }


        [HttpPost]
        public async Task InsertUser(UserModel userModel)
        {
            await _userService.Insert(_userFactory.CreateUserDto(userModel));
        }
    }
}