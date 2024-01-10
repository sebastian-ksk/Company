using Company.BLL.Services;
using Company.Models.Entities.Users;
using Company.Models.Models.Users;
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
        public async Task<ActionResult<List<User>>> ActionResult()
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            try
            {
                _userService.CreateUser(user);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Put(User user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int userId)
        {
            try
            {
                _userService.DeactivateUser(userId);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
