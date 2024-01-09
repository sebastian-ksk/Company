using Company.BLL.Services;
using Company.Models.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers.Users.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        public readonly IUserService _userService;
        public UsersController(IUserService service) {
            _userService = service;
        }

        [HttpGet]
        public ActionResult<List<UserEntity>> ActionResult()
        {
            try
            {
                var users = _userService.GetUsers();
                return Ok(users);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
            
        }

    }
}
