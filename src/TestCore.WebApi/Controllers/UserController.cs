using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCore.BusinessLogic.Service.Interfaces;
using TestCore.WebApi.Factories.Interfaces;
using TestCore.WebApi.Model;

namespace TestCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserService _userService;

        public UserController([FromServices] IUserService userService, [FromServices] IUserFactory userFactory)
        {
            _userService = userService;
            _userFactory = userFactory;
        }

        // GET api/getAll
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.Get();
            return new JsonResult(users.Select(dto => _userFactory.CreateUserModel(dto)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromBody] Guid id)
        {
            var user = await _userService.Get(id);
            return new JsonResult(user);
        }

        [HttpPost("{userModel}")]
        public async Task Insert([FromBody] UserModel userModel)
        {
            await _userService.Insert(_userFactory.CreateUserDto(userModel));
        }

        [HttpPut("{userModel}")]
        public async Task<IActionResult> Put([FromBody] UserModel userModel)
        {
            await _userService.Update(_userFactory.CreateUserDto(userModel));
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            await _userService.Delete(id);
            return new NoContentResult();
        }
    }
}